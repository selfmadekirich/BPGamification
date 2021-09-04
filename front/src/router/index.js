import Vue from 'vue'
import VueRouter from 'vue-router'
import SingIn from '../components/SingIn.vue'
import LeaderBoard from '../components/LeaderBoard.vue'
import Market from '../components/Market.vue'
import PersonalAcc from '../components/PersonalAcc.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'SingIn',
    component: SingIn,
  },
  {
    path: '/LeaderBoard',
    name: 'LeaderBoard',
    component: LeaderBoard,
  },
  {
    path: '/Market',
    name: 'Market',
    component: Market,
  },
  {
    path: '/PersonalAcc',
    name: 'PersonalAcc',
    component: PersonalAcc,
  },
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes,
})

export default router
