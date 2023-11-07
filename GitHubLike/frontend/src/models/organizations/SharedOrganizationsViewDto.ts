export interface SharedOrganizationsViewDto {
  organization: OrganizationsViewDto;
  inviteAccepted?: boolean;
  userName: string;
}

export interface OrganizationsViewDto {
  organizationId: number;
  organizationName: string;
  createdAt: Date;
}
