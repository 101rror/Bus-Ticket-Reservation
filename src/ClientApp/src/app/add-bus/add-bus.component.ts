import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-add-bus',
  template: `
    <div class="container mx-auto p-4">
      <h2 class="text-2xl font-bold mb-4">Add New Bus</h2>
      <form [formGroup]="busForm" (ngSubmit)="onSubmit()" class="max-w-lg">
        <div class="mb-4">
          <label class="block text-gray-700 text-sm font-bold mb-2" for="busName">
            Bus Name
          </label>
          <input
            type="text"
            id="busName"
            formControlName="busName"
            class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          />
        </div>

        <div class="mb-4">
          <label class="block text-gray-700 text-sm font-bold mb-2" for="busNumber">
            Bus Number
          </label>
          <input
            type="text"
            id="busNumber"
            formControlName="busNumber"
            class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          />
        </div>

        <div class="mb-4">
          <label class="block text-gray-700 text-sm font-bold mb-2" for="fromCity">
            From City
          </label>
          <input
            type="text"
            id="fromCity"
            formControlName="fromCity"
            class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          />
        </div>

        <div class="mb-4">
          <label class="block text-gray-700 text-sm font-bold mb-2" for="toCity">
            To City
          </label>
          <input
            type="text"
            id="toCity"
            formControlName="toCity"
            class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          />
        </div>

        <div class="mb-4">
          <label class="block text-gray-700 text-sm font-bold mb-2" for="journeyDate">
            Journey Date
          </label>
          <input
            type="date"
            id="journeyDate"
            formControlName="journeyDate"
            class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          />
        </div>

        <div class="mb-4">
          <label class="block text-gray-700 text-sm font-bold mb-2" for="fare">
            Fare
          </label>
          <input
            type="number"
            id="fare"
            formControlName="fare"
            class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          />
        </div>

        <div class="mb-4">
          <label class="block text-gray-700 text-sm font-bold mb-2" for="totalSeats">
            Total Seats
          </label>
          <input
            type="number"
            id="totalSeats"
            formControlName="totalSeats"
            class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          />
        </div>

        <div class="flex items-center justify-between">
          <button
            type="submit"
            [disabled]="!busForm.valid"
            class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline disabled:opacity-50"
          >
            Add Bus
          </button>
        </div>
      </form>
    </div>
  `
})
export class AddBusComponent implements OnInit {
  busForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private http: HttpClient
  ) {
    this.busForm = this.fb.group({
      busName: ['', Validators.required],
      busNumber: ['', Validators.required],
      fromCity: ['', Validators.required],
      toCity: ['', Validators.required],
      journeyDate: ['', Validators.required],
      fare: ['', [Validators.required, Validators.min(0)]],
      totalSeats: ['', [Validators.required, Validators.min(1)]]
    });
  }

  ngOnInit(): void {}

  onSubmit() {
    if (this.busForm.valid) {
      this.http.post('/api/bus', this.busForm.value).subscribe(
        (response) => {
          alert('Bus added successfully!');
          this.busForm.reset();
        },
        (error) => {
          alert('Error adding bus: ' + error.message);
        }
      );
    }
  }
}