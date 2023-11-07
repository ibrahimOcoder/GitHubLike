import { MyProjectsViewDto } from '../myprojects/MyProjectsViewDto';

export interface SharedProjectsViewDto {
  project: MyProjectsViewDto;
  inviteAccepted?: boolean;
  userName?: string;
}
