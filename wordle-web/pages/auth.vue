<template>
<v-card img="https://media1.giphy.com/media/11j5OF7BTglVkc/giphy.gif?cid=ecf05e473hc9ko06fmqmenf0sggjzm26jaaifwi2a0v8civs&rid=giphy.gif&ct=g">
<v-main >
  <v-container class="text-center ma-10 pa-0" >
    <v-row dense >
      <v-col cols="5" >
    <login-form/> 
</v-col>
</v-row>
  </v-container>
  </v-main>
</v-card>
</template>

<script lang="ts" >
import { Component,Vue } from "vue-property-decorator";
import LoginForm from "~/components/loginForm.vue";
import SignUp from "~/pages/signUp.vue"

@Component ({components: {LoginForm,SignUp}})
export default class Auth extends Vue  {
  tab: boolean= true

};


</script>