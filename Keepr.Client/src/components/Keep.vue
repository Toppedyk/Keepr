<template>
  <div class="Keep card">
    <img :src="keep.img" alt="keep image" class="img-fluid w-100 image">
    <h5 class="card-title keep-name">
      {{ keep.name }}
    </h5>
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

.image{
  position: relative;
}
.keep-name{
  position: absolute;
  bottom: 8px;
  left: 16px;
  font-weight: bold;
  color: white;
  // -webkit-text-stroke: .1px white;
}
</style>
