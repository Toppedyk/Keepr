import { AppState } from '../AppState'
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

  async getKeep(id) {
    const res = await api.get(`api/keeps/${id}`)
    AppState.activeKeep = res.data
  }

  async create(keep) {
    await api.post('api/keeps', keep)
    await this.getKeepsByProfileId(keep.creatorId)
  }

  async delete(id, profileId) {
    await api.delete(`api/keeps/${id}`)
    await this.getKeepsByProfileId(profileId)
  }

  async edit(keep) {
    await api.put(`api/keeps/${keep.id}`, keep)
    await this.getKeepsByProfileId(keep.creatorId)
  }
}
export const keepsService = new KeepsService()
