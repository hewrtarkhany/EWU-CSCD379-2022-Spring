<template>
  <v-container fluid fill-height justify-center>
    <v-tooltip bottom>
      <template #activator="{ on, attrs }">
        <v-btn color="primary" nuxt to="/" fab v-bind="attrs" v-on="on">
          <v-icon> mdi-home </v-icon>
        </v-btn>
      </template>
      <span> Go Home </span>
    </v-tooltip>

    <v-card-text class="text-h1 font-weight-black text-center">
      About the Game
    </v-card-text>

    <v-card-text class="text-h6 font-weight-black">
      This is a single-page web-application built as a school project to learn
      how to effectively use Vuetify, Nuxt, GitHub, and Azure. In particular,
      over the course of 10 weeks, we will build several things, but the first
      is a Wordle-inspired game. Meg is really great and everyone likes how she
      gives extra-credit for people saying "Meg is really great."
    </v-card-text>
  </v-container>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'

@Component({ components: {} })
export default class About extends Vue {
  name: string = 'About'
}
</script>