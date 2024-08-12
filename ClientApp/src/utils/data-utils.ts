import { AnyBook, BiographyBook, CryptoCurrencyBook, InvestmentBook } from 'src/app/interfaces/book';

export function toUTC(date: string): string {
    return new Date(date).toISOString();
  }

export function isBiographyBook(book: AnyBook): book is BiographyBook {
    return (book as BiographyBook).subject !== undefined;
}

export function isCryptoCurrencyBook(book: AnyBook): book is CryptoCurrencyBook {
    return (book as CryptoCurrencyBook).currencyType !== undefined;
}

export function isInvestmentBook(book: AnyBook): book is InvestmentBook {
    return (book as InvestmentBook).investmentType !== undefined;
}

export function removeUndefinedProperties(obj: any): any {
    return Object.fromEntries(Object.entries(obj).filter(([_, v]) => v !== undefined));
  }