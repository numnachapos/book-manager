import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Book } from '../interfaces/book';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BookService {
  private _baseURL: string = environment.apiUrl + "/Books";

  constructor(private http: HttpClient) { }

  getAllBooks() {
    return this.http.get<Book[]>(this._baseURL + "/GetBooks");
  }

  addBook(book: Book) {
    return this.http.post(this._baseURL+ "/AddBook", book);
  }
}
