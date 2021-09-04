<template>
  <div class="leader-list">
    <div
      v-for="user in users"
      :key="user.id"
      class="d-flex justify-content-center"
    >
      <b-list-group-item>
        <div class="d-flex justify-content-between">
          <p>{{ user.name }}</p>
          <p>{{ user.id }}</p>
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
  min-width: 300px;
  max-width: 500px;
}
</style>
<script>
import { getUsers } from '../users'
export default {
  name: 'LeaderBoard',
  data() {
    return {
      users: [],
    }
  },
  mounted() {
    getUsers.then((json) => {
      json.forEach((e) => {
        this.users.push(e)
      })
    })
    console.log(this.users)
  },
}
</script>
