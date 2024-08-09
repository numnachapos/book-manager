import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BookService } from 'src/app/services/book.service';
import { Router } from '@angular/router';
import { toUTC } from '../../../utils/date-utils';

@Component({
  selector: 'app-new-book',
  templateUrl: './new-book.component.html',
  styleUrls: ['./new-book.component.css']
})
export class NewBookComponent implements OnInit {

  addBookForm: FormGroup = new FormGroup({});
  showError: Boolean = false;
  constructor(private service: BookService, private fb: FormBuilder, private router: Router) { }

  ngOnInit() {
    this.addBookForm = this.fb.group({
      id:[Math.floor(Math.random() * 1000)],
      title: [null, Validators.required],
      author: [null, Validators.required],
      description: [null, Validators.compose([Validators.required, Validators.minLength(30)])],
      rate: [null],
      dateStart: [null],
      dateRead: [null],
      dateEnd: [null]
    })
  }

  onSubmit() {
      const formValue = this.addBookForm.value;
      formValue.dateStart = toUTC(formValue.dateStart);
      formValue.dateRead = toUTC(formValue.dateRead);
      formValue.dateEnd = toUTC(formValue.dateEnd);
  
      this.service.addBook(formValue).subscribe({
        next: (data) => {
          console.log(data);
          this.router.navigate(['/books']);
        },
        error: (error) => {
          this.showError = true;
        }
      });
    }
}
