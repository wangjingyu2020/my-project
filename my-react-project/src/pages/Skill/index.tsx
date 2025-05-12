import React, { useEffect, useState } from 'react';
import { PageContainer } from '@ant-design/pro-components';
import TechCategory from './components/TechCategory';
import TechChart from './components/TechChart';
import { getUserSkills, getUserSkillsHistory } from '@/services/ant-design-pro/api';
import { Row, Col, Tabs, Typography, Card } from 'antd';
import { useModel } from '@umijs/max';
import { motion } from 'framer-motion'; // Framer Motion



const { Title, Paragraph } = Typography;



const Skill: React.FC = () => {

  const { initialState } = useModel('@@initialState');
  const userId = initialState?.currentUser?.userid;
  const [skillsData, setSkillsData] = useState<API.SkillDto[]>([]);
  const [skillHistoryData, setSkillHistoryData] = useState<API.SkillHistoryDto[]>([]);
  const [activeTab, setActiveTab] = useState<string>("All"); // Default to 'All'
  const [selectedSkillId, setSelectedSkillId] = useState<number | null>(null);

  useEffect(() => {
    // ✅ Fetch user skills
    getUserSkills(Number(userId)).then((res) => {
      if (res.code === 200) {
        setSkillsData(res.data);
      }
    });

    // ✅ Fetch skill history
    getUserSkillsHistory(Number(userId)).then((res) => {
      if (res.code === 200) {
        setSkillHistoryData(res.data);
      }
    });
  }, []);

  // ✅ Filter skills based on active tab
  const filteredSkills = skillsData.filter(skill =>
    activeTab === "All" || skill.techCategoryName === activeTab
  );

  const onSelectSkill = (skillId: number) => {
    setSelectedSkillId(prevId => (prevId === skillId ? null : skillId));
  };

  const filteredHistory = skillHistoryData.filter(history =>
    selectedSkillId ? history.skillId === selectedSkillId : filteredSkills.some(skill => skill.name === history.skillName)
  );

  const handleTabChange = (key: string) => {
    setSelectedSkillId(null);
    setActiveTab(key);
  };

  return (
    <motion.div initial={{ opacity: 0, scale: 0.95 }} animate={{ opacity: 1, scale: 1 }} transition={{ duration: 1 }}>

      <PageContainer title={false}>

        <Card style={{ marginBottom: 20, textAlign: 'center', borderRadius: 8 }}>
          <Title level={2}>My Technical Skills Analysis</Title>
          <Paragraph type="secondary">
            This page showcases the technical skills I have mastered, categorized into different areas, along with an analysis of learning trends over time. You can switch tabs to explore various skill categories and track how my learning intensity has evolved.
          </Paragraph>
        </Card>


        <Tabs defaultActiveKey="All" onChange={(key) => handleTabChange(key)} centered>
          <Tabs.TabPane tab="All" key="All" />
          <Tabs.TabPane tab="Frontend" key="Frontend" />
          <Tabs.TabPane tab="Backend" key="Backend" />
          <Tabs.TabPane tab="DevOps" key="DevOps" />
        </Tabs>

        <Row gutter={24}>
          <Col span={12}>
            <TechCategory
              skillsData={filteredSkills}
              selectedSkillId={selectedSkillId}
              onSelectSkill={onSelectSkill}
              title="Skills"
              style={{ height: 600, overflowY: "auto" }}
            />
          </Col>

          <Col span={12}>
            <TechChart
              skillsHistoryData={filteredHistory.map((history) => ({
                skillId: history.skillId,
                name: history.skillName,
                year: history.year,
                intensity: history.popularity,
              }))}
              title="Learning History"
              style={{ height: 600, overflowY: "auto" }}
            />
          </Col>
        </Row>
      </PageContainer>
    </motion.div>
  );
};

export default Skill;
