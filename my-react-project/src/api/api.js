import axios from "axios";

// 所有请求通过 gateway
const API_URL = "/api";  // 让 Nginx 代理到 Gateway
const CHAT_URL = "/chat";

const authApi = axios.create({
    baseURL: API_URL,
    headers: {
        "Content-Type": "application/json",
    },
});

const chatApi = axios.create({
    baseURL: CHAT_URL,
    headers: {
        "Content-Type": "application/json",
    },
});

authApi.interceptors.request.use((config) => {
    const token = localStorage.getItem("token");
    if (token) {
        config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
});

export { authApi, chatApi };
