import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ExchangeRateService, DailyExchangeRates } from '../exchange-rate';
import { Observable, catchError, of } from 'rxjs';

@Component({
  selector: 'app-rate-table',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './rate-table.html',
  styleUrl: './rate-table.css',
  providers: [ExchangeRateService],
})
export class RateTable implements OnInit {
  dailyRates$!: Observable<DailyExchangeRates | undefined>;

  isLoading: boolean = true;
  errorMessage: string | null = null;

  constructor(private rateService: ExchangeRateService) {}

  ngOnInit(): void {
    this.dailyRates$ = this.rateService.getDailyRates().pipe(
      catchError((error) => {
        // Error Handling
        console.error('API Error:', error);
        this.errorMessage = 'Failed to load exchange rates. Check the .NET API status.';
        this.isLoading = false;
        return of(undefined);
      })
    );

    // Track loading state
    this.dailyRates$.subscribe({
      next: () => (this.isLoading = false),
      error: () => (this.isLoading = false),
    });
  }
}
