<template>
  <div v-if="state.loading === true && !state.activeProfile">
    <h1>Loading...</h1>
  </div>
  <div class="ProfileDetailsPage container-fluid" v-else>
    <div class="row">
      <div class="col-2 d-flex">
        <img :src="state.profile.picture" alt="">
      </div>
      <div class="col-10">
        <h2>{{ state.profile.name }}</h2>
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
    <div class="row">
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
import { computed, onMounted, reactive } from 'vue'
import { AppState } from '../AppState'
import { profilesService } from '../services/ProfilesService'
import Notification from '../utils/Notification'
import { useRoute } from 'vue-router'
import { keepsService } from '../services/KeepsService'
import { vaultsService } from '../services/VaultsService'

export default {
  name: 'ProfileDetailsPage',
  setup() {
    const route = useRoute()
    const state = reactive({
      loading: true,
      profile: computed(() => AppState.activeProfile),
      vaults: computed(() => AppState.vaults),
      keeps: computed(() => AppState.keeps),
      account: computed(() => AppState.account)
    })
    onMounted(async() => {
      try {
        await profilesService.getById(route.params.id)
        await vaultsService.getVaultsByProfileId(route.params.id)
        await keepsService.getKeepsByProfileId(route.params.id)
        state.loading = false
      } catch (error) {
        Notification.toast('Error: ' + error, 'error')
      }
    })
    return {
      state,
      route
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>
    .card-columns {
        column-count: 8;
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
