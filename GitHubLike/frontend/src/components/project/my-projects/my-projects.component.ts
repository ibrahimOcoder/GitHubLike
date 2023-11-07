import { Component } from '@angular/core';
import { RxState } from '@rx-angular/state';
import { MyProjectsViewDto } from 'src/models/projects/myprojects/MyProjectsViewDto';
import { MyProjectsApiService } from './my-projects.api.service';

export interface State {
  myProjects: MyProjectsViewDto[];
}

@Component({
  selector: 'app-my-projects',
  templateUrl: './my-projects.component.html',
  styleUrls: ['./my-projects.component.scss'],
  providers: [MyProjectsApiService, RxState],
})
export class MyProjectsComponent {
  state$ = this.state.select('myProjects');

  constructor(
    private state: RxState<State>,
    private myProjectsService: MyProjectsApiService,
  ) {
    this.state.connect(
      'myProjects',
      this.myProjectsService.getMyProjects(1),
      (_, myProjects) => {
        return myProjects;
      },
    );
  }
}
