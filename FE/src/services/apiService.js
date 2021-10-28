import axios from 'axios';

const service = {
    api: '',
    post(endpoint, payload){
        return axios.post(`${this.api}/${endpoint}`, payload);
    },
    get(endpoint, payload){
        return axios.get(`${this.api}/${endpoint}`, payload);
    },
    put(endpoint, payload){
        return axios.put(`${this.api}/${endpoint}`, payload);
    },
    delete(endpoint, payload){
        return axios.delete(`${this.api}/${endpoint}`, payload);
    }
};

export default service;