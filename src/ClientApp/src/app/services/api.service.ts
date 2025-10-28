import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface AvailableBusDto {
  busScheduleId: string;
  busName: string;
  busNumber: string;
  fromCity: string;
  toCity: string;
  journeyDate: string;
  availableSeats: number;
}

@Injectable({ providedIn: 'root' })
export class ApiService {
  private base = '/api';
  constructor(private http: HttpClient) {}

  search(from: string, to: string, journeyDate: string): Observable<AvailableBusDto[]> {
    let params = new HttpParams()
      .set('from', from)
      .set('to', to);
    
    if (journeyDate) {
      try {
        const date = new Date(journeyDate);
        if (isNaN(date.getTime())) {
          throw new Error('Invalid date');
        }
        // Set the time to midnight UTC
        const utcDate = new Date(Date.UTC(date.getFullYear(), date.getMonth(), date.getDate(), 0, 0, 0));
        params = params.set('journeyDate', utcDate.toISOString());
      } catch (error) {
        console.error('Error parsing date:', error);
        throw new Error('Invalid journey date format');
      }
    }
    
    return this.http.get<AvailableBusDto[]>(`${this.base}/search`, { params });
  }

  getSeatPlan(busScheduleId: string) {
    return this.http.get(`${this.base}/booking/${busScheduleId}/seats`);
  }
}
