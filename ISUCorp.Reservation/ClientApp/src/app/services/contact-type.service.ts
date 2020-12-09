import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { ContactType } from "../models/contacttype.model";

@Injectable()
export class ContactTypeService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getAll(): Observable<ContactType[]> {
    return this.http.get<ContactType[]>(this.baseUrl + 'api/ContactType/GetAll')
  }

}
