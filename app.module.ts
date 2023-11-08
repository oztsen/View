import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router'; // Importeer RouterModule
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ViewListComponent } from './view-list/view-list.component';
import { ViewDetailsComponent } from './view-details/view-details.component'; // Gewijzigd naar ViewDetailComponent
import { ViewEditComponent } from './view-edit/view-edit.component';

@NgModule({
  declarations: [
    AppComponent,
    ViewListComponent,
    ViewDetailsComponent, // Gewijzigd naar ViewDetailComponent
    ViewEditComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    RouterModule.forRoot([ // Voeg de router-configuratie toe
      { path: 'views', component: ViewListComponent },
      { path: 'views/:id', component: ViewDetailsComponent },
      { path: 'edit/:id', component: ViewEditComponent },
      { path: '', redirectTo: '/views', pathMatch: 'full' },
    ]),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
