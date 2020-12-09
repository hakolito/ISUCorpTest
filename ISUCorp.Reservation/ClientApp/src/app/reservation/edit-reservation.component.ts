import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { ReservationService } from '../services/reservation.service'
import { ContactTypeService } from '../services/contact-type.service'
import { ContactService } from '../services/contact.service'
import { Reservation } from '../models/reservation.model'
import { ContactType } from '../models/contacttype.model'
import { Contact } from '../models/contact.model'
import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';


@Component({
  selector: 'app-edit-reservation',
  templateUrl: './edit-reservation.component.html',
  styleUrls: []
})
export class EditReservationComponent implements OnInit {



  constructor(private dataService: ReservationService, private route: ActivatedRoute,
    private router: Router, private contactTypeService: ContactTypeService, private contactService: ContactService)
  { }

  submitted = false;
  Editor = ClassicEditor;
  item: Reservation = new Reservation();
  contact: Contact = new Contact();
  contactTypes: ContactType[] = [];
  reservationId: number;

  ngOnInit() {
    //getting the contact types
    this.contactTypeService.getAll()
      .subscribe((result: ContactType[]) => {
        this.contactTypes = result;
      });

    this.route.queryParams.subscribe(params => {
      this.reservationId = params['id'];

      this.dataService.getById(this.reservationId)
        .subscribe((result: Reservation) => {
          this.item = result;

          this.contactService.getById(this.item.contactId)
            .subscribe((result: Contact) => {
              this.contact = result;
            });

        });
    });

  }

  onSubmit() {
    this.submitted = true;

    this.item.ranking = 3;
    this.item.isFavorite = true;
    this.item.date = new Date();

    this.dataService.update(this.item)
      .subscribe(data => {
        this.router.navigate(['/']);
      });
  }
}  
