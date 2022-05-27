<script lang="ts">
import { Component,Prop,Vue } from "vue-property-decorator";
@Component ({components:{}})
export default class DayData extends Vue{
    @Prop({required: true})
    stats =null;
}
</script>