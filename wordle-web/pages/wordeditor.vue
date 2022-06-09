<template>
  <div id="app">
    <v-app id="inspire">
      <v-card>
        <v-card-title>
          <v-text-field
            v-model="search"
            append-icon="mdi-magnify"
            label="Search"
            single-line
            rounded
            background-color="blue-grey lighten-2"
            hide-details
          >
            <v-btn>hit</v-btn>
          </v-text-field>

        </v-card-title>
        <template>
          <v-data-table
            :headers="headers"
            :items="rows"
            :search="search"
            item-key="name"
          >
          </v-data-table>
        </template>
      </v-card>
    </v-app>
  </div>

</template>
<script lang="ts">
import {Vue, Component} from 'vue-property-decorator';
import {Word} from '~/scripts/word';

@Component
export default class WordEditor extends Vue {
  pageNumber: number = 0;
  pageSize: number = 10;
  word: Word = new Word()
  words: any = []
  age: number = 0
  deleted: boolean = false
  search: string = ''

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

  async addWord(value:string) {
    if (localStorage.getItem('BearerToken') == null) {
      // Need to log in
    } else {
      const {data, status} = await this.$axios.post('/wordlist/AddWord', {
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
      console.log(data);
      console.log('response status is: ', status);
      await this.getWords();
      return data;
    }
  }

  async getWords() {
    console.log("getting");
    const {data, status} = await this.$axios.get('/wordlist/getwordlist', {
      params: {
        pageNumber: this.pageNumber,
        pageSize: this.pageSize
      }
    }).then(result => {
      console.log("result", result);
      return result;
    });
    console.log(data);
    console.log('response status is: ', status);
    return data;
  }

  async deleteWord(value:string) {
    if(localStorage.getItem('BearerToken') == null){
      // Need to log in
    } else {
      const {data, status} = await this.$axios.delete('/wordlist/DeleteWord', {
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
      console.log(data);
      console.log('response status is: ', status);
      await this.getWords();
      return data;
    }
  }

  rows: any = []
  headers: any = [
    {
      text: 'Words',
      value: this.rows[0],
      align: 'start',
      sortable: true,
      filterable: true,
      groupable: true,
      delete: true,
      divider: true,
      filter: (value: any, search: string, item: any) => true,
      sort: (a: any, b: any) => '   '
    },
    {text: 'Delete', value: this.rows[2]},
    {text: 'Add', value: this.rows[3]},
    {text: 'Common', value: this.rows[1]}
  ]
}
</script>
