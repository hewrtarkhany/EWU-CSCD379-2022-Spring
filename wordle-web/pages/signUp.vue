<template>
<v-card img="https://media3.giphy.com/media/QpVUMRUJGokfqXyfa1/giphy.gif?cid=ecf05e4744zuw1m022b1vg0g3e56q5q7g2nietpqik8nxq2n&rid=giphy.gif&ct=g">
<v-main >
  <v-container class="text-center ma-10 pa-0" >
    <v-row dense >
      <v-col cols="5" >
        <template>
          <v-card width="auto">
                <v-card-title>SignUp</v-card-title>
        <v-form v-model="isValid">
            <v-card-text >
        <v-text-field
          label="UserName"
          color="#00ACC1"
          v-model="username"
            :rules="[v => !!v || 'UserName is required',
                        v => /.+.+/.test(v) || 'UserName must be valid']"
          error-count="2"
          required

        >

        </v-text-field>
        <v-text-field
          label="Password"
          color="#00ACC1"
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
              <v-text-field
          label="Age"
          v-bind="age"
            :rules="[v => !!v || 'UserName is Required',
                      ]"
          error-count="2"
          color="#00ACC1"
          required
        >

        </v-text-field>
        <v-card-actions>
          <v-btn
          rounded
          color="#00ACC1"
          > Register</v-btn>
        </v-card-actions>
    </v-card-text>
</v-form>
          </v-card>
        </template>
</v-col>
</v-row>
  </v-container>
  </v-main>
</v-card>
</template>
<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
@Component
export default class SignUpForm  extends Vue{
  
  isValid:boolean=false
  age:number=0
   ageChekcer=()=>{
    if(this.age<21){
      return ("You have to over 21 Years old to Play")
    }
  }
  postSignup=()=>{
    this.$axios.post('/api/DateWord',{
      withCredentials: true,
      headers:{
        "Accept":"application/json",
        "Content-Type":"application/json"
      }},{
        auth:{
          username: "username",
          password: "password"
        }
      }
      ).then((response)=>{
        console.log(response.data)
      }).catch((error)=>{
         console.log(error);

      })

      
  }

}
</script>