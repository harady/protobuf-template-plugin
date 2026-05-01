// This file is auto-generated. Do not edit manually.

export const UserRole = {
  USER_ROLE_UNSPECIFIED: 0,
  USER_ROLE_GUEST: 1,
  USER_ROLE_MEMBER: 2,
  USER_ROLE_ADMIN: 3,
} as const;
export type UserRole = typeof UserRole[keyof typeof UserRole];

export interface User {
  id: number;
  name: string;
  email: string;
  role: UserRole;
  tags: string[];
}

export interface GetUserRequest {
  id: number;
}

export interface GetUserResponse {
  user: User;
}
