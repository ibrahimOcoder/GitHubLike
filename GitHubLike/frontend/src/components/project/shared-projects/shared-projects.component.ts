import { Component } from '@angular/core';
import { RxState } from '@rx-angular/state';
import { ProjectUserUpdateDto } from 'src/models/projects/sharedprojects/SharedProjectsPatchDto';
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

  updateInvitation(projectId: number, accepted: boolean) {
    const rejectInvitation: ProjectUserUpdateDto = {
      projectId: projectId,
      userId: 1,
      acceptedInvite: accepted,
    };

    this.state.hold(
      this.sharedProjectsService.rejectInvitation(rejectInvitation),
      (resp) => {
        if (resp) {
          this.state.set({ sharedProjects: resp });
        }
      },
    );
  }
}
