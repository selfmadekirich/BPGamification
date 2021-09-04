<template>
  <div id="app">
    <div>
      <b-navbar toggleable="lg" class="container pt-3 align-items-center">
        <b-navbar-brand
          ><router-link to="/" class="h3"
            >Баланс Платформа</router-link
          ></b-navbar-brand
        >

        <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

        <b-collapse id="nav-collapse" class="justify-content-end" is-nav>
          <b-navbar-nav>
            <b-nav-item class="d-flex"
              ><router-link to="/LeaderBoard">Таблица лидеров</router-link
              ><img src="./assets/crown.png"
            /></b-nav-item>
            <b-nav-item class="d-flex"
              ><router-link to="/Market">Магазин</router-link
              ><img src="./assets/market.png" />
            </b-nav-item>
            <b-nav-item class="d-flex"
              ><router-link to="/PersonalAcc"> Личный кабинет</router-link
              ><img src="./assets/sing-in.png"
            /></b-nav-item>
          </b-navbar-nav>
        </b-collapse>
      </b-navbar>
    </div>
    <router-view></router-view>
  </div>
</template>

<style scoped>
a {
  color: black;
  text-decoration: none;
  padding-left: 7px;
  padding-right: 7px;
  font-size: 20px;
  font-weight: 500;
}
a:hover {
  color: black;
}
nav {
  border-bottom: black 3px solid;
}
</style>
<script>
export default {
  name: 'App',
}
</script>
