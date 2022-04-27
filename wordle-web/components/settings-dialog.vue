<template>
  <div>
    <v-btn icon @click="toggleDialog">
      <v-icon> mdi-cog </v-icon>
    </v-btn>

    <v-dialog v-model="dialog" width="450">
      <v-card>
        <v-container>
          <v-card-title> Settings </v-card-title>

          <v-card-text>
            <v-menu offset-y>
              <template #activator="{ on, attrs }">
                <v-btn color="primary" dark v-bind="attrs" v-on="on">
                  Pick Theme
                </v-btn>
              </template>
              <v-list>
                <v-list-item-group>
                  <v-list-item @click="turnOnTheLights">
                    <v-list-item-title> Light Mode </v-list-item-title>
                  </v-list-item>
                  <v-list-item @click="turnOffTheLights">
                    <v-list-item-title> Dark Mode </v-list-item-title>
                  </v-list-item>
                </v-list-item-group>
              </v-list>
            </v-menu>

            <v-menu offset-y>
              <template #activator="{ on, attrs }">
                <v-btn color="primary" dark v-bind="attrs" v-on="on">
                  Pick A Color
                </v-btn>
              </template>
              <v-list>
                <v-list-item-group>
                  <v-list-item @click="purpleTheme">
                    <v-list-item-title> Purple </v-list-item-title>
                  </v-list-item>
                  <v-list-item @click="fallTheme">
                    <v-list-item-title> Fall </v-list-item-title>
                  </v-list-item>
                  <v-list-item @click="graphiteTheme">
                    <v-list-item-title> Graphite </v-list-item-title>
                  </v-list-item>
                </v-list-item-group>
              </v-list>
            </v-menu>
          </v-card-text>
        </v-container>
      </v-card>
    </v-dialog>
  </div>
</template>

<script lang="ts">
import { Vue, Component } from 'vue-property-decorator'
import { colors } from 'vuetify/lib'

@Component({})
export default class SettingsDialog extends Vue {
  dialog = false

  toggleDialog() {
    this.dialog = !this.dialog
  }

  turnOnTheLights() {
    this.$vuetify.theme.dark = false
  }

  turnOffTheLights() { 
    this.$vuetify.theme.dark = true
  }

  purpleTheme() {
    const purpleTheme = {
      primary: colors.deepPurple,
      accent: colors.purple.accent3,
      secondary: colors.purple,
      info: '#03A9F4',
      warning: colors.pink.accent1,
      error: colors.pink.accent3,
      success: colors.deepPurple.lighten4,
    }

    this.$vuetify.theme.themes.dark = purpleTheme
    this.$vuetify.theme.themes.light = purpleTheme
  }

  fallTheme() {
    const fallTheme = {
      primary: colors.brown,
      accent: colors.deepOrange.accent3,
      secondary: colors.deepOrange,
      info: '#FFEB3B',
      warning: colors.orange.accent1,
      error: colors.orange.accent3,
      success: colors.brown.lighten4,
    }

    this.$vuetify.theme.themes.dark = fallTheme
    this.$vuetify.theme.themes.light = fallTheme
  }

  graphiteTheme() {
    const graphiteTheme = {
      primary: colors.grey.darken3,
      accent: colors.grey.lighten3,
      secondary: colors.grey,
      info: '#78909C',
      warning: colors.blueGrey.lighten3,
      error: colors.blueGrey.lighten1,
      success: colors.grey.lighten1,
    }

    this.$vuetify.theme.themes.dark = graphiteTheme
    this.$vuetify.theme.themes.light = graphiteTheme
  }
}
</script>
