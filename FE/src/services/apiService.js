import axios from 'axios';

const service = {
    api: process.env.VUE_APP_API_URL,
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
    },

    //Auth
    login(credentials){
        return this.post('auth/login', credentials);
    },
    getUserData(id){
        return this.get(`user/${id}`);
    },

    // Items
    getShopItems(){
        return this.get('shop/shopitem');
    },
    addShopItem(shopItem){
        return this.put('shop/shopitem', shopItem)
    }
    // const shopItem = {
    //     "Title": "Product Test",
    //     "Description": "This is a test description",
    //     "Price" : 22,
    //     "Stock" : 723,
    //     "Bought" : 4,
    //     "Discount" : 51
    //   }
};

export default service;