import axiosClient from "./axiosClient";

export const getProfile = async ()=>{
    const response = await axiosClient.get("/profile");
    return response.data;
}

