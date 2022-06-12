export abstract class WordsService {
  static getRandomWord(): string {
    return this.#words[Math.floor(Math.random() * this.#words.length)]
  }

  static async validWords(guess: string): Promise<string[]> {
    this.#words = await this.getWords();
    const candWords: string[] = []
    if (guess.length === 0) return candWords

    const emptySpaces = 5 - guess.length
    if (emptySpaces > 0) {
      for (let i = 0; i < emptySpaces; i++) {
        guess += '.'
      }
    }
    while (guess.includes('?')) {
      guess = guess.replace('?', '.')
    }
    const re = new RegExp(guess, '')

    let firstNonQChar: string = ''
    let charPosition: number = 0

    for (let i = 0; i < guess.length; i++) {
      if (guess.charAt(i) !== '?') {
        firstNonQChar = guess.charAt(i)
        charPosition = i
        break
      }
    }

    for (let i = 0; i < WordsService.#words.length; i++) {
      if (WordsService.#words[i].match(re)) {
        candWords.push(WordsService.#words[i])
      }
      if (
        candWords.length > 0 &&
        firstNonQChar !== guess.charAt(charPosition)
      ) {
        break // for early stopping once we've gone past first char match
      }
    }
    return candWords
  }

  // From: https://github.com/kashapov/react-testing-projects/blob/master/random-word-server/five-letter-words.json
  // @ts-ignore
  static #words: string[] = [];

  static async getWords(): Promise<string[]> {
    if (this.#words === []) {
      return this.#words
    } else {
      const response = await fetch('https://api-wordle.azurewebsites.net/wordlist/GetCommonWordList')
      const words = await response.json()
      this.#words = words
      return this.#words
    }
  }

}
