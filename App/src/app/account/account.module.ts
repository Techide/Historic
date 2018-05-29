import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { AccountRoutingModule } from "./account-routing.module";

import { LoginFormComponent } from "./login-form/login-form.component";
import { FacebookLoginComponent } from "./facebook-login/facebook-login.component";
import { GoogleLoginComponent } from "./google-login/google-login.component";

@NgModule({
  imports: [CommonModule, AccountRoutingModule],
  declarations: [
    LoginFormComponent,
    FacebookLoginComponent,
    GoogleLoginComponent
  ]
})
export class AccountModule {}
