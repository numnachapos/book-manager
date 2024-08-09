import { Component, OnInit } from '@angular/core';
import { BookService } from 'src/app/services/book.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { toUTC } from '../../../utils/date-utils';

@Component({
  selector: 'app-update-book',
  templateUrl: './update-book.component.html',
  styleUrls: ['./update-book.component.css']
})
export class UpdateBookComponent implements OnInit {

  book: any;
  updateBookForm: FormGroup = new FormGroup({});

  constructor(private service: BookService,
              private route: ActivatedRoute,
              private router: Router,
              private fb: FormBuilder) { }

  ngOnInit() {
    this.updateBookForm = this.fb.group({
      id: [''],
      title: ['', Validators.required],
      author: ['', Validators.required],
      description: ['', Validators.compose([Validators.required, Validators.minLength(30)])],
      rate: [''],
      dateStart: [''],
      dateRead: [''],
      dateEnd: ['']
    });

    this.service.getBookbyId(this.route.snapshot.params.id).subscribe({
      next: (data) => {
        this.book = data;
        console.log('Book data loaded:', data);

        this.updateBookForm.patchValue({
          id: data.id,
          title: data.title,
          author: data.author,
          description: data.description,
          rate: data.rate,
          dateStart: this.formatDate(data.dateStart),
          dateRead: this.formatDate(data.dateRead),
          dateEnd: this.formatDate(data.dateEnd)
        });
      },
      error: (error) => {
        console.error('Error loading book data:', error);
      }
    });
  }

  formatDate(date: Date | undefined): string {
    if (date) {
      return new Date(date).toISOString().substring(0, 10);
    }
    return '';
  }

  onSubmit() {
    console.log('Form Submitted');
    console.log('Form Valid:', this.updateBookForm.valid);
    console.log('Form Value:', this.updateBookForm.value);
  
    if (this.updateBookForm.valid) {
      const formValue = this.updateBookForm.value;
      console.log('Form Value before conversion:', formValue);
  
      // Check if date fields are valid before converting to UTC
      formValue.dateStart = formValue.dateStart ? toUTC(formValue.dateStart) : null;
      formValue.dateRead = formValue.dateRead ? toUTC(formValue.dateRead) : null;
      formValue.dateEnd = formValue.dateEnd ? toUTC(formValue.dateEnd) : null;
  
      console.log('Form Value after conversion:', formValue);
  
      this.service.updateBook(formValue).subscribe({
        next: (data) => {
          console.log('Update successful', data);
          this.router.navigate(["/books"]);
        },
        error: (error) => {
          console.error('Error updating book', error);
        }
      });
    } else {
      console.error('Form is invalid');
    }
  }
}

