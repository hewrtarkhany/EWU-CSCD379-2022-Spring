import {ValidWord} from "./valid"

describe('Get Valid Words', () => {
    test('get one word if word is valid', () => {
      const word = "acorn"; 
        const validWords= ValidWord.givehints(word);

        expect(validWords.length).toBe(1);

        expect(validWords[0]).toBe(word)


   
    })
    test('get one work if it ?', () => {
      const word = "ac???"; 
        const validWords= ValidWord.givehints(word);

        expect(validWords.length).toBe(3);

   
    })
  })