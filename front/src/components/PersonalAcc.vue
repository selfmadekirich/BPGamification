<template>
  <div class="account container d-flex flex-wrap">
    <div class="col-12 col-lg-6">
      <h2>Какая-то инфа</h2>
    </div>
    <div class="col-12 col-lg-6">
      <h2>Ачивки</h2>
    </div>
  </div>
</template>
<style scoped>
.account {
  margin-top: 5%;
}
</style>
<script>
import { getUsers } from '../users'
export default {
  name: 'PersonalAcc',
  data() {
    return {
      user: Object,
    }
  },
  mounted() {
    getUsers.then((json) => {
      this.user = json[0]
    })
    console.log(this.user)
  },
}
</script>
