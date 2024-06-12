import { Component } from '@angular/core';
import { AuthService } from '../../auth/auth.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.css'
})
export class NavBarComponent {
  
  username :any = this.authService.currentUserSource?.value?.username;
  
  constructor(
    private authService: AuthService
    ) {}
  
    logout(){
      this.authService.logout();
    }
  }
