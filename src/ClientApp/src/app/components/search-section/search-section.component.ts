import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-search-section',
  templateUrl: './search-section.component.html',
  styleUrls: ['./search-section.component.css']
})
export class SearchSectionComponent {
  from = 'Dhaka';
  to = 'Sylhet';
    date = '';

  trending = [
    { from: 'Dhaka', to: 'Rajshahi' },
    { from: 'Dhaka', to: "Cox's Bazar" },
    { from: 'Dhaka', to: 'Barisal' },
    { from: 'Dhaka', to: 'Chittagong' },
    { from: 'Dhaka', to: 'Sylhet' }
  ];

    constructor(private router: Router) {}

  applyTrending(t: { from: string, to: string }) {
    this.from = t.from;
    this.to = t.to;
  }

  swapLocations() {
    const temp = this.from;
    this.from = this.to;
    this.to = temp;
  }

  onSearch() {
    if (!this.date) {
      alert('Please select a journey date');
      return;
    }
    
    // Ensure the date is in ISO format
    const selectedDate = new Date(this.date);
    const isoDate = selectedDate.toISOString();
    
    this.router.navigate(
      ['/results'],
      {
        queryParams: {
          from: this.from,
          to: this.to,
          date: isoDate
        }
      }
    );
  }
}
