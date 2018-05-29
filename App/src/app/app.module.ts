import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";

import { HistoricComponent } from "./app.component";
import { HistoricRoutingModule } from "./app-routing.module";
import { SharedModule } from "./shared/shared.module";

@NgModule({
  declarations: [HistoricComponent],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    SharedModule,
    HistoricRoutingModule
  ],
  providers: [],
  bootstrap: [HistoricComponent]
})
export class AppModule {}
