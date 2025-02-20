import React from "react";
import { Button } from "antd";
import { useNavigate } from "react-router-dom";
import { authApi as api} from "../api/api";

const Navbar = () => {
    const navigate = useNavigate();

    const handleLogout = async () => {
        try {
            await api.post("/logout");
            localStorage.removeItem("token");
            navigate("/");
        } catch (error) {
            console.error("Logout failed", error);
        }
    };

    return (
        <div className="navbar">
            <span style={{ color: "white", fontSize: "18px" }}>Chat App</span>
            <Button type="link" className="logout-button" onClick={handleLogout}>
                Logout
            </Button>
        </div>
    );
};

export default Navbar;
