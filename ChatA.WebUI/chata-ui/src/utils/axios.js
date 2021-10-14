import axios from "axios";

const axiosInstance = axios.create();

axiosInstance.interceptors.request.use(
    async request => {
        request.headers['Authorization'] = 'Bearer ' + localStorage.getItem('token');
        return request;
    },
    error =>{
        return Promise.reject(error);
    }
);

export default axiosInstance;