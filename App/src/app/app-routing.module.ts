import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { HomeComponent } from "./main/home/home.component";

const routes: Routes = [{ path: "", redirectTo: "home", pathMatch: "full" }];

@NgModule({
  imports: [
    RouterModule.forRoot(
      routes,
      { enableTracing: false } // <-- For debugging purposes only
    )
  ],
  exports: [RouterModule]
})
export class HistoricRoutingModule {}
