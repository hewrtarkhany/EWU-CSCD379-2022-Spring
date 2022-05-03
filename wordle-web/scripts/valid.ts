import { WordsService } from './wordsService'
export class ValidWord {

  static validwords: string[] = WordsService.getWords()

  public static givehints(word: string ,count: number) {
    
    let listwords = []

    for (let oneword of this.validwords) {
      let possiblvalid: Boolean = true
      for (let j = 0; j < oneword.length; j++) {
        if (oneword[j] != word[j]) {
          if (word[j] == '?') {
            continue
          }
          possiblvalid = false
          break
        }
      }

      if (possiblvalid) {
        listwords.push(oneword)
        count ++;
      }
    }

    return listwords
  }
}
