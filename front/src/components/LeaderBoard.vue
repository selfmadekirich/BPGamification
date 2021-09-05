<template>
  <div class="leader-list">
    <div
      v-for="user in users"
      :key="user.operatorId"
      class="d-flex justify-content-center"
    >
      <b-list-group-item :class="{ green: user.itsMe }">
        <div class="d-flex align-items-center">
          <img src="../assets/star.png" alt="" />
          <p class="name">{{ user.name }}</p>
          <p class="bonus">{{ user.reputation }} b</p>
          <p class="bonus">{{ (user.bonus * 100).toString().slice(0, 5) }}%</p>
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
  width: 550px;
}
p {
  font-size: 20px;
  font-weight: 500;
  padding: 5px;
  margin: 0;
}
.green {
  background-color: #98ff98;
}
.name {
  width: 300px;
}
.bonus {
  width: 75px;
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
