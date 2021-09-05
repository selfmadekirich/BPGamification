<template>
  <div class="container d-flex flex-wrap">
    <div
      v-for="item in items"
      :key="item.id"
      class="all-cards col-lg-4 col-md-6 col-12 "
    >
      <div class="d-flex flex-column">
        <img src="../assets/pizza.jpg" />
        <h3>{{ item.info }}</h3>
        <h2>{{ item.price }}</h2>
      </div>
    </div>
  </div>
</template>
<style scoped>
.all-cards {
  margin-top: 5%;
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
