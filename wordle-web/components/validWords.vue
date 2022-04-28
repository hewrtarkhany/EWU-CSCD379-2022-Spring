<template>
  <v-card class="my-5 pa-5">
    
    <v-btn
      :disabled="wordleGame.gameOver"
      class="float-center"
      @click="validWords"
    >
      Valid Words {{validWords}}
    </v-btn>
  </v-card>
</template>

<script lang="ts">
import { Component, Vue, Prop } from 'vue-property-decorator'
import { WordleGame } from '~/scripts/wordleGame'
import {ValidWord} from '~/scripts/valid'
import {Word} from '~/scripts/word'


@Component
export default class KeyBoard extends Vue {
  @Prop({ required: true })
  wordleGame!: WordleGame

  get validWords(){
       const word: Word = this.wordleGame.currentWord;
       if(word.length === 5){
           let stringWord: string="";
           for(let i=0;i<5;i++){
               stringWord += word.letters[i].char;
           }
           ValidWord.givehints(stringWord);
           }
       return 0;
  }
}
</script>