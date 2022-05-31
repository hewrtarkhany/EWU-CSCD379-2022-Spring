<template>
  <v-card width="800" height="800">
    <v-container class="overflow-hidden" fluid>
      <v-row justify="center">
        <v-col>
          <!-- <Adsense
            data-ad-client="ca-pub-1431122584842002"
            data-ad-slot="9479195735"
          ></Adsense> -->
          <!-- That doesn't work without a top-level domain, anyway. Here's a fake ad instead -->
            <v-img src="https://media2.giphy.com/media/4CYF5Jb3SVvy2Jd8It/giphy.gif?cid=ecf05e47rdxrw7639wy2yv4ifgx3kkxmw70trthk5ck227hz&rid=giphy.gif&ct=g" />
          
        </v-col>
      </v-row>
    </v-container>
  </v-card>
</template>

<script>
import Vue from 'vue'
import Component from 'vue-class-component'

@Component
export default class PrerollAd extends Vue {}
</script>
