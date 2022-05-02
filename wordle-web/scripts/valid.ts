import { WordsService } from "./wordsService";
export class ValidWord{

    static validwords: string [] = WordsService.getWords();
     count:number=0;
     
    public static givehints(word: string){
        let  listwords = [] ;
        
        for(let oneword in this.validwords){
            let possiblvalid : Boolean=true;
            for(let j=0;j<oneword.length && possiblvalid;j++){
            if(oneword[j]!=word[j]){
                if(word[j]!='?'){
                possiblvalid= false;
                }}
            if(possiblvalid){
                listwords.push(oneword);
            
             }}

            }
        return listwords;
    }

}