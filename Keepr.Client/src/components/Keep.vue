<template>
  <div class="Keep col-3">
    <div class="card d-flex" :style="{ backgroundImage: `url(${keep.img})` }">
      <!-- <img :src="keep.img" class="card-img-top" alt="..."> -->
      <div class="card-body">
        <h5 class="card-title">
          Card title
        </h5>
        <p class="card-text">
          Some quick example text to build on the card title and make up the bulk of the card's content.
        </p>
      </div>
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
background-size: contain;
}

</style>
