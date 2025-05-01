import { GithubOutlined } from '@ant-design/icons';
import { DefaultFooter } from '@ant-design/pro-components';
import React from 'react';

const Footer: React.FC = () => {
  return (
    <DefaultFooter
      style={{
        background: 'none',
      }}
      links={[
        {
          key: 'portfolio',
          title: 'portfolio',
          href: 'https://github.com/wangjingyu2020/my-project',
          blankTarget: true,
        },
        {
          key: 'github',
          title: <GithubOutlined />,
          href: 'https://github.com/wangjingyu2020/my-project',
          blankTarget: true,
        },
        {
          key: 'my-project',
          title: 'my-project',
          href: 'https://github.com/wangjingyu2020/my-project',
          blankTarget: true,
        },
      ]}
    />
  );
};

export default Footer;
