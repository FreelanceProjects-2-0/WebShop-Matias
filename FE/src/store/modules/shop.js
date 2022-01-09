export default {
    state: {
        cartIsOpen: false,
        cartProductIds: [],
        orderInformation: [],
    },
    getters: {
        cartItems: (state) => state.cartProductIds.map((x) => state.items.find(y => y.id === x)),
        cartProductIds: (state) => state.cartProductIds,
        cartIsOpen: (state) => state.cartIsOpen,
        orderInformation: (state) => state.orderInformation,
    },
    actions: {
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
    },
}