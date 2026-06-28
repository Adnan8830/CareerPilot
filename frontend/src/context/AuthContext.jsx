import { createContext, useState } from "react";
import { login as loginApi } from "../api/authApi";

export const AuthContext = createContext();

export function AuthProvider({ children }) {
  const [user, setUser] = useState(null);
  const [token, setToken] = useState(localStorage.getItem("token"));

  const login = async (loginData) => {
    const response = await loginApi(loginData);
    localStorage.setItem("token", response.token);
    setToken(response.token);
  };

  const logout = () => {
    localStorage.removeItem("token");
    setToken(null);
  };
  return (
    <AuthContext.Provider value={{ user, token, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
}
