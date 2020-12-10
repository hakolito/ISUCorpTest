import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { Contact } from "../models/contact.model";

@Injectable()
export class ContactService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getAll(): Observable<Contact[]> {
    return this.http.get<Contact[]>(this.baseUrl + 'api/Contact/GetAll')
  }


  getById(id: number): Observable<Contact> {
    return this.http.get<Contact>(this.baseUrl + 'api/Contact/GetById?id=' + id)
  }

 search(name: string): Observable<Contact> {
    return this.http.get<Contact>(this.baseUrl + 'api/Contact/Search?name=' + name)
  }

  create(client: Contact): Observable<number> {
    return this.http.post<number>(this.baseUrl + 'api/Contact/Create', client)
  }

  update(client: Contact): Observable<number> {
    return this.http.post<number>(this.baseUrl + 'api/Contact/Update', client)
  }

  delete(id: number) {
    return this.http.post(this.baseUrl + 'api/Contact/Delete', id)
  }
}
