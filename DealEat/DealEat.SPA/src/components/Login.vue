<template>
    <div class="container p-3">
        <div class="text-center">
            <h1 class="my-4">Bienvenue sur DealEat</h1>

            <button type="button" @click="login('Base')" class="btn btn-lg btn-block btn-primary">Se connecter via DealEat</button>
        </div>
    </div>
</template>

<script>
import AuthService from '../services/AuthService'
import Vue from 'vue'

export default {
    data() {
        return {
            endpoint: null
        }
    },

    mounted() {
        AuthService.registerAuthenticatedCallback(() => this.onAuthenticated());
    },

    beforeDestroy() {
        AuthService.removeAuthenticatedCallback(() => this.onAuthenticated());
    },

    methods: {
        login(provider) {
            AuthService.login(provider);
        },

        onAuthenticated() {
            this.$router.replace('/');
        }
    }
}
</script>

<style >
</style>