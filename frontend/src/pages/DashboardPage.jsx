import { useContext } from "react";
import { useNavigate } from "react-router-dom";
import { AuthContext } from "../context/AuthContext";
import "./Dashboard.css";

function DashboardPage() {
  const { logout } = useContext(AuthContext);
  const navigate = useNavigate();

  const handleLogout = () => {
    logout();
    navigate("/");
  };

  return (
    <div className="dashboard-container">
      <div className="dashboard-card">
        <h1>CareerPilot</h1>

        <h2>Welcome 👋</h2>

        <p>You have successfully logged in.</p>

        <p className="dashboard-info">
          Welcome to your career dashboard. Resume management and job tracking
          features will be available here.
        </p>

        <button className="btn-primary" onClick={handleLogout}>
          Logout
        </button>
      </div>
    </div>
  );
}

export default DashboardPage;
