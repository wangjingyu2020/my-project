import React from "react";
import { Card, Typography, Divider, Timeline, Tag, Avatar, Spin } from "antd";
import { useParams } from "react-router-dom";
import { useModel } from "@umijs/max";
import MarkdownViewer from "@/components/Markdown/Markdown";
import { motion } from "framer-motion";
import dayjs from "dayjs";

const { Title, Paragraph } = Typography;

const ProjectDetail: React.FC = () => {
  const { id } = useParams<{ id: string }>();
  const { projectData, loading } = useModel("project");
  const project = projectData.find((p) => p.id === Number(id));


const getRawReadmeUrlFromGitUrl = (gitUrl: string) => {
  const cleanUrl = gitUrl.replace(/\.git$/, "");
  const match = cleanUrl.match(/^https:\/\/github\.com\/([^/]+)\/([^/]+)$/);

  if (!match) return null;

  const [_, username, repo] = match;
  return `https://raw.githubusercontent.com/${username}/${repo}/refs/heads/main/README.md`;
};



  if (loading) {
    return (
      <div style={{ textAlign: "center", padding: "50px" }}>
        <Spin size="large" />
      </div>
    );
  }

  if (!project) {
    return (
      <div style={{ textAlign: "center", fontSize: "18px", marginTop: "20px", color: "#999" }}>
        no project
      </div>
    );
  }

  return (
    <motion.div
      initial={{ opacity: 0, scale: 0.95 }}
      animate={{ opacity: 1, scale: 1 }}
      transition={{ duration: 0.5 }}
    >
      <div
        style={{
          maxWidth: "800px",
          margin: "40px auto",
          padding: "24px",
          background: "#fff",
          boxShadow: "0 6px 20px rgba(0,0,0,0.15)",
          borderRadius: "12px",
        }}
      >
        <Card
          style={{ borderRadius: "12px" }}
          title={
            <div style={{ display: "flex", alignItems: "center", gap: "12px" }}>
              <Avatar src={`https://api.dicebear.com/7.x/miniavs/svg?seed=${project.id}`} size={64} />
              <Title level={2} style={{ margin: 0 }}>{project.name}</Title>
            </div>
          }
        >
          <Paragraph style={{ fontSize: "16px", color: "#555" }}>
            {project.description}
          </Paragraph>
          <Divider style={{ color: "#1890ff" }}>Tech Stack</Divider>
          <div style={{ display: "flex", flexWrap: "wrap", gap: "8px" }}>
            {project.technologies.map((tech, index) => (
              <Tag key={index} color="blue" style={{ padding: "6px 12px", fontSize: "14px", borderRadius: "8px" }}>
                {tech.name}
              </Tag>
            ))}
          </div>

          <Divider style={{ color: "#1890ff" }}>Project Milestones</Divider>
          <motion.div initial={{ opacity: 0, y: 10 }} animate={{ opacity: 1, y: 0 }} transition={{ duration: 0.4 }}>
            <Timeline mode="left" style={{ marginBottom: 10 }}>
              <Timeline.Item>
                {dayjs(project.startDate).format("YYYY-MM-DD")} - Project Kickoff
              </Timeline.Item>              
              <Timeline.Item>{new Date().toISOString().split('T')[0]} - Project Review</Timeline.Item>
            </Timeline>
          </motion.div>
          <Divider style={{ color: "#1890ff" }}>Read Me</Divider>
          <Card
            style={{
              borderRadius: "8px",
              padding: "16px",
              marginTop: "12px",
              boxShadow: "0px 2px 8px rgba(0, 0, 0, 0.08)",
            }}
          >
            <MarkdownViewer file={getRawReadmeUrlFromGitUrl(project.githubUrl) || ""} />
          </Card>
        </Card>
      </div>
    </motion.div>
  );
};

export default ProjectDetail;
