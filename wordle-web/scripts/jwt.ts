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

  public get roles() {
    return this[
      'http://schemas.microsoft.com/ws/2008/06/identity/claims/role'
    ].split(',')
  }

  public get email() {
    return this[
      'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress'
    ]
  }

  public get name() {
    return this[
      'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'
    ]
  }
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
    } else {
      throw new Error('Invalid token')
    }
  }

  static get content(): WordleJwt {
    return Jwt._content
  }
}
