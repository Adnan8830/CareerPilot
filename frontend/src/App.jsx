import { Routes, Route } from "react-router-dom";
import LoginPage from "./pages/LoginPage.jsx";
import RegisterPage from "./pages/RegisterPage";
import DashboardPage from "./pages/DashboardPage";
import ProtectedRoute from "./components/ProtectedRoute.jsx";
import MainLayout from "./layouts/MainLayout.jsx";
import ProfilePage from "./pages/ProfilePage.jsx";
function App() {
  return (
    <Routes>
      <Route path="/" element={<LoginPage />} />
      <Route path="/register" element={<RegisterPage />} />
      <Route 
      element ={<ProtectedRoute><MainLayout /></ProtectedRoute>}
      >   
      <Route path="/dashboard" element={<DashboardPage />}/>
      <Route path="/profile" element={<ProfilePage/>}/>
      </Route>
    </Routes>
  );
}

export default App;
