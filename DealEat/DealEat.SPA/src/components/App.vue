<template>
    <div id="app">
        <header>
            <nav class="navbar navbar-expand-lg navbar-dark bg-primary" style="margin:2%;">
                    <router-link :to="`/home`" class="navbar-brand" style="width: 4%;"> <img src="../../Logo Deal'eat V1.png" style="width: 200%;"></router-link >
                    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarColor01" aria-controls="navbarColor01" aria-expanded="false" aria-label="Toggle navigation">
                      <span class="navbar-toggler-icon"></span>
                    </button>
                  
                    <div class="collapse navbar-collapse" id="navbarColor01">
                      <ul class="navbar-nav mr-auto">
                        <h1 class="test-font" style="margin-left: 50%;">
                          Deal'Eat
                        </h1>
                      </ul>
                      
                      <form class="form-inline my-2 my-lg-0">
                        <div v-if="isConnected()">
                        {{email}}
                        <button type='button' @click="logout()" class='btn btn-block btn-secondary'>Deconnexion</button>  
                        </div>
                        <div v-else >
                         <button type='button' @click="login('BaseWeb')" class='btn btn-block btn-secondary'>Se connecter</button>  
                        </div>
                        <input class="form-control mr-sm-2" type="text" placeholder="Chercher...">
                        <button class="btn btn-secondary my-2 my-sm-0" type="submit"><i class="fas fa-search"></i></button>
                      </form>
                    </div>
            </nav>
        </header>

    <div>
                
    </div>
        <main role="main" class="p-3 p-md-4 p-lg-5">
            <router-view class="child"></router-view>
        </main>
        
    </div>
</template>

<script>
import AuthService from '../services/AuthService'
import Vue from 'vue'

export default {
    data() {
        return {
            endpoint: null,
            email : 'test'
        }
    },

    mounted() {
        AuthService.registerAuthenticatedCallback(() => this.onAuthenticated());
        this.email = AuthService.email;

    },

    beforeDestroy() {
        AuthService.removeAuthenticatedCallback(() => this.onAuthenticated());
    },

    methods: {
      isConnected(){
        console.log( "Connecté = "+AuthService.isConnected+" Email = "+AuthService.email);
        return AuthService.isConnected;
      },
        login(provider) {
            AuthService.login(provider);
            
        },
        home(){
          this.$router.go("/");
        },
        onAuthenticated() {
           this.$router.go("/home");
        },
        logout(){
          AuthService.logout();
          console.log( "Deconnexion = "+AuthService.isConnected+" Email = "+AuthService.email);
          this.$router.go("/home");
        }
    }
}
</script>
<style lang="css" scoped>
@import "../styles/bootstrap.css";
</style>
