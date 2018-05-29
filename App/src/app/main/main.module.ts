import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { MainRoutingModule } from "./main-routing.module";
import { AdministrationModule } from "../administration/administration.module";
import { HomeComponent } from "./home/home.component";
import { AngularMaterialModule } from "../shared/angular-material/angular-material.module";

@NgModule({
  imports: [CommonModule, MainRoutingModule, AdministrationModule, AngularMaterialModule],
  declarations: [HomeComponent]
})
export class MainModule {}
