<template>
  <div>
    <div class="card" :style="{ backgroundColor: cor }">
      <h2>Nome da Ação</h2>
      <p>R$ {{ precoAcao }}</p>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    cor: {
      default: "red",
      type: String,
    },
  },
  data() {
    return {
      precoAcao: 30.44,
    }
  },
}
</script>

<style scoped>
.card {
  background-color: white;
  border-radius: 8px;
  box-shadow: 0px 2px 4px rgba(0, 0, 0, 0.1);
  padding: 16px;
  margin: 16px;
  display: inline-block;
  width: 200px;
  height: 100px;
}

.card-green {
  background-color: #80ff80;
}
</style>
