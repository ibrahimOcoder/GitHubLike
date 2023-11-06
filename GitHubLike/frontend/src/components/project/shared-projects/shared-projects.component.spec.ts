import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SharedProjectsComponent } from './shared-projects.component';

describe('SharedProjectsComponent', () => {
  let component: SharedProjectsComponent;
  let fixture: ComponentFixture<SharedProjectsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SharedProjectsComponent]
    });
    fixture = TestBed.createComponent(SharedProjectsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
