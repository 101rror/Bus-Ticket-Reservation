import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SearchSectionComponent } from './components/search-section/search-section.component';
import { ResultsPageComponent } from './components/results-page/results-page.component';
import { SeatSelectionComponent } from './components/seat-selection/seat-selection.component';

const routes: Routes = [
  { path: '', component: SearchSectionComponent },
  { path: 'results', component: ResultsPageComponent },
  { path: 'seats/:operatorId', component: SeatSelectionComponent },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}