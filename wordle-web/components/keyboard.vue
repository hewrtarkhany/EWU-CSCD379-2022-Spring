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

      <v-btn
        :disabled="wordleGame.gameOver"
        @click="validWords" 
        color="accent"
      >
        Available Words
      </v-btn>

      <v-btn
        :disabled="wordleGame.gameOver"
        @click="removeLetter"
        color="secondary"
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

  validWords(){
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
