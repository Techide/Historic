import { NgModule } from "@angular/core";
import { DropdownSearchEditComponent } from "./dropdown-search-edit/dropdown-search-edit.component";
import { ClickOutsideDirective } from "./dropdown-search-edit/dropdown.directive";
import { AngularMaterialModule } from "./angular-material/angular-material.module";
import { CommonModule } from "@angular/common";
import { CampaignService } from "./campaign/campaign.service";
import { HttpClientModule } from "@angular/common/http";

const components = [DropdownSearchEditComponent, ClickOutsideDirective];

@NgModule({
  imports: [CommonModule, AngularMaterialModule, HttpClientModule],
  exports: [components, AngularMaterialModule, HttpClientModule],
  declarations: [components],
  providers: [CampaignService]
})
export class SharedModule {}
