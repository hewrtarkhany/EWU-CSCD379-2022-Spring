<template>
    <v-card class=" ma-5 py-1" max-width="600px" flat>
        <v-container>
            <v-card-title > Day Stats for {{date}}
                <v-card-text>
                    <v-row>
                        <v-col>
                            Play:
                        </v-col>
                        <v-col>
                         Attempt Avg:
                        </v-col>
                        <v-col>
                            Time Avg:
                        </v-col>
                    </v-row>
                    <v-row>
                        <v-col>
                            {{stats}}
                        </v-col>
                        <v-col>
                            {{stats}}
                        </v-col>
                        <v-col>
                            {{stats}}
                        </v-col>
                    </v-row>
                </v-card-text>
            </v-card-title>
        </v-container>

    </v-card>
</template>
<script lang="ts">
import { Component,Prop,Vue } from "vue-property-decorator";
@Component ({components:{}})
export default class DayData extends Vue{
    @Prop({required: true})
    stats =null;
}
</script>