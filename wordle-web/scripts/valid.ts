import { WordsService } from "./wordsService";
export class validWord{
    static validwords: string [] = WordsService.getWords();
    public static givehints(word: string){
        let  listwords = [] ;
        for(let i in this.validwords){
            let possiblvalid : Boolean=true;
            for(let j=0;j<i.length && possiblvalid;j++){
            if(i[j]!=word[j]){
                if(word[j]!='?'){
                possiblvalid= false;
                }}
            if(possiblvalid){
                listwords.push(i); }}}
        return listwords;
    }

}