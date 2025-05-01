// @ts-ignore
/* eslint-disable */
import { request } from '@umijs/max';

/** login API POST /api/auth/login */
export async function login(body: API.LoginParams, options?: { [key: string]: any }) {
  return request<API.LoginResult>('/api/auth/login', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    data: body,
    ...(options || {}),
  });
}

/** logout POST /api/auth/logout */
export async function Logout(options?: { [key: string]: any }) {
  return request<Record<string, any>>('/api/auth/logout', {
    method: 'POST',
    ...(options || {}),
  });
}

/** Get user skills API - GET /api/portfolio/Skill/GetUserSkills/{userId} */
export async function getUserSkills(userId: number, options?: { [key: string]: any }) {
  return request<API.SkillsResult>(`/api/portfolio/Skill/getUserSkills/${userId}`, {
    method: 'GET',
    headers: {
      'Content-Type': 'application/json',
    },
    ...(options || {}),
  });
}

/** Get user skill history API - GET /api/portfolio/Skill/GetUserSkillHistory/{userId} */
export async function getUserSkillsHistory(userId: number, options?: { [key: string]: any }) {
  return request<API.SkillsHistoryResult>(`/api/portfolio/Skill/getUserSkillsHistory/${userId}`, {
    method: 'GET',
    headers: {
      'Content-Type': 'application/json',
    },
    ...(options || {}),
  });
}

/** Get user projects API - GET /api/portfolio/Project/getProjects/{userId} */
export async function getProjects(userId: number, options?: { [key: string]: any }) {
  return request<API.ProjectsResult>(`/api/portfolio/Project/getProjects/${userId}`, {
    method: 'GET',
    headers: {
      'Content-Type': 'application/json',
    },
    ...(options || {}),
  });
}
