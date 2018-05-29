import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { DropdownSearchEditComponent } from "./dropdown-search-edit.component";

describe("DropdownSearchEditComponent", () => {
  let component: DropdownSearchEditComponent;
  let fixture: ComponentFixture<DropdownSearchEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DropdownSearchEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DropdownSearchEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
