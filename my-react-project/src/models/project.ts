import { useState } from "react";
import { getProjects } from "@/services/ant-design-pro/api";

export default function useProjectModel() {
  const [projectData, setProjectData] = useState<API.ProjectDto[]>([]);
  const [loading, setLoading] = useState(false);

  const fetchProjects = async (userId: number) => {
    setLoading(true);
    try {
      const res = await getProjects(userId);
      if (res.code === 200) {
        setProjectData(res.data);
      }
    } catch (err) {
      console.error("Failed to get projects:", err);
    } finally {
      setLoading(false);
    }
  };

  return { projectData, loading, fetchProjects };
}
