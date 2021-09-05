<template>
  <div class="home container d-flex justify-content-center">
    <form>
      <div class="mb-3">
        <label for="exampleInputEmail1" class="form-label"
          >Адрес электронной почты</label
        >
        <input
          type="email"
          class="form-control"
          id="exampleInputEmail1"
          aria-describedby="emailHelp"
        />
      </div>
      <div class="mb-3">
        <label for="exampleInputPassword1" class="form-label">Пароль</label>
        <input
          type="password"
          class="form-control"
          id="exampleInputPassword1"
        />
      </div>
      <div class="mb-3 form-check d-flex align-items-center">
        <input type="checkbox" class="form-check-input" id="exampleCheck1" />
        <label class="form-check-label radio-label" for="exampleCheck1"
          >Запомнить меня</label
        >
      </div>
      <button type="submit" class="btn btn-outline-dark">
        <router-link to="/PersonalAcc"> Войти</router-link>
      </button>
    </form>
  </div>
</template>

<style scoped>
.home {
  padding-top: 10%;
}
.form-control {
  width: 300px;
}
label {
  font-size: 20px;
  font-weight: 450;
}
.radio-label {
  padding-left: 5px;
  font-weight: 300;
}
.btn {
  width: 100px;
}
a {
  color: black;
  text-decoration: none;
}
a:hover {
  color: black;
}
</style>

<script>
export default {
  name: 'SingIn',
}
</script>
