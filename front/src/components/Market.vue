<template>
  <div class="container d-flex flex-wrap">
    <div
      v-for="item in items"
      :key="item.id"
      class="all-cards col-lg-4 col-md-6 col-12 "
    >
      <div class="d-flex flex-column justify-content-center align-items-center">
        <img :src="item.image" />
        <h5 class="mt-3">{{ item.info }} {{ item.price }}</h5>
        <button type="button" class="btn">
          <h4 class="mt-3">Забрать</h4>
        </button>
      </div>
    </div>
  </div>
</template>
<style scoped>
.all-cards {
  margin-top: 3%;
}
img {
  width: 270px;
  height: 270px;
  border-radius: 12px;
}
</style>
<script>
import { getShop } from '../api'
export default {
  name: 'Market',
  data() {
    return {
      items: [],
    }
  },
  mounted() {
    getShop.then((json) => {
      json.listItems.forEach((element) => {
        this.items.push(element)
      })
      console.log(json)
    })
  },
}
</script>
