<template>
  <v-card >
<v-card-title>Register</v-card-title>
        <v-form v-model="isValid">

    <v-card-text >
      <v-text-field
          label="Age"
          v-model="age"
            :rules="[v => !!v || 'UserName is Required',
                      ]"
          error-count="2"
          required
        >

        </v-text-field>
        <v-text-field
          label="UserName"
          v-model="username"
            :rules="[v => !!v || 'UserName is required',
                        v => /.+.+/.test(v) || 'UserName must be valid']"
          error-count="2"
          required

        >

        </v-text-field>
        <v-text-field
          label="Password"
          v-model="password"
          type="password"
            :rules="[v => !!v || 'Password is required',
                        v => (v && v.length >= 8) || 'Password must have 8+ characters',
                        v => /(?=.*[A-Z])/.test(v) || 'Must have one uppercase character',
                        v => /(?=.*\d)/.test(v) || 'Must have one number',
                        v => /([!@$%])/.test(v) || 'Must have one special character [!@#$%]']"
          required
        >

        </v-text-field>
        <v-card-actions>
          <v-btn
          rounded
          color="grey"
          > Register</v-btn>
        </v-card-actions>
    </v-card-text>
  </v-form>
  </v-card>
  
</template>
<script lang="ts">
import { Component, Vue } from "vue-property-decorator";

@Component
export default class RegistrationForm  extends Vue{
  username:any=null
  password:any=null
  age:number=0
  isValid:boolean=false

  ageChekcer=()=>{
    if(this.age<21){
      return ("You have to over 21 Years old to Play")
    }
  }
}
</script>