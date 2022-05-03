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

    <v-row align="center" justify="space-around">
      <v-btn :disabled="wordleGame.gameOver" @click="guessWord"> Guess </v-btn>

      <v-dialog v-model="dialog" scrollable max-width="300px">
        <template v-slot:activator="{ on, attrs }">
          <v-btn color="primary" dark v-bind="attrs" v-on="on">
            Valid Words
          </v-btn>
        </template>
        <v-card>
          <v-card-title>Select Word</v-card-title>
     
          <v-divider></v-divider>

        <v-card-text>
          <v-list dense>
            <v-list-item-group v-model="selectedItem" color="primary">



              <v-list-item v-for="(item,index) in validWords" :key="item" @click="pickerIndex = index">

                <v-list-item-content>
                  <v-list-item-title v-text="item " ></v-list-item-title>

                </v-list-item-content>
              </v-list-item>
           



            </v-list-item-group>
          </v-list>
        </v-card-text>
          <v-card-actions>
            <v-btn color="blue darken-1" text @click="dialog = false">
              Close
            </v-btn>
            <v-btn color="blue darken-1" text  @click="enterPickerWord">
              Enter Word
            </v-btn>
            <v-card-text>
                <!--<v-list-item v-for="(item) in counteWords" :key="item">-->
                <v-list-item>
                <v-list-item-content>
                  <v-list-item-title v-text="counteWords " ></v-list-item-title>

                </v-list-item-content>
              </v-list-item>
            </v-card-text>
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
import { ValidWord } from '~/scripts/valid'
import { Word } from '~/scripts/word'

@Component
export default class KeyBoard extends Vue {
  @Prop({ required: true })
  wordleGame!: WordleGame
  dialog: boolean = false
  count: number = 0
 pickerIndex:number=0 ;
 //pickerWord:string="";


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


   enterPickerWord() {
        const word: Word = this.wordleGame.currentWord
        var  rightwords = ValidWord.givehints(word.text)
     for(var i=0;i<5;i++){
    this.wordleGame.currentWord.removeLetter()
     }
     this.dialog=false;
      var pickerWord = rightwords[this.pickerIndex];
      for (var j =0;j<pickerWord.length;j++){
        this.wordleGame.currentWord.addLetter(pickerWord.charAt(j));
      }

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
  created() {}

  get counteWords() {
    const word: Word = this.wordleGame.currentWord
    const s = this.dialog

   var  rightwords = ValidWord.givehints(word.text)
   this.count=0;
   for (var i =0;i<rightwords.length;i++){ 
      this.count++;
   }
    this.count+1;
   return this.count;

  }

  get validWords() {
    const word: Word = this.wordleGame.currentWord
    const s = this.dialog

    return ValidWord.givehints(word.text)
  }

}
</script>