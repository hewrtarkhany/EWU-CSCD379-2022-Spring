export class StopClock{
    start: number=0;
    now: number=0;
    isTiming: boolean=false;
    UpdateIt: any;

    Start(): void{
        this.start=Date.now()
        this.now=0;
        this.UpdateIt=setInterval(()=>{
            this.now= Date.now()-this.start;
        });
        this.isTiming=true;
    }
    
    Stop ():void{
        clearInterval(this.UpdateIt)
        this.isTiming=false;

    }
    showTime(){
        return (new Date (this.now)).toUTCString().match(/(\d\d:\d\d:\d\d)/);
    }

}