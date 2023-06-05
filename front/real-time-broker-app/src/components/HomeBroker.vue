<template>
  <div class="container">
    <card-broker :cor="red" />
    <card-broker :cor="blue" />
    <card-broker :cor="green" />
  </div>
</template>

<script>
import CardBroker from "./CardBroker.vue"

export default {
  components: {
    CardBroker,
  },
}
</script>

<style scoped>
.container {
  display: flex;
  justify-content: center;
  flex-wrap: wrap;
}
</style>
