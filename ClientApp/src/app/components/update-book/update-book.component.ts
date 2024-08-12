import { Component, OnInit } from '@angular/core';
import { BookService } from 'src/app/services/book.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { toUTC, removeUndefinedProperties } from '../../../utils/data-utils';
import { BookType } from 'src/app/interfaces/book-type.enum';
import { BiographyBook, CryptoCurrencyBook, InvestmentBook } from 'src/app/interfaces/book';
import { v4 as uuidv4 } from 'uuid';

@Component({
  selector: 'app-update-book',
  templateUrl: './update-book.component.html',
  styleUrls: ['./update-book.component.css']
})
export class UpdateBookComponent implements OnInit {

  book: any;
  updateBookForm: FormGroup = new FormGroup({});
  selectedBookType: BookType | null = null; 
  isBiographyBookType: boolean = false;
  isCryptoCurrencyBookType: boolean = false;
  isInvestmentBookType: boolean = false;

  constructor(private service: BookService,
              private route: ActivatedRoute,
              private router: Router,
              private fb: FormBuilder) { }

  ngOnInit() {
    this.updateBookForm = this.fb.group({
      id: [''],
      bookType: [''],
      title: ['', Validators.required],
      author: ['', Validators.required],
      description: ['', Validators.compose([Validators.required, Validators.minLength(30)])],
      rate: [''],
      dateStart: [''],
      dateRead: [''],
      dateEnd: [''],
      subject: [''],
      timePeriod: [''],
      currencyType: [''],
      marketTrend: [''],
      investmentType: [''],
      strategy: ['']
    });

    this.service.getBookbyId(this.route.snapshot.params.id).subscribe({
      next: (data) => {
        this.book = data;
        this.selectedBookType = data.bookType;
        this.checkBookType();
        console.log('Book data loaded:', data);

        this.updateBookForm.patchValue({
          id: data.id,
          bookType: data.bookType,
          title: data.title,
          author: data.author,
          description: data.description,
          rate: data.rate,
          dateStart: this.formatDate(data.dateStart),
          dateRead: this.formatDate(data.dateRead),
          dateEnd: this.formatDate(data.dateEnd),
          subject: (data as BiographyBook).subject,
          timePeriod: (data as BiographyBook).timePeriod,
          currencyType: (data as CryptoCurrencyBook).currencyType,
          marketTrend: (data as CryptoCurrencyBook).marketTrend,
          investmentType: (data as InvestmentBook).investmentType,
          strategy: (data as InvestmentBook).strategy
        });
      },
      error: (error) => {
        console.error('Error loading book data:', error);
      }
    });
  }

  checkBookType(): void {
    this.isBiographyBookType = this.selectedBookType === BookType.BiographyBook;
    this.isCryptoCurrencyBookType = this.selectedBookType === BookType.CryptoCurrencyBook;
    this.isInvestmentBookType = this.selectedBookType === BookType.InvestmentBook;
    console.log('Selected book type:', this.selectedBookType);
    console.log('Is Biography Book Type:', this.isBiographyBookType);
    console.log('Is Crypto Currency Book Type:', this.isCryptoCurrencyBookType);
    console.log('Is Investment Book Type:', this.isInvestmentBookType);
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
      let formValue = this.updateBookForm.value;
      console.log('Form Value before conversion:', formValue);
      formValue.id = uuidv4();
      formValue.dateStart = formValue.dateStart ? toUTC(formValue.dateStart) : null;
      formValue.dateRead = formValue.dateRead ? toUTC(formValue.dateRead) : null;
      formValue.dateEnd = formValue.dateEnd ? toUTC(formValue.dateEnd) : null;
  
      console.log('Form Value after conversion:', formValue);

      formValue = removeUndefinedProperties(formValue);
      console.log('Form Value after removing undefined properties:', formValue);
  
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

