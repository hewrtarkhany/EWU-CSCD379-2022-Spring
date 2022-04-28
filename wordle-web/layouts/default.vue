<template>
  <v-app>
    <v-app-bar fixed app>
      <router-link to="/" class="text-h4 font-weight-black no-decoration">
        <v-icon> mdi-gamepad-variant </v-icon> Burbank & Tarkhany Wordle
      </router-link>
      <v-spacer />
      <settings-dialog />
      
      
    <v-app-bar-nav-icon @click.stop="drawer = !drawer"></v-app-bar-nav-icon>
      
    </v-app-bar>

    <v-navigation-drawer
      v-model="drawer"
      absolute
      right
      temporary
    >
      <v-list
        nav
        dense
      >
        <v-list-item-group
          v-model="group"
          active-class="white--text text--accent-4"
        >
        <router-link to="/about" class="text-h4 font-weight-black no-decoration">
          <v-list-item>
            <v-list-item-title>About</v-list-item-title>
          </v-list-item>
        </router-link>

        </v-list-item-group>
      </v-list>
    </v-navigation-drawer>


    <v-main>
      <v-container>
        <Nuxt />
      </v-container>
    </v-main>
    <v-footer app>
      <span>&copy; {{ new Date().getFullYear() }}</span>
    </v-footer>
  </v-app>
</template>


<script lang="ts">

import { Component, Vue } from 'vue-property-decorator'
import About from '~/pages/about.vue'

@Component({ components: { About } })
export default class Default extends Vue {
      drawer= false
      group= null
  }
</script>


<style>
.no-decoration {
  text-decoration: none;
}
</style>