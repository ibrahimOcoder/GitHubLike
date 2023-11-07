import { Component } from '@angular/core';
import { RxState } from '@rx-angular/state';
import { SharedProjectsViewDto } from 'src/models/projects/sharedprojects/SharedProjectsViewDto';
import { SharedProjectsApiService } from './shared-projects.api.service';

export interface State {
  sharedProjects: SharedProjectsViewDto[];
}

@Component({
  selector: 'app-shared-projects',
  templateUrl: './shared-projects.component.html',
  styleUrls: ['./shared-projects.component.scss'],
  providers: [SharedProjectsApiService, RxState],
})
export class SharedProjectsComponent {
  state$ = this.state.select('sharedProjects');

  constructor(
    private state: RxState<State>,
    private sharedProjectsService: SharedProjectsApiService,
  ) {
    this.state.connect(
      'sharedProjects',
      this.sharedProjectsService.getSharedProjects(1),
      (_, sharedProjects) => {
        return sharedProjects;
      },
    );
  }
}
