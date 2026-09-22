import axiosClient from "./axiosClient";

export const getProfile = async ()=>{
    const response = await axiosClient.get("/profile");
    return response.data;
}

export const updateProfile = async (profileData) => {
    const response = await axiosClient.put("/profile", profileData);
    return response.data;
}
