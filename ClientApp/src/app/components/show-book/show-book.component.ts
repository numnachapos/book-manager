import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AnyBook, BiographyBook, Book, CryptoCurrencyBook, InvestmentBook } from 'src/app/interfaces/book';
import { BookType } from 'src/app/interfaces/book-type.enum';
import { BookService } from 'src/app/services/book.service';

@Component({
  selector: 'app-show-book',
  templateUrl: './show-book.component.html',
  styleUrls: ['./show-book.component.css']
})
export class ShowBookComponent implements OnInit{
  book : AnyBook = {} as AnyBook;
  
  constructor(private service: BookService, private route: ActivatedRoute){}

  ngOnInit() {
    this.service.getBookbyId(this.route.snapshot.params.id).subscribe(data => {
      this.book = data;
    })
  }

  isBiographyBook(book: Book): book is BiographyBook {
    return book.bookType === BookType.BiographyBook;
  }

  isCryptoCurrencyBook(book: Book): book is CryptoCurrencyBook {
    return book.bookType === BookType.CryptoCurrencyBook;
  }

  isInvestmentBook(book: Book): book is InvestmentBook {
    return book.bookType === BookType.InvestmentBook;
  }
}
