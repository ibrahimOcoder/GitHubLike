export interface OrganizationDetailsViewDto {
  organizationName: string;
  organizationUsersList: OrganizationUserDetailViewDto[];
  createdOn: Date;
  isOwner: boolean;
  isAdmin: boolean;
}

export interface OrganizationUserDetailViewDto {
  userId: number;
  userName: string;
  userRole: string;
}
