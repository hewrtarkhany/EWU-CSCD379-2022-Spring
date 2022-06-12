<template>
  <div id="app">
    <v-app id="inspire">
      <v-card>
        <v-card-title>
          <v-col cols="4">
            <v-row>
              <v-text-field
                v-model="search"
                append-icon="mdi-magnify"
                label="Search"
                single-line
                rounded
                background-color="blue-grey lighten-2"
                hide-details
              >
              </v-text-field>
            </v-row>
            <v-spacer/>
            <v-row v-if="MasterOfTheUniverse">
              <v-text-field
                v-model="newWord"
                label="Add Word"
                single-line
                rounded
                background-color="blue-grey lighten-2"
                hide-details
              >
              </v-text-field>
              <v-col cols="12">
                <v-checkbox
                  v-model="addCommon"
                  label="Common?"
                  color="blue-grey lighten-2"
                ></v-checkbox>
                <v-btn
                  color="blue darken-1"
                  dark
                  rounded
                  @click="addWord(true)"
                >
                  Add
                </v-btn>
              </v-col>
            </v-row>
          </v-col>
        </v-card-title>
      </v-card>
      <v-card class=" ma-3 pa-3">
        <v-row>
          <v-col> Words</v-col>
          <v-col> Common</v-col>
          <v-col v-if="MasterOfTheUniverse"> Delete</v-col>
        </v-row>
        <hr/>
        <div v-if="wordsLoaded">
          <v-row v-for="(word, i) in words" :key="i">
            <v-col v-if="MasterOfTheUniverse" cols="4">
              {{ word.word }}
            </v-col>
            <v-col v-else cols="6">
              {{ word.word }}
            </v-col>
            <v-col v-if="loginState" cols="4">
              <v-checkbox
                v-model="word.common"
                color="blue-grey lighten-2"
                @click="changeCommon(word.word, word.common)"
              ></v-checkbox>
            </v-col>
            <v-col v-else cols="6">
              <v-checkbox
                v-model="word.common"
                disabled
                color="blue-grey lighten-2"
              ></v-checkbox>
            </v-col>
            <v-btn v-if="MasterOfTheUniverse" rounded @click="deleteWord(word.word)">
              Delete
            </v-btn>
          </v-row>
        </div>
        <div v-else>
          <v-progress-circular indeterminate color="blue-grey lighten-2"></v-progress-circular>
        </div>
      </v-card>
    </v-app>
  </div>

</template>
<script lang="ts">
import {Vue, Component, Watch} from 'vue-property-decorator';
import {JWT} from "../scripts/jwt";
import {Word} from '~/scripts/word';

@Component
export default class WordEditor extends Vue {
  pageNumber: number = 0;
  pageSize: number = 10;
  word: Word = new Word()
  words: any = []
  age: number = 0
  search: string = ''
  wordsLoaded: boolean = false
  addCommon: boolean = false
  newWord: string = ''

  async created() {

    await this.getWords()
  }

  get wordsPerPage() {
    return this.pageSize;
  }

  set wordsPerPage(value) {
    this.pageSize = value;
    this.getWords();
  }

  get currentPage() {
    return this.pageNumber;
  }

  set currentPage(value) {
    this.pageNumber = value;
    this.getWords();
  }

  get MasterOfTheUniverse() {

    if (JWT.getToken() != null) {
      console.table(JWT.tokenData)
      console.log("log ", JWT.tokenData["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"])
      for (let i = 0; i < JWT.tokenData.roles; i++) {
        if (JWT.tokenData.roles[i] === "MasterOfTheUniverse") {

          return true;
        }
      }
    } else if (localStorage.getItem('BearerToken') != null) {
      JWT.setToken(localStorage.getItem('BearerToken'), this.$axios);
      console.log("Check again")
      return this.MasterOfTheUniverse;
    }
    console.log("Not MasterOfTheUniverse")
    return false;
  }

  changeCommon(word: string, common: boolean) {
    console.log("Changing common for " + word + " to " + common);
    if (localStorage.getItem('BearerToken') == null) {
      // Need to log in
    } else {
      this.$axios.post('/wordlist/ChangeCommonality',
        {
          word,
          common
        }
      ).then(result => {
        console.log("result", result);
      });
      this.wordsLoaded = false
      this.words = [];
      this.getWords();
      this.getWords();
    }
  }

  addWord() {
    if (localStorage.getItem('BearerToken') == null) {
      // Need to log in
    } else {
      this.$axios.post('/wordlist/AddWord', {
        params: {
          "word": this.newWord,
          "common": this.addCommon.toString()
        },
        headers: {
          'Content-Type': 'application/json',
          'Authorization': 'Bearer ' + localStorage.getItem('BearerToken')
        },
      }).then(result => {
        console.log("result", result);
      });
      this.wordsLoaded = false
      this.words = [];
      this.getWords();
      this.getWords();
    }
  }

  getWords() {
    console.log("getting");
    this.$axios.get('/wordlist/getwordlist', {
      params: {
        pageNumber: this.pageNumber,
        pageSize: this.pageSize,
        search: this.search
      }
    }).then(result => {
      console.log("result", result);
      this.words = result.data;
      this.wordsLoaded = true;
    });
  }

  deleteWord(value: string) {
    if (localStorage.getItem('BearerToken') == null) {
      // Need to log in
      console.log("Not Logged In");
    } else {
      this.$axios.delete('/wordlist/DeleteWord', {
        params: {
          word: value,
        },
        headers: {
          'Content-Type': 'application/json',
          'Authorization': 'Bearer ' + localStorage.getItem('BearerToken')
        },
      }).then(result => {
        console.log("result", result);
        return result;
      });
      this.wordsLoaded = false
      this.words = [];
      this.getWords();
      this.getWords();
    }
  }

  localLoginState: boolean = false

  get loginState() {
    this.loginState = true;
    return this.localLoginState
  }

  set loginState(value) {
    this.$axios.get('/token/ValidToken', {
      headers: {
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + localStorage.getItem('BearerToken')
      },
    }).then(result => {
      console.log("result ", result.data);
      this.localLoginState = result.data;
    });
  }

  @Watch('search')
  updateSearch(){
    this.wordsLoaded = false
    this.words = [];
    this.getWords();
  }
}
</script>
