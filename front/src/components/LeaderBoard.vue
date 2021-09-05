<template>
  <div class="leader-list">
    <div
      v-for="user in users"
      :key="user.operatorId"
      class="d-flex justify-content-center"
    >
      <b-list-group-item>
        <div class="d-flex justify-content-between align-items-center">
          <img src="../assets/star.png" alt="" />
          <p>{{ user.name }}</p>
          <p>{{ user.reputation }}</p>
        </div>
      </b-list-group-item>
    </div>
  </div>
</template>
<style scoped>
.leader-list {
  padding-top: 5%;
}
.list-group-item {
  border-radius: 10px;
  width: 500px;
}
p {
  font-size: 20px;
  font-weight: 500;
  padding: 5px;
  margin: 0;
}
@media screen and (max-width: 500px) {
  .list-group-item {
    border-radius: 10px;
    width: 300px;
  }
}
</style>
<script>
import { getBoard } from '../api'
export default {
  name: 'LeaderBoard',
  data() {
    return {
      users: [],
    }
  },
  mounted() {
    getBoard.then((json) => {
      json.forEach((element) => {
        this.users.push(element)
      })
      console.log(json)
    })
  },
}
</script>
