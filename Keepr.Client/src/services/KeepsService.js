import { AppState } from '../AppState'
import { api } from './AxiosService'

class KeepsService {
  async getAll() {
    const res = await api.get('api/keeps')
    AppState.keeps = res.data.reverse()
  }

  async getKeepsByProfileId() {

  }

  getKeepsByVaultId(id) {

  }

  async getKeep(id) {
    const res = await api.get(`api/keeps/${id}`)
    AppState.activeKeep = res.data
  }

  async create() {

  }

  async delete() {

  }

  async edit() {

  }
}
export const keepsService = new KeepsService()
