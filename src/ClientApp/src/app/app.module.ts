import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { SearchSectionComponent } from './components/search-section/search-section.component';
import { ResultsPageComponent } from './components/results-page/results-page.component';
import { SeatSelectionComponent } from './components/seat-selection/seat-selection.component';
import { AddBusComponent } from './add-bus/add-bus.component';

@NgModule({
  declarations: [
    AppComponent,
    SearchSectionComponent,
    ResultsPageComponent,
    SeatSelectionComponent,
    AddBusComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }