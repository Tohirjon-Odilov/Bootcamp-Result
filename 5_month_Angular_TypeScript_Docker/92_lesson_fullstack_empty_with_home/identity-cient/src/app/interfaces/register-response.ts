export interface RegisterResponse {
  fullName: string;
  email: string;
  password: string;
  status: string;
  age: number;
  roles: string[];
  message: string;
  statusCode: number;
  isSuccess: boolean;
}
