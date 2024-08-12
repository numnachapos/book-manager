import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BiographyBook, Book, CryptoCurrencyBook, InvestmentBook } from 'src/app/interfaces/book';
import { BookType } from 'src/app/interfaces/book-type.enum';
import { BookService } from 'src/app/services/book.service';

@Component({
  selector: 'app-delete-book',
  templateUrl: './delete-book.component.html',
  styleUrls: ['./delete-book.component.css']
})
export class DeleteBookComponent implements OnInit{

  book: any;
  
  constructor(private route: ActivatedRoute, 
    private router: Router,
    private service: BookService) {}

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

  deleteBook(id: number){
    this.service.deleteBook(id).subscribe(() => {
      this.router.navigate(['/books']);
    })
  }
}
