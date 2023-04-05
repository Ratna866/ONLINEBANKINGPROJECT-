import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginComponent } from '../components/login/login.component';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http:HttpClient) { }
  baseServerUrl="https://localhost:7062";
  
  public registerUser(User:Array<String>) {
    return this.http.post(this.baseServerUrl +"/api/User/CreateUser",null,{
      responseType:'text',
    });
  }
}
// public LoginComponent(user:Array<String>) {
//   return this.http.post(this.baseServerUrl +"User/CreateUser",null,{
//     responseType:'text',
//   });
// }
