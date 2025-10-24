import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

type BusSummary = {
  id: string;
  operator: string;
  startTime: string;
  arrivalTime: string;
  seatsLeft: number;
  fare: number;
  routeFrom: string;
  routeTo: string;
};

@Component({
  selector: 'app-results-page',
  templateUrl: './results-page.component.html'
})
export class ResultsPageComponent implements OnInit {
  from = 'Dhaka';
  to = 'Rajshahi';
  date = '';
  buses: BusSummary[] = [];

  constructor(private route: ActivatedRoute, private router: Router) {}

  ngOnInit() {
    this.route.queryParamMap.subscribe(q => {
      this.from = q.get('from') || this.from;
      this.to = q.get('to') || this.to;
      this.date = q.get('date') || this.date;
    });

    // Dummy data (UI only)
    this.buses = [
      { id: '1', operator: 'National Travels', startTime: '06:00 AM', arrivalTime: '01:30 PM', seatsLeft: 36, fare: 700, routeFrom: 'Kallyanpur', routeTo: 'Chapai Nawabganj' },
      { id: '2', operator: 'Hanif Enterprise', startTime: '06:00 AM', arrivalTime: '01:30 PM', seatsLeft: 40, fare: 700, routeFrom: 'Mohakhali', routeTo: 'Chapai Nawabganj' },
      { id: '3', operator: 'Grameen Travels', startTime: '06:01 AM', arrivalTime: '12:51 PM', seatsLeft: 36, fare: 700, routeFrom: 'Kallyanpur', routeTo: 'Chapai' }
    ];
  }

  viewSeats(id: string) {
    this.router.navigate(['/seats', id]);
  }

  modifySearch() {
    this.router.navigate(['/']);
  }
}