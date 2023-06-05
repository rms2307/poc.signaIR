<template>
  <HomeBroker />
</template>

<script>
import HomeBroker from "./components/HomeBroker.vue"

export default {
  name: "App",
  components: {
    HomeBroker,
  },
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
