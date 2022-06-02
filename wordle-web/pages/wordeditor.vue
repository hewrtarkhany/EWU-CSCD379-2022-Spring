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
<template >
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
import{ Vue, Component }from 'vue-property-decorator';
import axios from 'axios';
import { Word } from '~/scripts/word';

@Component
export default class WordEditor extends Vue{
  word : Word= new Word()
  words: any = []

  deleted:boolean=false
  search:string=''


addWord=async ()=>{

await axios.post(
  '/api/DateWord/',
  {
    word: this.word,
  },
  {
    headers: {
      "x-access-token": "token-value",

    },
  }
);
}

// getting  with error handling  second get 
 getWord=async()=> {
  try {
    // arbetrory api end point 
    const { data, status } = await axios.get('/api/DateWord',
      {
        headers: {
          Accept: 'application/json',
        },
      },
    );

    console.log(JSON.stringify(data, null, 4));

    console.log('response status is: ', status);

    return data;

  } catch (error) {
    if (axios.isAxiosError(error)) {
      console.log('error message: ', error.message);
      return error.message;
    } else {
      console.log('unexpected error: ', error);
      return 'An unexpected error occurred';
    }
  }
}


 deleteWord=async ()=>{
        await axios.delete(`/api/DateWord/${0}`)// arbitrary id till we know what is gonna 
             .then(response => {
               this.rows[response.data]
             });

    
}
// either using the top get or this one debating on this
getWords=()=> {
    this.$axios.get('/DateWord/words').then((response) => {// words is arbitrary till we know what's in the backend
      this.words = response.data
    })
  }

    rows: any=[ ]
    headers: any= [
      {
        text: 'Words',
        value: this.rows[0],
        align: 'start',
        sortable: true ,
        filterable: true,
        groupable: true,
        delete:true,
        divider: true,
        filter: (value: any, search: string, item: any) => true,
        sort: (a: any, b: any) =>'   '
      },
      { text: 'Delete', value: this.rows[1]  },
      { text: 'Add', value: this.rows[2] } ,
      {text: 'Common',value: this.rows[3]}
    ]  
  }

</script>