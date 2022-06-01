<template>
  <v-container fluid fill-height justify-center>
    <v-card>
      <v-card-title class="display-3 justify-center">
        last 10 Daily Words
      </v-card-title>
      <v-card-text class="text-center">
          {{words}}
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
export default class DailyStats extends Vue {
  dayStats :any = []
  words :string=''
  playerGuid: string=''

  created() {
    this.retrieveGuid()
    setTimeout(()=>{
        this.getDateWords()

    },2000)
        

    
  
  }
  getDateWords() {
    this.words= '10 Daily Words'
    this.$axios.get('/api/DateWord?playerGuid='+this.playerGuid).then((reponse)=>{
      this.dayStats = reponse.data
    })
  }
   retrieveGuid(){
    
    const guid =localStorage.getItem('playerGuid')
    if(guid==null){
      this.$axios
      .get('/api/Players/ValidatePlyerGuid?pleyerGuid='+guid).then((response)=>{
        this.playerGuid=response.data
      })
    }else{
      this.$axios
      .get('/api/Players/ValidatePlayerGuid?playerGuid='+guid)
      .then((reposnse)=>{
        this.playerGuid= reposnse.data
      })
    }
  }
}
</script>
