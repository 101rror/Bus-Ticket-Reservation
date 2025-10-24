import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-search-section',
  templateUrl: './search-section.component.html'
})
export class SearchSectionComponent {
  from = 'Dhaka';
  to = 'Rajshahi';
  date = '';

  trending = [
    { from: 'Dhaka', to: 'Rajshahi' },
    { from: 'Dhaka', to: "Cox's Bazar" },
    { from: 'Dhaka', to: 'Barisal' }
  ];

  constructor(private router: Router) {}

  applyTrending(t: { from: string; to: string }) {
    this.from = t.from;
    this.to = t.to;
  }

  onSearch() {
    this.router.navigate(['/results'], { queryParams: { from: this.from, to: this.to, date: this.date } });
  }
}