<template>
  <div v-if="state.loading === true && !state.account">
    <h1>Loading...</h1>
  </div>
  <div class="AccountDetailsPage container-fluid" v-else>
    <div class="row">
      <div class="col-2 d-flex">
        <img :src="state.account.picture" alt="">
      </div>
      <div class="col-10">
        <h2>{{ state.account.name }}</h2>
        <p>Vaults: <span>{{ state.vaults.length }}</span> </p>
        <p>Keeps: <span>{{ state.keeps.length }}</span></p>
      </div>
    </div>
    <div class="row">
      <div class="col d-flex">
        <h3>Vaults </h3>
        <button type="button" class="btn btn-success ml-3" data-toggle="modal" data-target="#createVault">
          Add Vault
        </button>
      </div>
    </div>
    <div class="row" v-if="state.vaults.length > 0">
      <Vault v-for="vault in state.vaults" :key="vault.id" :vault="vault" />
    </div>
    <div class="row">
      <div class="col">
        <h3>Keeps</h3>
        <button type="button" class="btn btn-success ml-3" data-toggle="modal" data-target="#CreateKeepModal">
          Add Keep
        </button>
      </div>
    </div>
    <div class="row justify-content-center">
      <div class="col-12">
        <div class="card-columns mt-3">
          <Keep v-for="keep in state.keeps" :key="keep.id" :keep="keep" />
        </div>
      </div>
    </div>
    <CreateKeepModal />
    <CreateVaultModal />
  </div>
</template>

<script>
import { computed, onMounted, reactive, watchEffect } from 'vue'
import { AppState } from '../AppState'
import { profilesService } from '../services/ProfilesService'
import { vaultsService } from '../services/VaultsService'
import { keepsService } from '../services/KeepsService'
import Notification from '../utils/Notification'
export default {
  name: 'Account',
  setup() {
    const state = reactive({
      loading: true,
      profile: computed(() => AppState.activeProfile),
      vaults: computed(() => AppState.accountVaults),
      keeps: computed(() => AppState.keeps),
      account: computed(() => AppState.account)
    })
    watchEffect(async() => {
      await vaultsService.getVaultsByAccountId(state.account.id)
      await keepsService.getKeepsByProfileId(state.account.id)
    })
    onMounted(async() => {
      try {
        await profilesService.getById(state.account.id)
        await vaultsService.getVaultsByAccountId(state.account.id)
        await keepsService.getKeepsByProfileId(state.account.id)
        state.loading = false
      } catch (error) {
        Notification.toast('Error: ' + error, 'error')
      }
    })
    return {
      state
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>
    .card-columns {
        column-count: 5;
    }
@media(max-width: 900px){
      .card-columns {
        column-count: 3;
    }

}

@media(max-width: 574px){
      .card-columns {
        column-count: 2;
    }
}
</style>
