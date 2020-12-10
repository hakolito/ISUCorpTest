import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { ReservationService } from '../services/reservation.service'
import { ContactTypeService } from '../services/contact-type.service'
import { ContactService } from '../services/contact.service'
import { Reservation } from '../models/reservation.model'
import { ContactType } from '../models/contacttype.model'
import { Contact } from '../models/contact.model'
import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';


@Component({
  selector: 'app-create-reservation',
  templateUrl: './create-reservation.component.html',
  styleUrls: []
})
export class CreateReservationComponent implements OnInit {



  constructor(private dataService: ReservationService,
    private router: Router, private contactTypeService: ContactTypeService, private contactService: ContactService) { }

  submitted = false;
  Editor = ClassicEditor;
  item: Reservation = new Reservation();
  contact: Contact = new Contact();
  contactTypes: ContactType[] = [];

  ngOnInit() {
    //getting the contact types
    this.contactTypeService.getAll()
      .subscribe((result: ContactType[]) => {
        this.contactTypes = result;
      });
  }

  create() {
    this.router.navigate(['contacts']);
  }

  onKeyUp(event) {
    let name = event.target.value;

    if (name.length > 3) {
      this.contactService.search(name)
        .subscribe((result: Contact) => {
          if (result != undefined) {
            this.contact = result;
          }
        });
    }
  }

  onSubmit() {
    this.submitted = true;

    this.item.contactId = 1;
    this.item.ranking = 3;
    this.item.isFavorite = true;
    this.item.date = new Date();

    this.dataService.create(this.item)
      .subscribe(data => {
        this.router.navigate(['/']);
      });
  }
}  
