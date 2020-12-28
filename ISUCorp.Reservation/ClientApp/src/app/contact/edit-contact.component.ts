import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { ContactService } from '../services/contact.service'
import { ContactTypeService } from '../services/contact-type.service'
import { Contact } from '../models/contact.model'
import { ContactType } from '../models/contacttype.model'
import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';


@Component({
  selector: 'app-edit-contact',
  templateUrl: './edit-contact.component.html',
  styleUrls: []
})
export class EditContactComponent implements OnInit {



  constructor(private dataService: ContactService, private route: ActivatedRoute,
    private router: Router, private contactTypeService: ContactTypeService)
  { }

  submitted = false;
  Editor = ClassicEditor;
  item: Contact = new Contact();
  contactTypes: ContactType[] = [];
  contactId: number;
  errorMessage;
  ngOnInit() {
    //getting the contact types
    this.contactTypeService.getAll()
      .subscribe((result: ContactType[]) => {
        this.contactTypes = result;
      }, (error) => {//Error callback
        this.errorMessage = error;
      });

    this.route.queryParams.subscribe(params => {
      this.contactId = params['id'];

      this.dataService.getById(this.contactId)
        .subscribe((result: Contact) => {
          this.item = result;
        }, (error) => {//Error callback
          this.errorMessage = error;
        });
    });

  
  }

  onSubmit() {
    this.submitted = true;

    this.dataService.update(this.item)
      .subscribe(data => {
        this.router.navigate(['contacts']);
      }, (error) => {//Error callback
        this.errorMessage = error;
      });
  }
}  
