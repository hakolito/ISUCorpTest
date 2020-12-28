import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { Reservation } from "../models/reservation.model";

@Injectable()
export class ReservationService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getAll(): Observable<Reservation[]> {
    return this.http.get<Reservation[]>(this.baseUrl + 'api/Reservation/GetAll')
  }

  getAllList(): Observable<Reservation[]> {
    return this.http.get<Reservation[]>(this.baseUrl + 'api/Reservation/GetAllList')
  }

  getById(id: number): Observable<Reservation> {
    return this.http.get<Reservation>(this.baseUrl + 'api/Reservation/GetById?id=' + id)
  }

  create(client: Reservation): Observable<number> {
    return this.http.post<number>(this.baseUrl + 'api/Reservation/Create', client)
  }

  update(client: Reservation): Observable<number> {
    return this.http.post<number>(this.baseUrl + 'api/Reservation/Update', client)
  }

  delete(id: number) {
    return this.http.post(this.baseUrl + 'api/Reservation/Delete', id)
  }

  getcount(): Observable<number> {
    return this.http.get<number>(this.baseUrl + 'api/Reservation/GetCount')
  }
}
