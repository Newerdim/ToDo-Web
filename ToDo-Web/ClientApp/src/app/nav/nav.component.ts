import { Component, OnInit } from '@angular/core';
import { NavbarService } from '../services/navbar.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {
  navShow: boolean;

  constructor(private navbarService: NavbarService) { }

  ngOnInit(): void {
    this.navShow = false;
    this.navbarService.headerMessage.subscribe(
      show => {
        this.navShow = show;
      }
    );
  }

  hideNav() {
    this.navShow = false;
  }

  showNav() {
    this.navShow = true;
  }

}
