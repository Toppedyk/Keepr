import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class KeepsService {
  async getAll() {
    const res = await api.get('api/keeps')
    AppState.keeps = res.data.reverse()
  }

  async getKeepsByProfileId(id) {
    const res = await api.get(`api/profiles/${id}/keeps`)
    AppState.keeps = res.data.reverse()
  }

  async getKeepsByVaultId(id) {
    const res = await api.get(`api/vaults/${id}/keeps`)
    AppState.keeps = res.data.reverse()
  }

  async getVaultKeep(id) {
    const res = await api.get(`api/vaultkeeps/${id}`)
    logger.log(res.data)
    AppState.activeVaultKeep = res.data
  }

  async getKeep(id) {
    const res = await api.get(`api/keeps/${id}`)
    AppState.activeKeep = res.data
  }

  async create(keep) {
    await api.post('api/keeps', keep)
    await this.getKeepsByProfileId(keep.creatorId)
  }

  async addVaultKeep(vaultKeep) {
    const res = await api.post('api/vaultkeeps', vaultKeep)
    await this.getKeepsByVaultId(res.data.vaultId)
  }

  async removeVaultKeep(vaultKeepId) {
    await api.delete(`api/vaultkeeps/${vaultKeepId}`)
  }

  async delete(id) {
    await api.delete(`api/keeps/${id}`)
    this.getAll()
  }

  async edit(keep) {
    await api.put(`api/keeps/${keep.id}`, keep)
    this.getAll()
  }
}
export const keepsService = new KeepsService()
