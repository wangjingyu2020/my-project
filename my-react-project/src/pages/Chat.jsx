import React, { useState, useRef, useEffect } from "react";
import { Input, Card, List, Avatar, Layout } from "antd";
import { chatApi } from "../api/api";
import Navbar from "../components/Navbar";
import "../styles/Chat.css";


const { Content } = Layout;

const Chat = () => {
    const [messages, setMessages] = useState([]);
    const [input, setInput] = useState("");
    const messagesEndRef = useRef(null);

    const sendMessage = async () => {
        if (!input.trim()) return;

        const newMessages = [...messages, { role: "user", content: input }];
        setMessages(newMessages);
        setInput("");

        try {
            const response = await chatApi.get("/openai/talkwithgpt", {
                params: { prompt: input },
            });

            console.log(response);

            setMessages([...newMessages, { role: "bot", content: response.data || "No response." }]);
        } catch (error) {
            setMessages([...newMessages, { role: "bot", content: "Error fetching response." }]);
        }
    };

    // 使聊天框自动滚动到底部
    useEffect(() => {
        messagesEndRef.current?.scrollIntoView({ behavior: "smooth" });
    }, [messages]);

    return (
        <Layout className="chat-layout">
            <Navbar />
            <Content className="chat-content">
                <Card title="Chat with AI" className="chat-card">
                    <div className="chat-messages">
                        <List
                            dataSource={messages}
                            renderItem={(msg) => (
                                <List.Item className={`chat-message ${msg.role}`}>
                                    <List.Item.Meta
                                        avatar={<Avatar className="chat-avatar">{msg.role === "user" ? "U" : "AI"}</Avatar>}
                                        title={msg.role === "user" ? "You" : "AI"}
                                        description={msg.content}
                                    />
                                </List.Item>
                            )}
                        />
                        <div ref={messagesEndRef} />
                    </div>
                    <Input.Search
                        value={input}
                        onChange={(e) => setInput(e.target.value)}
                        onSearch={sendMessage}
                        enterButton="Send"
                        className="chat-input"
                    />
                </Card>
            </Content>
        </Layout>
    );
};

export default Chat;
