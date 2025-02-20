import React, { useState } from "react";
import { Form, Input, Button, message, Card } from "antd";
import { useNavigate } from "react-router-dom";
import { authApi as api} from "../api/api";

const Register = () => {
    const [loading, setLoading] = useState(false);
    const navigate = useNavigate();

    const handleRegister = async (values) => {
        setLoading(true);
        try {
            await api.post("/register", values);
            message.success("Registration successful! Please login.");
            navigate("/login");
        } catch (err) {
            message.error("Registration failed. Try again.");
        } finally {
            setLoading(false);
        }
    };

    return (
        <div className="auth-container">
            <Card title="Register" style={{ width: 400 }}>
                <Form layout="vertical" onFinish={handleRegister}>
                    <Form.Item label="Name" name="name" rules={[{ required: true, message: "Please enter your name" }]}>
                        <Input />
                    </Form.Item>
                    <Form.Item label="Email" name="email" rules={[{ required: true, message: "Please enter your email" }]}>
                        <Input />
                    </Form.Item>
                    <Form.Item label="Password" name="password" rules={[{ required: true, message: "Please enter your password" }]}>
                        <Input.Password />
                    </Form.Item>
                    <Form.Item>
                        <Button type="primary" htmlType="submit" loading={loading} block>
                            Register
                        </Button>
                    </Form.Item>
                </Form>
            </Card>
        </div>
    );
};

export default Register;
