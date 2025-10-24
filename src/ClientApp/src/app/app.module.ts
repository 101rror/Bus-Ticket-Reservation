import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { SearchSectionComponent } from './components/search-section/search-section.component';
import { ResultsPageComponent } from './components/results-page/results-page.component';
import { SeatSelectionComponent } from './components/seat-selection/seat-selection.component';

@NgModule({
  declarations: [
    AppComponent,
    SearchSectionComponent,
    ResultsPageComponent,
    SeatSelectionComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }