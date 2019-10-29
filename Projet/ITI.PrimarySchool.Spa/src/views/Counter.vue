<template>
  <div class="about">
    <h1>Compteur</h1>
    <p>Count: {{ count }}</p>
    <input type="number" v-model.number="step" />
    <button @click="onClicked">Increment</button>
  </div>
</template>

<script>
export default {
  data() {
    return {
      count: 0,
      step: 1
    };
  },

  methods: {
    onClicked() {
      this.count += this.step;
    }
  }
}
</script>
