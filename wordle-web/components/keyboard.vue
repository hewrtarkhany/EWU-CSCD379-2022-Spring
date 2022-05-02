<template>
  <v-card class="my-5 pa-5">
    <v-row v-for="(charRow, i) in chars" :key="i" no-gutters justify="center">
      <v-col v-for="char in charRow" :key="char" cols="1">
        <v-container class="text-center">
          <v-btn 
            :color="letterColor(char)"
            :elevation="hover ? 24 : 6"
            :disabled="wordleGame.gameOver"
            @click="setLetter(char)"
          >
            {{ char }}
          </v-btn>
        </v-container>
      </v-col>
    </v-row>

    <v-row
    align="center"
    justify="space-around"
  >
    <v-btn
      :disabled="wordleGame.gameOver"
      @click="guessWord" 
    >
      Guess
    </v-btn>

 <v-dialog
        v-model="dialog"
        scrollable
        max-width="250px"
      >
        <template v-slot:activator="{ on, attrs }">
          <v-btn
            color="primary"
            dark
            v-bind="attrs"
            :disabled="wordleGame.gameOver"
            v-on="on"
          >
            Valid Words
          </v-btn>
          
        </template>

        <v-card>
          <v-card-title>Available Words</v-card-title>
          <v-divider></v-divider>
          <v-card-text style="height: 200px;"
          >
          </v-card-text>

          <v-list three-line>
            <template v-for="(item) in validWords">
         <v-list-item 
          :key="item">
          <v-list-item-content>
            <v-list-item-title >{{item}}</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </template>

          </v-list>

          <v-divider></v-divider>
          <v-card-actions>
            <v-btn
              color="blue darken-1"
              text
              @click="dialog = false"
            >
              Close
            </v-btn>
          
          </v-card-actions>
        </v-card>

  </v-dialog>

    <v-btn
      :disabled="wordleGame.gameOver"
      @click="removeLetter"
      color="primary"
    >
      <v-icon>mdi-backspace</v-icon>
    </v-btn>

    </v-row>

  </v-card>
</template>

<script lang="ts">
import { Component, Vue, Prop } from 'vue-property-decorator'
import { Letter, LetterStatus } from '~/scripts/letter'
import { WordleGame } from '~/scripts/wordleGame'
import {ValidWord} from '~/scripts/valid'
import {Word} from '~/scripts/word'

@Component
export default class KeyBoard extends Vue {

  @Prop({ required: true })
  wordleGame!: WordleGame
  dialog:boolean=false;

  chars = [
    ['q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p'],
    ['a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l'],
    ['z', 'x', 'c', 'v', 'b', 'n', 'm', '?'],
  ]
  setLetter(char: string) {
    this.wordleGame.currentWord.addLetter(char)
  }
  removeLetter() {
    this.wordleGame.currentWord.removeLetter()
  }
  guessWord() {
    if (
      this.wordleGame.currentWord.length ===
      this.wordleGame.currentWord.maxLetters
    ) {
      this.wordleGame.submitWord()
    }
  }
  letterColor(char: string): string {
    if (this.wordleGame.correctChars.includes(char)) {
      return Letter.getColorCode(LetterStatus.Correct)
    }
    if (this.wordleGame.wrongPlaceChars.includes(char)) {
      return Letter.getColorCode(LetterStatus.WrongPlace)
    }
    if (this.wordleGame.wrongChars.includes(char)) {
      return Letter.getColorCode(LetterStatus.Wrong)
    }
    return Letter.getColorCode(LetterStatus.Unknown)
  }  
  created(){

  }
  
  
   get validWords(){

       const word: Word = this.wordleGame.currentWord;
        const s = this.dialog;

          return ValidWord.givehints(word.text);      
  }

}
</script>