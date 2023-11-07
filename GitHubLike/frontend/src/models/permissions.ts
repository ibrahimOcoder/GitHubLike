export enum Permissions {
  Create = 1 << 0,
  Retrieve = 1 << 1,
  Update = 1 << 2,
  Delete = 1 << 4,
}

export function ToPermissionValues(n: Permissions) {
  const values: string[] = [];
  while (n) {
    const bit = n & (~n + 1);
    values.push(Permissions[bit]);
    n ^= bit;
  }
  return values;
}
