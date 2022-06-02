<template>
  <v-card>
    <v-card-title>Login</v-card-title>
        <v-form v-model="isValid">
    <v-card-text>
        <v-text-field
          label="UserName"
          v-model="username"
            :rules="[v => !!v || 'UserName is Required']"
          required
        >

        </v-text-field>
        <v-text-field
          label="Password"
          v-model="password"
          type="password"
            :rules="[v => !!v || 'Password is Required']"
          required
        >

        </v-text-field>
        <v-card-actions>
          <v-btn
          rounded
          color="green"
          > Login</v-btn>
              <v-btn
          rounded
          color="primary"
          text block nuxt to="/registrationForm"
          > Register</v-btn>

        </v-card-actions>
    </v-card-text>
  </v-form>
  </v-card>
  
</template>
<script lang="ts">
import { Component, Vue } from "vue-property-decorator";

@Component
export default class LoginForm  extends Vue{
  username:any=null
  password:any=null
  isValid:boolean=false
}
</script>