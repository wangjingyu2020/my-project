export default [
  {
    path: '/user',
    layout: false,
    routes: [
      {
        name: 'login',
        path: '/user/login',
        component: './User/Login',
      },
    ],
  },
  {
    path: '/welcome',
    name: 'welcome',
    icon: 'smile',
    component: './Welcome',
  },
  {
    path: '/skill',
    name: 'skill',
    icon: 'BookOutlined',
    component: './Skill',
  },

  {
    path: '/project',
    name: 'project',
    icon: 'BookOutlined',
    routes: [
      {
        path: '/project',
        redirect: '/project/list',
      },
      {
        path: '/project/list',
        name: 'list',
        component: './Project/ProjectList',
      },
      {
        path: '/project/detail/:id',
        component: './Project/ProjectDetail',
        
      },
    ],
  },

  {
    path: '/',
    redirect: '/welcome',
  },
  {
    path: '*',
    layout: false,
    component: './404',
  },
];
