import { Permissions } from '../permissions';

export interface RoleViewDto {
  roleName: string;
  permissions: Permissions;
  permissionsLabels: string[];
}
