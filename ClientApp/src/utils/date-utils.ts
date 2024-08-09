export function toUTC(date: string): string {
    return new Date(date).toISOString();
  }