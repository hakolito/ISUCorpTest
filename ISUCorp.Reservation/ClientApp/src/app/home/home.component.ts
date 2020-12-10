import { Component, OnInit } from '@angular/core';
import { Router, NavigationExtras } from "@angular/router";
import { ReservationService } from '../services/reservation.service'
import { Reservation } from '../models/reservation.model'
import { TranslateService } from '@ngx-translate/core';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  list: Reservation[];
  hasData: Boolean = false;
  itemsPerPage: number;
  p: number = 1;
  order: string = 'contact.name';
  reverse: boolean = false;

  constructor(private reservationService: ReservationService, private router: Router, private translate: TranslateService) {
    translate.addLangs(['en', 'es']);
    translate.setDefaultLang('en');
  }

  ngOnInit() {
    this.loadData();
  }

  loadData() {
    this.reservationService.getAllList().subscribe((data) => {
      this.list = data;

      if (this.list.length > 0) {
        this.hasData = true;
      }
      else {
        this.hasData = false;
      }
    });
  }


  setOrder(event) {
    if (this.order === event.target.value) {
      this.reverse = !this.reverse;
    }

    this.order = event.target.value;
  }

  create() {
    this.router.navigate(['create-reservation']);
  }
}
