import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RxState } from '@rx-angular/state';
import { DeleteProjectUserDto } from 'src/models/projects/myprojects/DeleteProjectUserDto';
import { ProjectDetailsViewDto } from 'src/models/projects/myprojects/ProjectDetailsViewDto';
import { ProjectDetailsApiService } from './project-details.api.service';

interface State {
  projectDetails: ProjectDetailsViewDto;
}

@Component({
  selector: 'app-project-details',
  templateUrl: './project-details.component.html',
  styleUrls: ['./project-details.component.scss'],
  providers: [RxState, ProjectDetailsApiService],
})
export class ProjectDetailsComponent implements OnInit {
  state$ = this.state.select('projectDetails');
  constructor(
    private route: ActivatedRoute,
    private state: RxState<State>,
    private projectDetailsService: ProjectDetailsApiService,
  ) {}

  projectId!: number;
  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    if (id) {
      this.projectId = id;
      this.state.connect(
        'projectDetails',
        this.projectDetailsService.getProjectDetails(id),
        (_, data) => {
          return data;
        },
      );
    }
  }

  removeUser(userId: number) {
    const removeUserDto: DeleteProjectUserDto = {
      projectId: this.projectId,
      userId,
    };

    this.state.hold(
      this.projectDetailsService.removeProjectUser(removeUserDto),
      (resp) => {
        console.log(resp);
        if (resp) {
          this.state.set({ projectDetails: resp });
        }
      },
    );
  }
}
