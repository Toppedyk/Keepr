<template>
  <div class="modal" id="createVault" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="exampleModalLabel">
            New Vault
          </h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <form @submit.prevent="createVault">
            <div class="form-group">
              <label for="vault name">Name</label>
              <input type="text" class="form-control" id="name" v-model="state.newVault.name" required>
            </div>
            <div class="form-group">
              <label for="vault description">Description</label>
              <input type="text" class="form-control" id="description" v-model="state.newVault.description">
            </div>
            <div class="form-group">
              <label for="vault image">Image Url</label>
              <input type="text" class="form-control" id="imgUrl" v-model="state.newVault.imgUrl">
            </div>
            <label>
              <input type="checkbox" v-model="state.newVault.isPrivate" />
              Private
            </label>
            <div class="modal-footer">
              <button type="button" class="btn btn-secondary" data-dismiss="modal">
                Close
              </button>
              <button type="submit" class="btn btn-primary">
                Save changes
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, reactive } from 'vue'
import { vaultsService } from '../services/VaultsService'
import { AppState } from '../AppState'
import Notification from '../utils/Notification'
export default {
  name: 'CreateVaultModal',
  setup() {
    const state = reactive({
      newVault: {},
      account: computed(() => AppState.account)
    })
    return {
      state,
      async createVault() {
        state.newVault.creatorId = state.account.id
        await vaultsService.create(state.newVault)
        Notification.toast('Successfully created', 'success')
        state.newVault = {}
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
