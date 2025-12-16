import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface ExchangeRate {
  validFor: string;
  country: string;
  currency: string;
  amount: number;
  currencyCode: string;
  rate: number;
}

export interface DailyExchangeRates {
  rates: ExchangeRate[];
}

@Injectable({
  providedIn: 'root',
})
export class ExchangeRateService {
  private apiUrl = '/api/rates/daily';

  constructor(private http: HttpClient) {}

  getDailyRates(): Observable<DailyExchangeRates> {
    return this.http.get<DailyExchangeRates>(this.apiUrl);
  }
}
