import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AnyBook, BiographyBook, Book, CryptoCurrencyBook, InvestmentBook } from 'src/app/interfaces/book';
import { BookType } from 'src/app/interfaces/book-type.enum';
import { BookService } from 'src/app/services/book.service';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent implements OnInit {
  books: AnyBook[] = [];
  bookTypes: string[] = [];
  selectedBookType: BookType | null = null;
  isBiographyBookType: boolean = false;
  isCryptoCurrencyBookType: boolean = false;
  isInvestmentBookType: boolean = false;

  constructor(private service: BookService, private router: Router) { }

  ngOnInit() {
    this.service.getBookTypes().subscribe({
      next: (types) => {
        this.bookTypes = this.getEnumKeys(BookType);
      },
      error: (error) => console.error('Error fetching book types:', error)
    });
  }

  getEnumKeys(enumObj: any): string[] {
    return Object.keys(enumObj).filter(key => isNaN(Number(key)));
  }

  onBookTypeChange(): void {
    console.log('Selected book type:', this.selectedBookType);

    const selectedBookTypeEnum = BookType[this.selectedBookType as unknown as keyof typeof BookType];
    this.isBiographyBookType = selectedBookTypeEnum === BookType.BiographyBook;
    this.isCryptoCurrencyBookType = selectedBookTypeEnum === BookType.CryptoCurrencyBook;
    this.isInvestmentBookType = selectedBookTypeEnum === BookType.InvestmentBook;

  if (this.selectedBookType !== null) {
      this.service.getBooksByType(this.selectedBookType.toString()).subscribe({
        next: (books) => {
          this.books = books;
          this.books.forEach(book => {
            console.log('Book type name:', this.getBookTypeName(book.bookType));
          });
          console.log('Books:', this.books);
        },
        error: (error) => console.error('Error fetching books:', error)
      });
    } else {
      this.books = [];
    }
  }

  showBook(id: number) {
    this.router.navigate(['/show-book/' + id]);
  }

  updateBook(id: number){
    this.router.navigate(['/update-book/'+id]);
  }

  deleteBook(id: number){
    this.router.navigate(['/delete-book/'+id]);
  }

  isBiographyBook(book: AnyBook): book is BiographyBook {
    return book.bookType === BookType.BiographyBook;
  }

  isCryptoCurrencyBook(book: AnyBook): book is CryptoCurrencyBook {
      return book.bookType === BookType.CryptoCurrencyBook;
  }

  isInvestmentBook(book: AnyBook): book is InvestmentBook {
      return book.bookType === BookType.InvestmentBook;
  }
  
  getBookTypeName(bookType: number): string {
    switch (bookType) {
      case BookType.BiographyBook:
        return 'BiographyBook';
      case BookType.CryptoCurrencyBook:
        return 'CryptoCurrencyBook';
      case BookType.InvestmentBook:
        return 'InvestmentBook';
      default:
        return 'Unknown';
    }
  }
}
