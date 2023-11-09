export interface ProjectUserUpdateDto {
  projectId: number;
  userId: number;
  roleId?: number;
  acceptedInvite?: boolean;
}
