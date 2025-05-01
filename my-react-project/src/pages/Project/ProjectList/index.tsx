import React, { useEffect, useState } from 'react';
import { Card, Row, Col, Avatar, Tooltip, Tag } from "antd";
import { history, useModel } from '@umijs/max';
import { motion } from 'framer-motion'; // Framer Motion


const ProjectList: React.FC = () => {
  const { initialState } = useModel('@@initialState');
  const userId = initialState?.currentUser?.userid;
  const { projectData, fetchProjects } = useModel("project");

  useEffect(() => {
    if (!projectData.length) {
      fetchProjects(Number(userId));
    }
  }, []);

  return (
    <Row gutter={[16, 16]} style={{ padding: "16px", background: "#f4f4f4" }}>
      {projectData.map(project => (
        <Col key={project.id} xs={24} sm={12} md={8} lg={6}>
          <motion.div
            initial={{ opacity: 0, y: 10 }}
            animate={{ opacity: 1, y: 0 }}
            transition={{ duration: 0.5 }}
            whileHover={{ scale: 1.05 }}
          >
            <Card
              hoverable
              bordered={false}
              style={{
                cursor: "pointer",
                borderRadius: "12px",
                boxShadow: "0 4px 10px rgba(0,0,0,0.15)",
                transition: "all 0.3s ease",
              }}
              onClick={() => history.push(`/project/detail/${project.id}`)}
            >
              <div style={{ display: "flex", flexDirection: "column", alignItems: "center" }}>
                <Tooltip title="Hi~">
                  <Avatar src={`https://api.dicebear.com/7.x/miniavs/svg?seed=${project.id}`} size={64} />
                </Tooltip>
                <h3 style={{ marginTop: "8px", fontWeight: "bold" }}>{project.name}</h3>
              </div>
              <p style={{ textAlign: "center", color: "#555", fontSize: "14px", marginBottom: "10px" }}>
                {project.description}
              </p>
              <div style={{ display: "flex", flexWrap: "wrap", gap: 6, justifyContent: "center" }}>
                {project.technologies.map((tech, index) => (
                  <Tag key={index} color="blue">{tech.name}</Tag>
                ))}
              </div>
            </Card>
          </motion.div>
        </Col>
      ))}
    </Row>
  );
};

export default ProjectList;
