<template>
  <div class="card col-3">
    <img :src="vault.imgUrl" class="card-img-top img-fluid w-100" alt="...">
    <div class="card-body">
      <h5 class="card-title">
        {{ vault.name }}
      </h5>
      <p v-if="vault.isPrivate ==true">
        PRIVATE
      </p>
    </div>
  </div>
</template>

<script>
export default {
  name: 'Vault',
  props: {
    vault: {
      type: Object,
      required: true
    }
  },
  setup() {
    return {}
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
