import { Injectable } from '@angular/core'
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Authors } from '../app/interfaces';
import { ResponseApi } from '../app/interfaces';
import { Books } from '../app/interfaces';
import { Categories } from '../app/interfaces';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': 'library-token'
  })
}

@Injectable()

export class DataService {
  constructor(private http: HttpClient) { }

  public getAllAuthors(): Observable<Authors[]> {
    return this.http.get<Authors[]>("/api/Author/GetAuthors")
  }

  public createAuthor(author: Authors): Observable<ResponseApi> {
    return this.http.post<ResponseApi>("/api/Author/CreateAuthor", author, httpOptions);
  }

  public getAllBooks(): Observable<Books[]> {
    return this.http.get<Books[]>("/api/Book/GetBooks")
  }

  public getAllCategories(): Observable<Categories[]> {
    return this.http.get<Categories[]>("/api/Category/GetCategories")
  }
}
