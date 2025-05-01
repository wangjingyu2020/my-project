import React from 'react';
import { Card } from 'antd';
import { Scatter } from '@ant-design/plots';

interface SkillsHistoryData {
  skillId: number;
  name: string;
  year: number;
  intensity: number;
}

interface TechChartProps {
  skillsHistoryData: SkillsHistoryData[]; // ✅ Accept skill data as a prop
  title: string;
  style?: React.CSSProperties;
}

const TechChart: React.FC<TechChartProps> = ({ skillsHistoryData, title, style }) => {
  const config = {
    data: skillsHistoryData, // ✅ Use external data
    colorField: "name", // Color by technology name
    xField: "year", // Learning year
    yField: "intensity", // Learning intensity
    shapeField: "circle",
    pointStyle: {
      fillOpacity: "#1",
      r: 5, // Point size
    }
  };

  return (
    <Card title={title} style={{ borderRadius: 10, boxShadow: "0 4px 8px rgba(0,0,0,0.1)", ...style }}>
      <Scatter {...config} />
    </Card>
  );
};

export default TechChart;
