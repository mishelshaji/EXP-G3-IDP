  import { Component } from '@angular/core';
  import { Router } from '@angular/router';
  import { AccountsService } from 'src/app/service/account.service';
  import { TokenHelper } from 'src/utilities/helpers/tokenHelper';

  @Component({
    selector: 'app-signin',
    templateUrl: './signin.component.html',
    styleUrls: ['./signin.component.css']
  })
  export class SigninComponent {
    model: LoginDto = {
      email: '',
      password: ''
    }

    constructor(
      private service: AccountsService,
      private router: Router,
      private tokenHelper: TokenHelper) { }


    onSubmit() {
      this.service.login(this.model).subscribe({
        next: (response: any) => {
          this.tokenHelper.setToken(response.result);
          const role = this.tokenHelper.getDecodedToken();
          
          if (role.userrole === "User") {
            this.router.navigateByUrl('/user');
            console.log(role.userrole);
          } else if (role.userrole == "Manager") {
            this.router.navigateByUrl('/manager');
          } else if (role.userrole == "Admin") {
            console.log(role.userrole);
            this.router.navigateByUrl('/admin');
          }
        }
      })
    }

  }
