import { Contact } from "./contact.model";

export class Reservation {
  id: number;
  description: string;
  date: Date;
  ranking: number;
  isFavorite: boolean;
  contactId: number;
  contact: Contact;
}
