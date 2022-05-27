<template>
  <v-container fluid fill-height justify-center>
    <v-card>
      <v-card-title class="display-3 justify-center">
        Leader's Stats
      </v-card-title>
      <v-card-text class="text-center">
          {{names}}
      </v-card-text>
      <v-card-text>
        <v-simple-table>
            <thead>
              <tr>
                <th> Date </th>
                <th style="text-align:center"> Score </th>
                <th style="text-align:center"> Time</th>
                <th style="text-align:center"> Games </th>
                <th style="text-align:center"> Played </th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="( dayStat,date) in  dayStats" 
              :key="date"
              >
                <td> {{ dayStat.date}}</td>

                <td style="text-align: center" >{{dayStat.score}} </td>
                <td style="text-align: center" >{{dayStat.time}} </td>
                <td style="text-align: center" >{{dayStat.games}} </td>
                <td style="text-align: center" >{{dayStat.played}} </td>

              </tr>
            </tbody>
        </v-simple-table>
      </v-card-text>
      <v-card-actions>
        <v-btn color="green" @click="getData">
          10 Words
        </v-btn>
      </v-card-actions>
    </v-card>

  </v-container>
</template>

<script lang="ts">
import {Component, Vue} from 'vue-property-decorator'

@Component({})
export default class DayData extends Vue {
  dayStats :any = []
  names :string=''

  created() {
  this.getData()
  }
  // creating a response data with player guid number to get the right player
  getData() {
    this.names= '10 Daily Words'
    this.$axios.get('/api/DateWord').then((reponse)=>{
      this.dayStats = reponse.data
    })
  }
}
</script>
