<template>
  <div class="modal fade "
       id="keepDetails"
       tabindex="-1"
       aria-labelledby="exampleModalLabel"
       aria-hidden="true"
       v-if="state.keep"
  >
    <div class="modal-dialog modal-xl">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="exampleModalLabel">
            {{ state.keep.name }}
          </h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <p></p>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-dismiss="modal">
            Close
          </button>
          <button type="button" class="btn btn-primary">
            Save changes
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, reactive } from 'vue'
import { AppState } from '../AppState'
export default {
  name: 'KeepDetailsModal',
  setup() {
    const state = reactive({
      keep: computed(() => AppState.activeKeep)
    })
    return { state }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
