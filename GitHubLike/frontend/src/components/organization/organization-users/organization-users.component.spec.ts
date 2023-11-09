import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrganizationUsersComponent } from './organization-users.component';

describe('OrganizationUsersComponent', () => {
  let component: OrganizationUsersComponent;
  let fixture: ComponentFixture<OrganizationUsersComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [OrganizationUsersComponent]
    });
    fixture = TestBed.createComponent(OrganizationUsersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
