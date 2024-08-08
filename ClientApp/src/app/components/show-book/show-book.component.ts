import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Book } from 'src/app/interfaces/book';
import { BookService } from 'src/app/services/book.service';

@Component({
  selector: 'app-show-book',
  templateUrl: './show-book.component.html',
  styleUrls: ['./show-book.component.css']
})
export class ShowBookComponent implements OnInit{
  book : Book = {} as Book;
  
  constructor(private service: BookService, private route: ActivatedRoute){}

  ngOnInit() {
    this.service.getBookbyId(this.route.snapshot.params.id).subscribe(data => {
      this.book = data;
    })
  }
}
