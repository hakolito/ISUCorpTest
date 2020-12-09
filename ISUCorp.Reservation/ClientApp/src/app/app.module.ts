import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CreateReservationComponent } from './reservation/create-reservation.component';
import { EditReservationComponent } from './reservation/edit-reservation.component';
import { CreateContactComponent } from './contact/create-contact.component';
import { EditContactComponent } from './contact/edit-contact.component';
import { ListContactComponent } from './contact/list-contact.component';


import { NgxPaginationModule } from 'ngx-pagination';  
import { RatingModule } from 'ng-starrating';
import { OrderModule } from 'ngx-order-pipe';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';

/*Services*/
import { ReservationService } from './services/reservation.service';
import { ContactTypeService } from './services/contact-type.service';
import { ContactService } from './services/contact.service';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CreateReservationComponent,
    EditReservationComponent,
    CreateContactComponent,
    EditContactComponent,
    ListContactComponent,

  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgxPaginationModule,
    RatingModule,
    OrderModule,
    CKEditorModule,
    BsDatepickerModule.forRoot(),
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'create-reservation', component: CreateReservationComponent },
      { path: 'edit-reservation/:id', component: EditReservationComponent },
      { path: 'create-contact', component: CreateContactComponent },
      { path: 'contacts', component: ListContactComponent },
      { path: 'edit-contact/:id', component: EditContactComponent },
    ])
  ],
  providers: [
    ReservationService,
    ContactTypeService,
    ContactService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
