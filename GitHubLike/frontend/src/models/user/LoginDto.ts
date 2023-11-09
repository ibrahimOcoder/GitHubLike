export interface LoginDto {
  userId: string;
  password: string;
}

export interface LoginResponseDto {
  token: string;
}
