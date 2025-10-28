import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BookingService {
  constructor(private http: HttpClient) { }

  searchBuses(from: string, to: string, date: string): Observable<any> {
    return this.http.get(`/api/search`, {
      params: {
        from,
        to,
        journeyDate: date
      }
    });
  }
}
