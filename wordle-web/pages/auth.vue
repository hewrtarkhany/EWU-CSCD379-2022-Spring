<template>
<v-main>
 <v-app-bar
  app
  color="grey"
  dark
  >
    <v-toolbar-title> Wordle Login</v-toolbar-title>
  </v-app-bar>
    <login-form/>
  </v-main>

</template>

<script lang="ts" >
import { Component,Vue } from "vue-property-decorator";
import LoginForm from "~/components/loginForm.vue";

@Component ({components: {LoginForm}})
export default class Auth extends Vue  {
  tab: boolean= true

};


</script>