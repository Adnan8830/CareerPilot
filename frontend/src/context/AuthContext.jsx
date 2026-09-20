  import { createContext, useState,useEffect } from "react";
  import { login as loginApi, getCurrentUser,logout as logoutApi } from "../api/authApi";

  export const AuthContext = createContext();

  export function AuthProvider({ children }) {
    const [user, setUser] = useState(null);
    const [isAuthenticated, setIsAuthenticated] = useState(false);
    const [isLoading, setIsLoading] = useState(true);



    useEffect(()=>{
      const checkAuth = async()=>{
        try{
          const currentUserData = await getCurrentUser();
          setUser(currentUserData);
          setIsAuthenticated(true);
        }catch(error){
          setUser(null);
          setIsAuthenticated(false);
        }finally{
          setIsLoading(false);
        }
      };
      checkAuth();
    },[]);


    const login = async (loginData) => {
      await loginApi(loginData);
      setIsAuthenticated(true);
    };

    const logout = async () => {
      await logoutApi();
      setUser(null); 
      setIsAuthenticated(false);
    };

    return (
      <AuthContext.Provider value={{ user, isAuthenticated, login, logout, isLoading }}>
        {children}
      </AuthContext.Provider>
    );
  }
