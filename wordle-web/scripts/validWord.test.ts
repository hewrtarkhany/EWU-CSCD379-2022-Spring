import {ValidWord} from "./valid"

describe('Get Valid Words', () => {
    test('get one word if word is valid', () => {
      const word = "acorn"; const num=0;
        const validWords= ValidWord.givehints(word,num);

        expect(validWords.length).toBe(1);

        expect(validWords[0]).toBe(word)
        expect(validWords.length=num).toBe(3)


   
    })
    test('get one work if it ?', () => {
      const word = "ac???"; const num =0;
        const validWords= ValidWord.givehints(word, num);

        expect(validWords.length).toBe(3);
        expect(validWords.length==num).toBe(3);

   
    })
  })