<template>
  <div class="account container d-flex flex-wrap">
    <div class="stat col-12 col-lg-6">
      <h2>Статистика</h2>
      <div v-if="person">
        <h5>Выполнено: {{ person.dailyTask }} заданий</h5>
        <h5>
          Совершено ошибок:
          {{ (person.percent * 100).toString().slice(0, 2) }} %
        </h5>
      </div>
    </div>
    <div class="col-12 col-lg-6">
      <h2>Задачи</h2>
      <div v-if="person">
        <div v-for="p in person.todayTask" :key="p.id" class="mt-4">
          <h5>{{ p.task.taskName }}</h5>
          <b-progress
            :value="p.task.result.split('/')[0]"
            :max="p.task.result.split('/')[1]"
            show-progress
            animated
          ></b-progress>
          <p>За это задание вы можете получить {{ p.task.award }} баллов</p>
        </div>
      </div>
    </div>
  </div>
</template>
<style scoped>
.account {
  margin-top: 5%;
}
.progress {
  height: 25px;
}
.stat h5 {
  padding-top: 25px;
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
      console.log(json)
    })
  },
}
</script>
