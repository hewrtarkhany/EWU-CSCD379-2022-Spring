<template>
  <v-card>
    <v-card>
      <v-col cols="12">
        <v-card width="auto">
          <v-card-title>Login</v-card-title>
          <v-form v-model="isValid">
            <v-card-text>
              <v-text-field
                v-model="username"
                label="UserName"
                color="#00ACC1"
                :rules="[v => !!v || 'UserName is Required']"
                required
              >

              </v-text-field>
              <v-text-field
                v-model="password"
                label="Password"
                color="#00ACC1"
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
                      @click="getToken"
                    > Login
                    </v-btn>
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
      </v-col>
    </v-card>
    <v-card v-if="showDialog">
      <v-col cols="12">
        <v-alert
          v-if="isValid"
          :value="true"
          color="success"
          icon="mdi-check"
          dismissible
          transition="scale-transition"
        >
          Login Successful
          <v-btn nuxt to="/wordeditor">Go to world list</v-btn>
        </v-alert>
        <v-alert
          v-else
          :value="true"
          color="error"
          icon="mdi-close"
          dismissible
          transition="scale-transition"
        >
          Login Failed
        </v-alert>
      </v-col>
    </v-card>
  </v-card>
</template>
<script lang="ts">
import {Component, Vue} from "vue-property-decorator";
import {JWT} from "../scripts/jwt";

@Component
export default class LoginForm extends Vue {
  localUsername: string = 'test'
  localPassword: string = ''
  isValid: boolean = false
  showDialog: boolean = false

  getToken() {
    // const token = Buffer.from(`${this.username}:${this.password}`, 'utf8').toString('base64')
    this.$axios.post('/Token/GetToken', {
      Email: this.username,
      Password: this.password
    }).then((response) => {
      console.log(response.data.token);
      JWT.setToken(response.data.token, this.$axios)
      localStorage.setItem('BearerToken', response.data.token)
      localStorage.setItem('userName', this.username)
      this.isValid = true;
    }).catch((error) => {
      this.isValid = false;
      console.log(error);
    })
    this.showDialog = true;
  }

  get username(){
    return this.localUsername;
  }

  set username(value){
    this.localUsername = value;
    this.showDialog = false;
    this.isValid = false;
  }

  get password(){
    return this.localPassword;
  }

  set password(value){
    this.localPassword = value;
    this.showDialog = false;
    this.isValid = false;
  }
}
</script>
