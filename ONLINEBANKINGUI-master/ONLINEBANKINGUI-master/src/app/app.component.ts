import { Component } from '@angular/core';
import { RegisterComponent } from './components/register/register.component';
import { AuthService } from './services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'OnlineBanking.UI';
  

// constructor(private authService:AuthService){
// RegisterComponent(user:User){
//   this.authService.register(user).subscribe();
// }
}

