import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BookingService } from '../../services/booking.service';

@Component({
  selector: 'app-search-results',
  template: `
    <div class="container mx-auto p-4">
      <div *ngIf="loading" class="text-center">
        Loading...
      </div>
      <div *ngIf="error" class="text-red-500 text-center">
        {{ error }}
      </div>
      <div *ngIf="!loading && !error">
        <h2 class="text-2xl mb-4">Available Buses</h2>
        <div *ngIf="buses.length === 0" class="text-center text-gray-600">
          No buses available for the selected route and date.
        </div>
        <div *ngFor="let bus of buses" class="border rounded-lg p-4 mb-4 shadow">
          <div class="flex justify-between items-center">
            <div>
              <h3 class="text-xl font-bold">{{ bus.busName }}</h3>
              <p class="text-gray-600">{{ bus.busNumber }}</p>
              <p>{{ bus.fromCity }} to {{ bus.toCity }}</p>
              <p>Journey Date: {{ bus.journeyDate | date:'medium' }}</p>
              <p>Available Seats: {{ bus.availableSeats }}</p>
            </div>
            <button 
              [routerLink]="['/booking', bus.busScheduleId]"
              class="bg-blue-500 text-white px-4 py-2 rounded hover:bg-blue-600">
              Book Now
            </button>
          </div>
        </div>
      </div>
    </div>
  `
})
export class SearchResultsComponent implements OnInit {
  buses: any[] = [];
  loading = true;
  error = '';

  constructor(
    private route: ActivatedRoute,
    private bookingService: BookingService
  ) {}

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      const { from, to, date } = params;
      if (from && to && date) {
        this.searchBuses(from, to, date);
      } else {
        this.error = 'Missing search parameters';
        this.loading = false;
      }
    });
  }

  searchBuses(from: string, to: string, date: string) {
    this.loading = true;
    this.error = '';
    this.bookingService.searchBuses(from, to, date).subscribe({
      next: (results) => {
        this.buses = results;
        this.loading = false;
      },
      error: (error) => {
        this.error = 'Failed to load available buses. Please try again.';
        this.loading = false;
        console.error('Error loading buses:', error);
      }
    });
  }
}