export interface Book
{
    id: number;
    title: string;
    description: string;
    autor: string;
    rate?: number;
    dateStart?: Date;
    dateRead?: Date;
    dateEnd?: Date;
}