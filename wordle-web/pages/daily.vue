<template>
  <v-container fluid fill-height justify-center>
    <v-card>
      <v-card-title class="display-3 justify-center">
        Leader's Stats
      </v-card-title>
      <v-container v-for="apiData in dayStat" :key="apiData">
        <day-stats :today="apiData"></day-stats>
      </v-container>
    </v-card>
  </v-container>
</template>

<script lang="ts">
import {Component, Vue} from 'vue-property-decorator'
@Component({})
export default class DayData extends Vue {
  dayStat :any = []
  created() {
  this.getData()
  }
  async getData() {
    const response=await this.$axios.get('/api/Recents');
    this.dayStat=response.data;
  }
}
</script>
