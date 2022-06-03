import axios from 'axios'

class WordleJwt {
  iss: string = ''
  sub: string = ''
  aud: string = ''
  exp: number = 0
  random: number = 0
  jti: string = ''
  userId: string = ''
  'http://schemas.microsoft.com/ws/2008/06/identity/claims/role': string
  'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress': string
  'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name': string

  get stuff(): string {
    return 'Stuff'
  }

  public get roles() {
    console.log(
      'test: ' +
        this['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']
    )
    return this[
      'http://schemas.microsoft.com/ws/2008/06/identity/claims/role'
    ].split(',')
  }
}

export const getJwt = async (): Promise<WordleJwt> => {
  const response = await axios.get('/api/jwt')
  return response.data
}

export class Jwt {
  private static _token: string = ''
  private static _content: WordleJwt

  static getToken(): string {
    return Jwt._token
  }

  static setToken(token: string) {
    const parts = token.split('.')
    if (parts.length === 3) {
      Jwt._token = token
      axios.defaults.headers.common.Authorization = `Bearer ${token}`
      const jsonObject = JSON.parse(atob(parts[1]))
      Jwt._content = Object.assign(new WordleJwt(), jsonObject)
    }
  }

  static get content(): WordleJwt {
    return Jwt._content
  }
}
