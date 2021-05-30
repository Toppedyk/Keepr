<template>
  <div class="Keep card" :style="{ backgroundImage: `url(${keep.img})` }">
    <div class="card-body">
      <h5 class="card-title">
        Card title
      </h5>
      <p class="card-text">
        {{ keep.description }}
      </p>
    </div>
  </div>
</template>

<script>
export default {
  name: 'Keep',
  props: {
    keep: {
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

.card{
background-size: cover;
background-repeat: no-repeat;
min-height: 30vh;
}

</style>
