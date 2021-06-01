<template>
  <div class="modal fade" id="CreateKeepModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="exampleModalLabel">
            New Keep
          </h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <form @submit.prevent="createKeep">
            <div class="form-group">
              <label for="Keep name">Name</label>
              <input type="text" class="form-control" id="keep name" v-model="state.newKeep.name" required>
            </div>
            <div class="form-group">
              <label for="Keep description">Description</label>
              <input type="text" class="form-control" id="keep description" v-model="state.newKeep.description">
            </div>
            <div class="form-group">
              <label for="Keep image">Image Url</label>
              <input type="text" class="form-control" id="keep imgUrl" v-model="state.newKeep.img">
            </div>
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
import { AppState } from '../AppState'
import { keepsService } from '../services/KeepsService'
import Notification from '../utils/Notification'
export default {
  name: 'CreateKeepModal',
  setup() {
    const state = reactive({
      newKeep: {},
      account: computed(() => AppState.account)
    })
    return {
      state,
      async createKeep() {
        state.newKeep.creatorId = state.account.id
        await keepsService.create(state.newKeep)
        Notification.toast('Successfully created', 'success')
        state.newKeep = {}
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
