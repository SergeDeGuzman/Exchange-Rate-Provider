import { Component, signal } from '@angular/core';
import { RateTable } from './rate-table/rate-table';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RateTable],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App {
  title = 'CnBExchangeRate';
}
