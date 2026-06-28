import axiosClient from "./axiosClient";

export const register = async (registerData)=>{
    const response = await axiosClient.post("/auth/register",registerData);
    return response.data;
}

export const login = async (loginData)=>{
    const response = await axiosClient.post("/auth/login",loginData);
    return response.data;
}