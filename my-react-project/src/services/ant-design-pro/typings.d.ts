// @ts-ignore
/* eslint-disable */

declare namespace API {
  type CurrentUser = {
    name?: string;
    userid?: string;
    email?: string;
  };

  type LoginResult = {
    status?: string;
    message?: string;
    token: string;
    user?: {
      id?: string;
      name?: string;
      email?: string;
      email_verified_at?: string | null;
      created_at?: string;
      updated_at?: string;
    };
  };

  type SkillsResult = {
    code: number;
    message: string;
    data: SkillDto[];
  };

  type SkillDto = {
    id: number;
    name: string;
    level: string;
    techCategoryId: number;
    techCategoryName: string;
  };


  type SkillsHistoryResult = {
    code: number;
    message: string;
    data: SkillHistoryDto[];
  };

  type SkillHistoryDto = {
    id: number;
    skillId: number;
    skillName: string;
    year: number;
    popularity: number;
  };

  type ProjectsResult = {
    code: number;
    message: string;
    data: ProjectDto[];
  };

  type ProjectDto = {
    id: number;
    name: string;
    githubUrl: string;
    startDate: string; // ✅ Use `string` for date, since JSON usually returns ISO format
    description: string;
    technologies: TechnologyDto[];
  };

  type TechnologyDto = {
    id: number;
    name: string;
    type: string;
  };

  type PageParams = {
    current?: number;
    pageSize?: number;
  };

  type RuleListItem = {
    key?: number;
    disabled?: boolean;
    href?: string;
    avatar?: string;
    name?: string;
    owner?: string;
    desc?: string;
    callNo?: number;
    status?: number;
    updatedAt?: string;
    createdAt?: string;
    progress?: number;
  };

  type RuleList = {
    data?: RuleListItem[];
    total?: number;
    success?: boolean;
  };

  type FakeCaptcha = {
    code?: number;
    status?: string;
  };

  type LoginParams = {
    email?: string;
    password?: string;
  };

  type ErrorResponse = {
    errorCode: string;
    errorMessage?: string;
    success?: boolean;
  };

  type NoticeIconList = {
    data?: NoticeIconItem[];
    total?: number;
    success?: boolean;
  };

  type NoticeIconItemType = 'notification' | 'message' | 'event';

  type NoticeIconItem = {
    id?: string;
    extra?: string;
    key?: string;
    read?: boolean;
    avatar?: string;
    title?: string;
    status?: string;
    datetime?: string;
    description?: string;
    type?: NoticeIconItemType;
  };
}
