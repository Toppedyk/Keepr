<template>
  <div v-if="state.loading === true && !state.vault">
    <h1>Loading...</h1>
  </div>
  <div class="VaultDetails container-fluid" v-else>
    <div class="row">
      <div class="col">
        <h1>{{ state.vault.name }}</h1>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { AppState } from '../AppState'
// import { vaultsService } from '../services/VaultsService'
import { useRoute } from 'vue-router'
import { keepsService } from '../services/KeepsService'
import Notification from '../utils/Notification'
export default {
  name: 'VaultDetailsPage',
  setup() {
    const route = useRoute()
    const state = reactive({
      vault: computed(() => AppState.activeVault),
      keeps: computed(() => AppState.keeps),
      loading: true
    })
    onMounted(async() => {
      try {
        await keepsService.getKeepsByVaultId(route.params.id)
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

</style>
