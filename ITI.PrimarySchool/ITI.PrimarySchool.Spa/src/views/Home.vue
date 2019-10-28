<template>
  <div class="home">
    <p><button @click="loginClicked">Log in</button></p>
  </div>
</template>

<script>
// @ is an alias to /src
import HelloWorld from '@/components/HelloWorld.vue'
import { setBearer } from '../services/AuthenticationService'

export default {
  methods: {
    loginClicked() {
      let apiUrl = process.env.VUE_APP_API_URL;
      var popup = window.open(apiUrl + '/Authentication/Index', "ITI.PrimarySchool Authentication", "menubar=no, status=no, scrollbars=no, menubar=no, width=700, height=600");
    }
  },

  created() {
    window.addEventListener("message", (e) => {
      if (e.data.type === 'authenticated') {
        setBearer(e.data.payload.token);
      }
    }, false);
  }
}
</script>
