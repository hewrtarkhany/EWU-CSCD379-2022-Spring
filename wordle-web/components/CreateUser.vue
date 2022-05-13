<template  >   

      <v-dialog
        v-model="dialog"
        persistent
        max-width="600px"
      >
  
        <v-card>
          <v-card-title>
            <span class="text-h5">Player</span>
          </v-card-title>
          <v-card-text>
            <v-container>
              <v-row>
                <v-col
                  cols="12"
                  sm="6"
                  md="4"
                >
                  <v-text-field
                    v-model="userName"
                    required
                  ></v-text-field>
                </v-col>
              </v-row>
            </v-container>
          </v-card-text>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn
              color="blue darken-1"
              text
              @click="dialog = false"
            >
              Close
            </v-btn>
            <v-btn
              color="blue darken-1"
              text
              @click="createUser"
            >
              Save
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
</template>
<script lang="ts">
import { Component, Vue, Prop } from 'vue-property-decorator'
import { WordleGame } from "../scripts/wordleGame"

@Component
export default class CreateUser extends Vue {
  @Prop({ required: true })
  wordleGame!: WordleGame
  @Prop({ required: true })
  dialog: boolean = false
  
  userName :string= ""

async createUser (){
    this.dialog=false;

    const user = {
  score: this.wordleGame.words.length,
  name: this.userName
}
 this.$axios.post('/api/Player', user).then((response) => {
   console.log(response.status);
    })
 localStorage.setItem("player", JSON.stringify( user.name));

}
mounted(){
    const userString = localStorage.getItem("player");
 if(userString){
     const user = JSON.parse(userString);
 this.userName= user?.name || "";
 }


}

}
</script>