import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrganizationProjectsComponent } from './organization-projects.component';

describe('OrganizationProjectsComponent', () => {
  let component: OrganizationProjectsComponent;
  let fixture: ComponentFixture<OrganizationProjectsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [OrganizationProjectsComponent]
    });
    fixture = TestBed.createComponent(OrganizationProjectsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
