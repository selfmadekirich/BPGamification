<template>
  <div class="all-cards container d-flex flex-wrap justify-content-center">
    <CardMarket />
    <CardMarket />
    <CardMarket />
    <CardMarket />
    <CardMarket />
    <CardMarket />
  </div>
</template>
<style scoped>
.all-cards {
  margin-top: 5%;
}
</style>
<script>
import CardMarket from './CardMarket.vue'
export default {
  name: 'Market',
  components: {
    CardMarket,
  },
}
</script>
