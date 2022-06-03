<template>
  <v-card width="auto">
    <v-card-title>Login</v-card-title>
        <v-form v-model="isValid">
    <v-card-text>
        <v-text-field
          label="UserName"
          color="#00ACC1"
          v-model="username"
            :rules="[v => !!v || 'UserName is Required']"
          required
        >

        </v-text-field>
        <v-text-field
          label="Password"
          color="#00ACC1"
          v-model="password"
          type="password"
            :rules="[v => !!v || 'Password is Required']"
          required
        >

        </v-text-field>
        <v-card-actions>
          <v-row>
            <v-col cols="1">
          <v-btn
          rounded
          color="#00ACC1"
          > Login</v-btn>

            </v-col>
              <v-col cols="8">
              <v-btn
          
          color="#00ACC1"
          rounded
          to="/signUp"
          > Register
          </v-btn>
            </v-col>
            
          </v-row>

          
        

          

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