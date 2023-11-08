import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ViewListComponent } from './view-list/view-list.component';
import { ViewDetailsComponent } from './view-details/view-details.component';
import { ViewEditComponent } from './view-edit/view-edit.component';

const routes: Routes = [
  { path: '', redirectTo: '/views', pathMatch: 'full' },
  { path: 'views', component: ViewListComponent },
  { path: 'views/:id', component: ViewDetailsComponent },
  { path: 'views/:id/edit', component: ViewEditComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
