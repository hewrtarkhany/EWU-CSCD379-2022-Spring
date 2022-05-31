<template>
  <v-container >
    <v-row justify="center">
      <v-col cols="12">
        <v-card flat color="transparent">
          <v-card-title class="justify-center">
            <h1>How it Works!</h1>
          </v-card-title>
        </v-card>
      </v-col>

      <v-col cols="10">
        <v-card>
          <div class="d-flex align-center">
            <v-card-text decoration>
              <ul>
                <li>
                  the game is based on choosing the right word
                </li>
                <li>
                 once you start the game, you get to right letters on the keyboard, and guess it.
                </li>
                <li>
                  the guess button will give you hints and below that, you get to see the words are available.
                </li>
                <li>
                  you will only have 6 tries to get the guess right.
                </li>
                <li>
                  if you get the guess right then your name will go on leader board
                </li>
                <li>
                  then you can review the stats based on plays 
                </li>

              </ul>
            </v-card-text>
          </div>
        </v-card>
      </v-col>

      <v-col cols="10">
        <v-card flat color="transparent">
          <v-card-title class="justify-center">
            <h1>Instructions</h1>
          </v-card-title>

        </v-card>
      </v-col>

      <v-col cols="10">
        <v-card>
          <div class="d-flex align-center">
            <v-container fluid >
              <v-card flat>
                <v-card-title class="justify-left"> Step by Step </v-card-title>

                <v-card-text>
                  <ui>
                    <li>
                      in the right side choose the Play from( home, play, daily stats, instruction,leaderboard, settings)
                    </li>
                    <li>

                    </li>
                  </ui>


                </v-card-text>
                <v-card-actions>
                  <v-btn button nuxt to="/game" color="primary"> Play </v-btn>
                </v-card-actions>
              </v-card>
            </v-container>
          </div>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script lang="ts">
import Vue from 'vue'
import Component from 'vue-class-component'

@Component
export default class InstructionPage extends Vue {}
</script>

