import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService, AvailableBusDto } from '../../services/api.service';

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

  loading = false;
  error: string | null = null;

  constructor(private route: ActivatedRoute, private router: Router, private api: ApiService) {}

  ngOnInit() {
    this.route.queryParamMap.subscribe(q => {
      this.from = q.get('from') || this.from;
      this.to = q.get('to') || this.to;
      this.date = q.get('date') || this.date;
    });

    // Fetch results after query params are applied so we send the correct params
    this.route.queryParamMap.subscribe(q => {
      // subscription above already sets values; call fetchResults here to ensure
      // the API receives the query params (from/to/date) rather than running
      // before the async subscription fires.
      this.fetchResults();
    });
  }

  viewSeats(id: string) {
    this.router.navigate(['/seats', id]);
  }

  modifySearch() {
    this.router.navigate(['/']);
  }

  fetchResults() {
    if (!this.date) {
      this.error = 'Please select a journey date';
      return;
    }
    this.loading = true;
    this.error = null;
    this.api.search(this.from, this.to, this.date).subscribe({
      next: (data: AvailableBusDto[]) => {
        this.buses = data.map(d => ({
          id: d.busScheduleId,
          operator: d.busName,
          startTime: new Date(d.journeyDate).toLocaleTimeString(),
          arrivalTime: '',
          seatsLeft: d.availableSeats,
          fare: 0,
          routeFrom: d.fromCity,
          routeTo: d.toCity
        }));
        this.loading = false;
      },
      error: (err) => {
        this.error = 'Could not load buses';
        console.error(err);
        this.loading = false;
      }
    });
  }
}