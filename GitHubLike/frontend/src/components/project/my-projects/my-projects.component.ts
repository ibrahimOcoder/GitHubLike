import { Component } from '@angular/core';
import { RxState } from '@rx-angular/state';
import { MyProjectsViewDto } from 'src/models/projects/myprojects/MyProjectsViewDto';
import { LoginResponseDto } from 'src/models/user/LoginDto';
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
    const currentUser = JSON.parse(
      localStorage.getItem('currentUser')!,
    ) as LoginResponseDto;
    this.state.connect(
      'myProjects',
      this.myProjectsService.getMyProjects(currentUser.userId),
      (_, myProjects) => {
        return myProjects;
      },
    );
  }
}
