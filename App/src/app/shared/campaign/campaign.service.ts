import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Campaign } from "./campaign.class";
import { map } from "rxjs/operators";

@Injectable()
export class CampaignService {
  apiAddress = "";

  constructor(private client: HttpClient) {}

  getCampaigns(): Observable<Campaign[]> {
    return this.client.get<Campaign[]>(this.apiAddress);
  }
}
