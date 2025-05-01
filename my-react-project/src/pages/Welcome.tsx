import { PageContainer } from '@ant-design/pro-components';
import { useModel } from '@umijs/max';
import { Card, theme, Button, Divider } from 'antd';
import React from 'react';
import { motion } from 'framer-motion';
import { history } from '@umijs/max';
import { GithubOutlined, MailOutlined } from '@ant-design/icons';

const InfoCard: React.FC<{ title: string; index: number; desc: string; href: string }> = ({ title, href, index, desc }) => {
  return (
    <motion.div whileHover={{ scale: 1.05 }}>
      <Card hoverable bordered={false} style={{ borderRadius: '8px', minWidth: '220px', textAlign: 'center', transition: 'all 0.3s ease-in-out' }}
        onClick={() => history.push(href)}
      >
        <div style={{
          width: 48, height: 48, lineHeight: '48px', textAlign: 'center',
          color: '#FFF', fontWeight: 'bold', fontSize: '18px', backgroundColor: '#1890ff',
          borderRadius: '50%', margin: '0 auto',
        }}>
          {index}
        </div>
        <h3 style={{ marginTop: '12px' }}>{title}</h3>
        <p style={{ color: '#666', fontSize: '14px' }}>{desc}</p>
      </Card>
    </motion.div>
  );
};

const Welcome: React.FC = () => {
  const { token } = theme.useToken();
  const { initialState } = useModel('@@initialState');

  return (
    <motion.div initial={{ opacity: 0, scale: 0.95 }} animate={{ opacity: 1, scale: 1 }} transition={{ duration: 1 }}>
      <PageContainer title={false}>
        <Card style={{
          borderRadius: 8,
          textAlign: 'center',
          padding: '20px',
          background: '#fff', // ✅ 白色背景
          boxShadow: "0 6px 12px rgba(0, 0, 0, 0.1)", // ✅ 轻微阴影
        }}>
          <h1 style={{ fontSize: '28px', fontWeight: 'bold', color: token.colorTextHeading }}>
            Welcome to my portfolio 🚀
          </h1>
          <p style={{ fontSize: '16px', color: token.colorTextSecondary, lineHeight: '24px' }}>
            Just sharing a bit about my tech stack and this project—Hope you like it!
          </p>

          <div style={{ display: 'flex', justifyContent: 'center', gap: 16, marginTop: 20 }}>
            <InfoCard index={1} title="Skill" href="/skill" desc="Here is my tech stack" />
            <InfoCard index={2} title="Project" href="/project" desc="Here is my project " />
          </div>

          <Divider style={{ color: "#1890ff" }}>About Me</Divider>
          <p style={{ fontSize: '14px', marginTop: '12px', color: '#555' }}>
            A Software Developer familiar with frontend, backend, and DevOps.
          </p>

          <Divider style={{ color: "#1890ff" }}>Contact Me</Divider>          <div style={{ display: 'flex', justifyContent: 'center', gap: 12 }}>
            <Button type="default" icon={<GithubOutlined />} onClick={() => window.open('https://github.com/wangjingyu2020/my-project', '_blank')}>
              GitHub
            </Button>
            <Button type="default" icon={<MailOutlined />} onClick={() => window.open('mailto:jyw19971118@gmail.com')}>
              Email
            </Button>
          </div>
        </Card>
      </PageContainer>
    </motion.div>
  );
};

export default Welcome;
