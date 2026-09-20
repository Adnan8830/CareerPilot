import { NavLink, Outlet } from "react-router-dom";
import { useState } from "react";
import "./MainLayout.css";

function MainLayout() {
  const [isSidebarOpen, setIsSidebarOpen] = useState(false);
  return (
    <div className="app-layout">
      <aside className={`sidebar ${isSidebarOpen ? "open" : "collapsed"}`}>
        <button onClick={()=>setIsSidebarOpen(!isSidebarOpen)}>
          {isSidebarOpen ? "«" : "»"} 
        </button>
        {isSidebarOpen && <h1>CareerPilot</h1>}
        <nav>
          <NavLink
            to="/dashboard"
            className={({ isActive }) => (isActive ? "active" : "")}
          >
            {isSidebarOpen ? "Dashboard" : "🏠"}
          </NavLink>

          <NavLink
            to="/profile"
            className={({ isActive }) => (isActive ? "active" : "")}
          >
            {isSidebarOpen ? "Profile" : "👤"}
          </NavLink>

          <NavLink
            to="/resumes"
            className={({ isActive }) => (isActive ? "active" : "")}
          >
            {isSidebarOpen ? "Resumes" : "📄"}
          </NavLink>

          <NavLink
            to="/applications"
            className={({ isActive }) => (isActive ? "active" : "")}
          >
            {isSidebarOpen ? "Applications" : "📝"}
          </NavLink>

          <NavLink
            to="/interviews"
            className={({ isActive }) => (isActive ? "active" : "")}
          >
            {isSidebarOpen ? "Interviews" : "🎤"}
          </NavLink>

          <NavLink
            to="/settings"
            className={({ isActive }) => (isActive ? "active" : "")}
          >
            {isSidebarOpen ? "Settings" : "⚙️"}
          </NavLink>
        </nav>
      </aside>

      <main className="main-content">
        <Outlet />
      </main>
    </div>
  );
}

export default MainLayout;
