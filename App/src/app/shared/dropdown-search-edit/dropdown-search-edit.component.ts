import { Component, OnInit, ViewChild, ElementRef } from "@angular/core";
import { FormGroup, FormBuilder, FormControl } from "@angular/forms";
import { Observable } from "rxjs";
import { startWith, map, findIndex, tap } from "rxjs/operators";
import { isNullOrUndefined } from "util";
import { nextTick } from "q";
import { Campaign } from "../campaign/campaign.class";
import { CampaignService } from "../campaign/campaign.service";

@Component({
  selector: "app-dropdown-search-edit",
  templateUrl: "./dropdown-search-edit.component.html",
  styleUrls: ["./dropdown-search-edit.component.scss"]
})
export class DropdownSearchEditComponent implements OnInit {
  @ViewChild("campaignInput") campaignSearchElement: ElementRef;

  selectedItem: Campaign;
  highlightedItem: Campaign;
  showDropDown: boolean;
  fromKeyPress: boolean;

  mouseDownedItem: Campaign;

  options: Campaign[];

  campaignGroup: FormGroup;

  filteredOptions: Observable<Campaign[]>;

  constructor(
    private fb: FormBuilder,
    private campaignService: CampaignService
  ) {
    this.campaignGroup = this.fb.group({ campaignControl: "" });
  }

  ngOnInit(): void {
    this.filteredOptions = this.getCampaignControl().valueChanges.pipe(
      startWith<string | Campaign>(""),
      map(value => (typeof value === "string" ? value : value.Name)),
      map(
        name =>
          this.fromKeyPress
            ? name
              ? this.filter(name)
              : this.options.slice()
            : this.options.slice()
      )
    );
  }

  openDropDown() {
    if (this.options.length < 1) {
      this.showDropDown = false;
      return;
    }

    if (this.showDropDown !== true) {
      this.highlightedItem = this.selectedItem;
      this.showDropDown = true;
    }
  }

  closeDropDown() {
    if (this.showDropDown !== false) {
      this.highlightedItem = undefined;
      this.showDropDown = false;
    }
  }

  onKeyDown(e: KeyboardEvent) {
    this.fromKeyPress = false;
    if (this.showDropDown === false && e.keyCode !== 27) {
      this.openDropDown();
    }

    switch (e.keyCode) {
      case 27: // escape
        e.preventDefault();
        this.closeDropDown();
        break;
      case 38: // arrowUp
        e.preventDefault();
        this.highlightPreviousItem();
        break;
      case 40: // arrrowDown
        e.preventDefault();
        this.highlightNextItem();
        break;
      case 13: // enter
        e.preventDefault();
        this.selectItemValue(this.highlightedItem);
        break;
      default:
        this.fromKeyPress = true;
    }
  }

  onItemMouseDown(e: MouseEvent, item: Campaign) {
    e.preventDefault();
    this.mouseDownedItem = item;
  }

  onItemMouseUp(e: MouseEvent, item: Campaign) {
    e.preventDefault();
    if (this.mouseDownedItem === item) {
      this.selectItemValue(item);
      this.mouseDownedItem = null;
    }
  }

  onIconMouseDown(e: MouseEvent) {
    e.preventDefault();
    this.campaignSearchElement.nativeElement.focus();
  }

  onInputBlur(e) {
    this.closeDropDown();
  }

  private selectItemValue(item: Campaign) {
    if (item) {
      this.getCampaignControl().setValue(item.Name);
      this.selectedItem = item;
      this.closeDropDown();
    }
  }

  private highlightNextItem() {
    if (this.options.length <= 1) {
      return;
    }

    let nextItem: Campaign;
    if (!isNullOrUndefined(this.highlightedItem)) {
      let foundIndex: number;

      this.filteredOptions.forEach(c => {
        foundIndex = c.findIndex(x => x.Id === this.highlightedItem.Id);
        nextItem = c.length - 1 > foundIndex ? c[foundIndex + 1] : c[0];
      });
    } else {
      this.filteredOptions.forEach(c => {
        nextItem = c[0];
      });
    }

    this.highlightedItem = nextItem;
  }

  private highlightPreviousItem(): any {
    if (this.options.length <= 1) {
      return;
    }

    let nextItem: Campaign;
    if (!isNullOrUndefined(this.highlightedItem)) {
      let foundIndex: number;
      this.filteredOptions.forEach(c => {
        foundIndex = c.findIndex(x => x.Id === this.highlightedItem.Id);
        nextItem = foundIndex > 0 ? c[foundIndex - 1] : c[c.length - 1];
      });
    } else {
      this.filteredOptions.forEach(c => {
        nextItem = c[c.length - 1];
      });
    }

    this.highlightedItem = nextItem;
  }

  private getCampaignControl(): FormControl {
    return this.campaignGroup.get("campaignControl") as FormControl;
  }

  private filter(name: string): Campaign[] {
    return this.options.filter(o =>
      o.Name.toLowerCase().includes(name.toLowerCase())
    );
  }
}
