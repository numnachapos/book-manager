import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BookService } from 'src/app/services/book.service';
import { Router } from '@angular/router';
import { toUTC } from '../../../utils/data-utils';
import { BookType } from 'src/app/interfaces/book-type.enum';

@Component({
  selector: 'app-new-book',
  templateUrl: './new-book.component.html',
  styleUrls: ['./new-book.component.css']
})
export class NewBookComponent implements OnInit {

  addBookForm: FormGroup = new FormGroup({});
  bookTypes: string[] = [];
  showError: Boolean = false;
  selectedBookType: BookType | null = null;
  isBiographyBookType: boolean = false;
  isCryptoCurrencyBookType: boolean = false;
  isInvestmentBookType: boolean = false;

  constructor(private service: BookService, private fb: FormBuilder, private router: Router) {
    this.addBookForm = this.fb.group({
      bookType: ['', Validators.required],
      title: ['', Validators.required],
      author: ['', Validators.required],
      description: ['', [Validators.required, Validators.minLength(30)]],
      rate: [''],
      dateStart: [''],
      dateRead: [''],
      dateEnd: ['']
    });
   }

  ngOnInit(): void {
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
    this.selectedBookType = this.addBookForm.get('bookType')?.value;
    const selectedBookTypeEnum = BookType[this.selectedBookType as unknown as keyof typeof BookType];
    this.isBiographyBookType = selectedBookTypeEnum === BookType.BiographyBook;
    this.isCryptoCurrencyBookType = selectedBookTypeEnum === BookType.CryptoCurrencyBook;
    this.isInvestmentBookType = selectedBookTypeEnum === BookType.InvestmentBook;

    // Clear specific controls
    this.clearSpecificControls();

    // Add specific controls based on the selected book type
    if (this.isBiographyBookType) {
      this.addBookForm.addControl('subject', this.fb.control('', Validators.required));
      this.addBookForm.addControl('timePeriod', this.fb.control('', Validators.required));
    } else if (this.isCryptoCurrencyBookType) {
      this.addBookForm.addControl('currencyType', this.fb.control('', Validators.required));
      this.addBookForm.addControl('marketTrend', this.fb.control('', Validators.required));
    } else if (this.isInvestmentBookType) {
      this.addBookForm.addControl('investmentType', this.fb.control('', Validators.required));
      this.addBookForm.addControl('strategy', this.fb.control('', Validators.required));
    }

    // Mark the form as dirty when the book type is changed
    this.addBookForm.markAsDirty();
  }

  private clearSpecificControls(): void {
    // Remove specific controls
    this.addBookForm.removeControl('subject');
    this.addBookForm.removeControl('timePeriod');
    this.addBookForm.removeControl('currencyType');
    this.addBookForm.removeControl('marketTrend');
    this.addBookForm.removeControl('investmentType');
    this.addBookForm.removeControl('strategy');
  }

  onSubmit() {
      const formValue = this.addBookForm.value;
      formValue.bookType = BookType[formValue.bookType as keyof typeof BookType];
      formValue.dateStart = formValue.dateStart ? toUTC(formValue.dateStart) : null;
      formValue.dateRead = formValue.dateRead ? toUTC(formValue.dateRead) : null;
      formValue.dateEnd = formValue.dateEnd ? toUTC(formValue.dateEnd) : null;
  
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
