import axios from 'axios';


const axiosClient = axios.create({
    baseURL:"https://localhost:7282/api",
    headers:{
        "Content-Type":"application/json"
    },
    withCredentials:true
});


export default axiosClient;