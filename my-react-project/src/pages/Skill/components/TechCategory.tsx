import React, { useState } from 'react';
import { Card, List, Progress, Tooltip } from 'antd';
import { CodeOutlined } from '@ant-design/icons';

interface SkillsData {
  id: number;
  name: string;
  level: string;
  techCategoryId: number;
  techCategoryName: string;
}

interface TechCategoryProps {
  skillsData: SkillsData[];
  selectedSkillId: number | null;
  onSelectSkill: (id: number) => void;
  title: string;
  style?: React.CSSProperties;
}

const getProgressPercent = (level: string): number => {
  switch (level) {
    case "Experienced":
      return 75;
    case "Intermediate":
      return 50;
    case "Beginner":
      return 25;
    default:
      return 10; // Default fallback
  }
};

const TechCategory: React.FC<TechCategoryProps> = ({ skillsData, selectedSkillId, onSelectSkill, title, style }) => {

  const handleSelectSkill = (id: number) => {
    onSelectSkill(id);
  };

  return (
    <Card title={title} style={{ borderRadius: 10, boxShadow: "0 4px 8px rgba(0,0,0,0.1)", ...style }}>
      <List
        dataSource={skillsData}
        renderItem={(item) => (
          <List.Item
            onClick={() => handleSelectSkill(item.id)}
            style={{
              padding: "12px 16px",
              transition: "background 0.3s",
              borderRadius: 6,
              cursor: "pointer", // ✅ Make items clickable
              background: selectedSkillId === item.id ? "#d9d9d9" : "transparent", // ✅ Highlight selected item
            }}
          >
            <Tooltip title={`${item.name} - ${item.level}`} placement="right">
              <span style={{ marginRight: 12, fontSize: 18 }}>{<CodeOutlined />}</span>
            </Tooltip>
            <span style={{ fontWeight: 600, flex: 1 }}>{item.name}</span>
            <Progress percent={getProgressPercent(item.level)} status="active" style={{ width: "50%" }} />
          </List.Item>
        )}
      />
    </Card>
  );
};

export default TechCategory;
