import { Component, OnInit } from '@angular/core';
import { Router, NavigationExtras } from "@angular/router";
import { ContactService } from '../services/contact.service'
import { Contact } from '../models/contact.model'
@Component({
  selector: 'app-list-contact',
  templateUrl: './list-contact.component.html',
})
export class ListContactComponent implements OnInit {
  list: Contact[];
  hasData: Boolean = false;
  itemsPerPage: number;
  p: number = 1;
  order: string = 'contact.name';
  reverse: boolean = false;
  errorMessage;

  constructor(private dataService: ContactService, private router: Router) { }

  ngOnInit() {
    this.loadData();
  }

  loadData() {
    this.dataService.getAll().subscribe((data) => {
      this.list = data;

      if (this.list.length > 0) {
        this.hasData = true;
      }
      else {
        this.hasData = false;
      }
    }, (error) => {//Error callback
      this.errorMessage = error;
    });
  }


  setOrder(value: string) {
    if (this.order === value) {
      this.reverse = !this.reverse;
    }

    this.order = value;
  }

  create() {
    this.router.navigate(['create-contact']);
  }

  delete(id:number) {

    this.dataService.delete(id).subscribe((data) => {
      this.loadData();
    }, (error) => {//Error callback
      this.errorMessage = error;
    });
  }
}
