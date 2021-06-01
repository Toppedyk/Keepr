<template>
  <div class="modal"
       id="keepDetails"
       tabindex="-1"
       aria-labelledby="exampleModalLabel"
       aria-hidden="true"
       v-if="state.keep"
  >
    <div class="modal-dialog modal-xl">
      <div class="modal-content">
        <div class="row">
          <div class="col-6">
            <img :src="state.keep.img" alt="keep image" class="img-fluid w-100">
          </div>
          <div class="col-6">
            <div class="row">
              <div class="col">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span>
                </button>
              </div>
            </div>
            <div class="row ">
              <div class="col d-flex justify-content-center align-items-baseline">
                <i class="fas fa-eye"></i><span class="ml-2 mr-4 number-details">{{ state.keep.views }}</span>
                <i class="fab fa-kaggle"></i><span class="ml-2 mr-4 number-details">{{ state.keep.keeps }}</span>
                <i class="fas fa-share-alt"></i><span class="ml-2 mr-4 number-details">{{ state.keep.shares }}</span>
              </div>
            </div>
            <div class="row mt-4">
              <div class="col d-flex justify-content-center">
                <h2>{{ state.keep.name }}</h2>
              </div>
            </div>
            <div class="row">
              <div class="col d-flex justify-content-center mt-4">
                <p>{{ state.keep.description }}</p>
              </div>
            </div>
          </div>
        </div>
        <div class="modal-footer d-flex justify-content-between">
          <button type="button" class="btn btn-secondary" data-dismiss="modal" @click="deleteKeep">
            Delete
          </button>
          <form @submit.prevent="addVaultKeep">
            <div class="dropdown" v-if="state.accountVaults.length === 0">
              <label class="mr-1">Add to Vault</label>
              <select class="form-select" aria-labelledby="dropdownMenuButton" style="border: 1px gray solid;" v-model="state.newVaultKeep.vaultId" required>
                <option>
                  No vaults created
                </option>
              </select>
            </div>
            <div class="dropdown" v-else>
              <label class="mr-1">Add to Vault</label>
              <select class="form-select"
                      aria-labelledby="dropdownMenuButton"
                      style="border: 1px gray solid;"
                      v-model="state.newVaultKeep.vaultId"
                      required
              >
                <option v-for="vault in state.accountVaults" :key="vault.id" :value="vault.id">
                  {{ vault.name }}
                </option>
              </select>
              <button type="submit" class="btn btn-success btn-sm" v-if="state.accountVaults.length > 0">
                <i class="fas fa-plus-circle ml-3"></i>
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
import { useRouter } from 'vue-router'
import { vaultsService } from '../services/VaultsService'
import $ from 'jquery'
import Swal from 'sweetalert2'
export default {
  name: 'KeepDetailsModal',
  setup() {
    const router = useRouter()
    const state = reactive({
      keep: computed(() => AppState.activeKeep),
      accountVaults: computed(() => AppState.vaults),
      newVaultKeep: {}
    })
    return {
      state,
      router,
      async addVaultKeep() {
        try {
          state.newVaultKeep.keepId = state.keep.id
          await vaultsService.getById(state.newVaultKeep.vaultId)
          await keepsService.addVaultKeep(state.newVaultKeep)
          $('#keepDetails').modal('toggle')
          Notification.toast('Successfully Created', 'success')
          router.push({ name: 'VaultDetailsPage', params: { id: state.newVaultKeep.vaultId } })
          state.newVaultKeep = {}
        } catch (error) {
          Notification.toast('Error: ' + error, 'warning')
        }
      },
      async deleteKeep() {
        try {
          await Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
          }).then((result) => {
            if (result.isConfirmed) {
              keepsService.delete(state.keep.id)
              Notification.toast('Successfully Deleted', 'success')
            }
          })
        } catch (error) {
          Notification.toast('Error: ' + error, 'warning')
        }
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>
.number-details{
  font-weight: bold;
}
</style>
