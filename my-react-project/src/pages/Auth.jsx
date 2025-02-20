import React, { useState } from "react";
import { Form, Input, Button, Card, message } from "antd";
import { authApi as api} from "../api/api";
import { useNavigate } from "react-router-dom";

const Auth = () => {
    const [isRegister, setIsRegister] = useState(false);
    const [loading, setLoading] = useState(false);
    const navigate = useNavigate();

    const handleSubmit = async (values) => {
        setLoading(true);
        try {
            if (isRegister) {
                await api.post("/register", values);
                message.success("Registration successful! Please login.");
                setIsRegister(false);
            } else {
                const response = await api.post("/login", values);
                localStorage.setItem("token", response.data.token);
                message.success("Login successful!");
                navigate("/chat");
            }
        } catch (error) {
            message.error("Operation failed. Try again.");
        } finally {
            setLoading(false);
        }
    };

    return (
        <div className="auth-container">
            <Card title={isRegister ? "Register" : "Login"} style={{ width: 400 }}>
                <Form layout="vertical" onFinish={handleSubmit}>
                    {isRegister && (
                        <Form.Item label="Name" name="name" rules={[{ required: true, message: "Enter your name" }]}>
                            <Input />
                        </Form.Item>
                    )}
                    <Form.Item label="Email" name="email" rules={[{ required: true, message: "Enter your email" }]}>
                        <Input />
                    </Form.Item>
                    <Form.Item label="Password" name="password" rules={[{ required: true, message: "Enter your password" }]}>
                        <Input.Password />
                    </Form.Item>
                    <Form.Item>
                        <Button type="primary" htmlType="submit" loading={loading} block>
                            {isRegister ? "Register" : "Login"}
                        </Button>
                    </Form.Item>
                </Form>
                <Button type="link" onClick={() => setIsRegister(!isRegister)}>
                    {isRegister ? "Already have an account? Login" : "Don't have an account? Register"}
                </Button>
            </Card>
        </div>
    );
};

export default Auth;
