<template>
  <div class="Keep card rounded shadow">
    <img :src="keep.img"
         alt="keep image"
         class="img-fluid w-100 image rounded"
         data-toggle="modal"
         data-target="#exampleModal"
         @click="getKeep"
    >
    <div class="card-title info">
      <h4 class="keep-name mr-4">
        {{ keep.name }}
      </h4>
      <router-link :to="{name: 'ProfileDetailsPage', params:{id:keep.creator.id}}">
        <img :src="keep.creator.picture" alt="profile picture" class="rounded-circle small-img">
      </router-link>
    </div>
    <KeepDetailsModal :keep="keep" />
  </div>
</template>

<script>
import { keepsService } from '../services/KeepsService'
import Notification from '../utils/Notification'
export default {
  name: 'Keep',
  props: {
    keep: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    return {
      async getKeep() {
        try {
          await keepsService.getKeep(props.keep.id)
        } catch (error) {
          Notification.toast('Error: ' + error, 'error')
        }
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>
.card{
min-width: 20vw;
}

.image{
  position: relative;
  // height: auto;
}

.info{
position: absolute;
bottom: .5rem;
left: .5rem;
display: flex;
justify-content: space-between;
align-items: baseline;
margin-bottom: 0;
}
.keep-name{
  font-size: 1em;
  font-weight: bold;
  color: white;
  // -webkit-text-stroke: .1px white;
}

.small-img{
  height:1.5em;
  width: 1.5em;
}
</style>
