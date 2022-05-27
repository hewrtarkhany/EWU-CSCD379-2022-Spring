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
              info about the game
              <v-spacer />
              <v-card-text> more isntruction </v-card-text>
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
                <v-card-title class="justify-left"> title </v-card-title>

                <v-card-text>
                  some stuff
                  <v-spacer />
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

<script>
import Vue from 'vue'
import Component from 'vue-class-component'

@Component
export default class InstructionPage extends Vue {}
</script>

