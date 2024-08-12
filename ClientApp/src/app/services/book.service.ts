import { HttpClient, HttpErrorResponse, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AnyBook, Book } from '../interfaces/book';
import { environment } from '../../environments/environment';
import { catchError, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BookService {
  private _baseURL: string = environment.apiUrl + "/Books";

  constructor(private http: HttpClient) { }

  getBooksByType(bookType: string): Observable<AnyBook[]> {
    let params = new HttpParams().set('bookType', bookType);
    return this.http.get<AnyBook[]>(`${this._baseURL}/GetBooksByType`, { params }).pipe(
      catchError((error: HttpErrorResponse) => {
        console.error('Error fetching books by type:', error.message);
        return throwError(() => new Error('Failed to fetch books by type'));
      })
    );
  }

  getBookTypes(): Observable<string[]> {
    return this.http.get<string[]>(`${this._baseURL}/types`).pipe(
      catchError((error) => {
        console.error('Error loading book types:', error.message);
        return throwError(() => new Error('Failed to fetch book types'));
      })
    );
  }

  addBook(book: Book) {
    return this.http.post(this._baseURL+ "/AddBook", book);
  }

  getBookbyId(id: number){
    return this.http.get<Book>(this._baseURL + "/GetSingleBook/"+id);
  }

  updateBook(book: AnyBook){
    console.log('Book data:', book);
    return this.http.put(this._baseURL + "/UpdateBook/"+book.id, book);
  }

  deleteBook(id: number){
    return this.http.delete(this._baseURL + "/DeleteBook/"+id);
  }
}
