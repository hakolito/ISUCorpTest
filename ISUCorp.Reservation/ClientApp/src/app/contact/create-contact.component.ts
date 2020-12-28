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
    private router: Router, private contactTypeService: ContactTypeService, private fb: FormBuilder) { }

  submitted = false;
  Editor = ClassicEditor;
  item: Contact = new Contact();
  contactTypes: ContactType[] = [];
  errorMessage;
  contactForm: FormGroup;

  ngOnInit() {
    this.contactForm = this.fb.group({
      name: ['', Validators.required],
      contactTypeId: [0],
      dBO: ['', Validators.required],
      phone: ['', Validators.required],
    });


    //getting the contact types
    this.contactTypeService.getAll()
      .subscribe(
        (result: ContactType[]) => {
          this.contactTypes = result;
        },
        (error) => {//Error callback
          this.errorMessage = error;
        });
  }

  onSubmit() {
    this.submitted = true;


    this.item = {
      id:0,
      name: this.contactForm.value.name,
      contactTypeId: parseInt(this.contactForm.value.contactTypeId),
      phone: this.contactForm.value.phone,
      dBO: new Date(this.contactForm.value.dBO)
    };

    this.dataService.create(this.item)
      .subscribe(data => {
        this.router.navigate(['contacts']);
      },
        (error) => {//Error callback
         
          this.errorMessage = [];
          if (error.status === 400) {
            
            // handle validation error
            let validationErrorDictionary = error.error.errors;
            for (var fieldName in validationErrorDictionary) {
              if (validationErrorDictionary.hasOwnProperty(fieldName)) {
                this.errorMessage.push(validationErrorDictionary[fieldName]);
              }
            }
          } else {
            this.errorMessage.push("something went wrong!");
          }
        });
  }
}  
