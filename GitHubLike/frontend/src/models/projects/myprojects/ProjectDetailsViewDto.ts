export interface ProjectDetailsViewDto {
  projectName: string;
  projectUsersList: ProjectUserDetailViewDto[];
  createdOn: Date;
}

export interface ProjectUserDetailViewDto {
  userId: number;
  userName: string;
}
