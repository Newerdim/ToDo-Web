import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NavbarService {

  private headerMessageSource = new Subject<boolean>();
  headerMessage = this.headerMessageSource.asObservable();

  constructor() { }

  showNav(show: boolean) {
    this.headerMessageSource.next(show);
  }
}
