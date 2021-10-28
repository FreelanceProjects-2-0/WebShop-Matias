import apiService from '@/services/apiService';

export default {
    state: {
        shopItems: [],
        cartIsOpen: false,
        userData: [],
        cartProductIds: [],
        orderInformation: [],
    },
    getters: {
        shopItems: (state) => state.shopItems,
        cartItems: (state) => state.cartProductIds.map((x) => state.items.find(y => y.id === x)),
        cartProductIds: (state) => state.cartProductIds,
        cartIsOpen: (state) => state.cartIsOpen,
        userData: (state) => state.userData,
        orderInformation: (state) => state.orderInformation,
    },
    actions: {
        async fetch_items({commit, dispatch}) {
            const response = await apiService.shopItemsRequest();
            commit('updateShopItems', response.data);
            dispatch('try_cached_order');
            return true;
        },
        try_cached_order({commit}) {
            const orderInformation = localStorage.getItem('orderInformation');
            const cartItems = localStorage.getItem('cartItems');
            
            if (orderInformation){
                commit('updateOrderInformation', JSON.parse(orderInformation));
            }
            if (cartItems){
                commit('setCartItems', JSON.parse(cartItems));
            }
        },
    },
    mutations: {
        setCartState: (state, isOpen) => {
            state.cartIsOpen = isOpen;
        },
        updateShopItems: (state, shopItems) => {
            state.shopItems = shopItems;
            state.itemsFetched = true;
        },
    },
}