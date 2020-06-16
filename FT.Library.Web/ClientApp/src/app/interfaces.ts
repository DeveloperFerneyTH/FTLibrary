export interface Authors {
  ID: number,
  FirstName: string,
  LastName: string,
  BirthDay: string
}

export interface Books {
  ID: number,
  Name: string,
  ISBN: string,
  Category_ID: number,
  Category_Name: string,
  Author_ID: number,
  Author_Name: string
}

export interface Categories {
  ID: number,
  Name: string,
  Description: string
}

export interface ResponseApi {
  ExecuteSuccess: boolean,
  Message: string
}
