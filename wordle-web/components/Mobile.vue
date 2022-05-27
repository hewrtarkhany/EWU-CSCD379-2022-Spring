<template>
    <v-container fluid>
        <v-row justify="center">
            <v-col class="ma-0 pa-0">
                <v-card class="d-flex justify-center" color="transparent" flat>
                    <v-btn v-if="!display" x-small block :disabled="disable" @click="showDisplay(true)">
                    </v-btn>
                </v-card>

            </v-col>
        </v-row>
    </v-container>

</template>

<script lang="ts">
import {Component,Prop,Vue} from 'vue-property-decorator'
@Component
export default class Mobile extends Vue{
    @Prop({ required: true })
  candidatesArray!: string[]

  @Prop({ required: true })
  display!: boolean

  @Prop({ required: true })
  disable!: boolean

  emit(c: string) {
    this.$emit('fill-word', c)
    this.showDisplay(true)
  }

  showDisplay(show: boolean) {
    this.$emit('update:display', show)
  }

  mounted() {
    this.showDisplay(false)
  }
}

</script>