<template>
<v-main>
 <v-app-bar
  app
  color="grey"
  dark
  >
    <v-toolbar-title> Wordle Login</v-toolbar-title>
  </v-app-bar>
  <v-container class="text-center ma-10 pa-0" >
    <v-row >
      <v-col cols="5" >
    <login-form/>
    
</v-col>
</v-row>
  </v-container>
  </v-main>

</template>

<script lang="ts" >
import { Component,Vue } from "vue-property-decorator";
import LoginForm from "~/components/loginForm.vue";
import RegistrationForm from "~/pages/registrationForm.vue";

@Component ({components: {LoginForm, RegistrationForm}})
export default class Auth extends Vue  {
  tab: boolean= true

};


</script>