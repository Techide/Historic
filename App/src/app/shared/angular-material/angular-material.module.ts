import { NgModule } from "@angular/core";
import {
  MatButtonModule,
  MatToolbarModule,
  MatMenuModule,
  MatFormFieldModule,
  MatAutocompleteModule,
  MatInputModule
} from "@angular/material";
import { ReactiveFormsModule, FormsModule } from "@angular/forms";

const modules = [
  FormsModule,
  ReactiveFormsModule,
  MatFormFieldModule,
  MatInputModule,
  MatAutocompleteModule,
  MatButtonModule,
  MatToolbarModule,
  MatMenuModule
];

@NgModule({
  imports: [],
  exports: [modules],
  declarations: []
})
export class AngularMaterialModule {}
