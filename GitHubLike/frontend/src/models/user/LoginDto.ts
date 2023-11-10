export interface LoginDto {
  userId: string;
  password: string;
}

export interface LoginResponseDto {
  userId: number;
  token: string;
}
