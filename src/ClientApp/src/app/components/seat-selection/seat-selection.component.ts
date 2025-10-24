import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

type Seat = {
  id: string;
  label: string;
  status: 'available' | 'selected' | 'booked' | 'sold' | 'blocked';
  gender?: 'M' | 'F';
};

@Component({
  selector: 'app-seat-selection',
  templateUrl: './seat-selection.component.html'
})
export class SeatSelectionComponent implements OnInit {
  operatorId: string | null = null;
  seats: Seat[] = [];
  selected: string[] = [];
  mobile = '';

  constructor(private activatedRoute: ActivatedRoute) {}

  ngOnInit(): void {
    this.operatorId = this.activatedRoute.snapshot.paramMap.get('operatorId');
    this.seats = this.makeSeats();
  }

  makeSeats(): Seat[] {
    const s: Seat[] = [];
    for (let r = 1; r <= 8; r++) {
      for (let c = 1; c <= 4; c++) {
        const id = `${r}${c}`;
        s.push({
          id,
          label: `${r}${String.fromCharCode(64 + c)}`,
          status: Math.random() > 0.85 ? 'booked' : 'available'
        });
      }
    }
    return s;
  }

  toggleSeat(seat: Seat) {
    if (seat.status !== 'available') return;
    const idx = this.selected.indexOf(seat.id);
    if (idx >= 0) {
      this.selected.splice(idx, 1);
    } else {
      this.selected.push(seat.id);
    }
  }

  seatFare = 700;
  get serviceCharge() { return 20 * this.selected.length; }
  get pgwCharge() { return 28 * this.selected.length; }
  get total() { return this.seatFare * this.selected.length + this.serviceCharge + this.pgwCharge; }
}