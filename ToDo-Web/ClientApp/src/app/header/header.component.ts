import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { NavbarService } from '../services/navbar.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  constructor(private navbarService: NavbarService) { }

  ngOnInit(): void {
  }

  showNav() {
    this.navbarService.showNav(true);
  }

}
