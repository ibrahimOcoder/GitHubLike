export interface OrganizationProjectsViewDto {
  projectId: number;
  projectName: string;
  createdBy: string;
  createdOn: Date;
  organizationProjectUsers: OrganizationProjectsUserDetailViewDto[];
  orgProjectUsers?: string;
}

export interface OrganizationProjectsUserDetailViewDto {
  userId: number;
  userName: string;
}
