import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { ContactService } from '../services/contact.service'
import { ContactTypeService } from '../services/contact-type.service'
import { Contact } from '../models/contact.model'
import { ContactType } from '../models/contacttype.model'
import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';


@Component({
  selector: 'app-create-contact',
  templateUrl: './create-contact.component.html',
  styleUrls: []
})
export class CreateContactComponent implements OnInit {



  constructor(private dataService: ContactService,
    private router: Router, private contactTypeService: ContactTypeService)
  { }

  submitted = false;
  Editor = ClassicEditor;
  item: Contact = new Contact();
  contactTypes: ContactType[] = [];

  ngOnInit() {
    //getting the contact types
    this.contactTypeService.getAll()
      .subscribe((result: ContactType[]) => {
        this.contactTypes = result;
      });
  }

  onSubmit() {
    this.submitted = true;

    this.dataService.create(this.item)
      .subscribe(data => {
        this.router.navigate(['contacts']);
      });
  }
}  
