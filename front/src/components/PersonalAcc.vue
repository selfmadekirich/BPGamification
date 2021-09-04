<template>
  <div class="account container d-flex flex-wrap">
    <div class="col-12 col-lg-6">
      <h2>Какая-то инфа</h2>
    </div>
    <div class="col-12 col-lg-6">
      <h2>Ачивки</h2>
      {{ person }}
    </div>
  </div>
</template>
<style scoped>
.account {
  margin-top: 5%;
}
</style>
<script>
import { getAcc } from '../api'
export default {
  name: 'PersonalAcc',
  data() {
    return {
      person: null,
    }
  },
  mounted() {
    getAcc.then((json) => {
      this.person = json
    })
  },
}
</script>
