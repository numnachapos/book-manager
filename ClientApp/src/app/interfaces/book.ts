import { BookType } from "./book-type.enum";

export interface Book {
    id: number;
    bookType: BookType;
    title: string;
    description: string;
    author: string;
    rate?: number;
    dateStart?: Date;
    dateRead?: Date;
    dateEnd?: Date;
}

export interface BiographyBook extends Book {
    subject: string;
    timePeriod: string;
}

export interface CryptoCurrencyBook extends Book {
    currencyType: string;
    marketTrend: string;
}

export interface InvestmentBook extends Book {
    investmentType: string;
    strategy: string;
}

export type AnyBook = Book | BiographyBook | CryptoCurrencyBook | InvestmentBook;