// import apiService from '@/services/apiService';

export default {
  state: {
    dummyShopItems: [],
  },
  getters: {
    dummyShopItems: (state) => state.dummyShopItems,
  },
  actions: {
    async fetch_items({ commit }) {
      commit('updatedummyShopItems', [
        {
          ProductId: 1,
          ProductTitle: 'Product 1',
          ProductDescription: 'This is a test description',
          ProductPrice: 250,
          ProductStock: 7,
          ProductBought: 373,
          ProductDiscount: 5,
        },
        {
          ProductId: 2,
          ProductTitle: 'Product 2',
          ProductDescription: 'This is a test description',
          ProductPrice: 225,
          ProductStock: 2,
          ProductBought: 255,
          ProductDiscount: 7.5,
        },
        {
          ProductId: 3,
          ProductTitle: 'Product 3',
          ProductDescription: 'This is a test description',
          ProductPrice: 5551,
          ProductStock: 3,
          ProductBought: 358,
          ProductDiscount: 10,
        },
        {
          ProductId: 4,
          ProductTitle: 'Product 4',
          ProductDescription: 'This is a test description',
          ProductPrice: 1932,
          ProductStock: 543,
          ProductBought: 213,
          ProductDiscount: 15,
        },
        {
          ProductId: 5,
          ProductTitle: 'Product 5',
          ProductDescription: 'This is a test description',
          ProductPrice: 250,
          ProductStock: 7,
          ProductBought: 623,
          ProductDiscount: 5,
        },
        {
          ProductId: 6,
          ProductTitle: 'Product 6',
          ProductDescription: 'This is a test description',
          ProductPrice: 225,
          ProductStock: 2,
          ProductBought: 663,
          ProductDiscount: 7.5,
        },
        {
          ProductId: 7,
          ProductTitle: 'Product 7',
          ProductDescription: 'This is a test description',
          ProductPrice: 5551,
          ProductStock: 3,
          ProductBought: 501,
          ProductDiscount: 10,
        },
        {
          ProductId: 8,
          ProductTitle: 'Product 8',
          ProductDescription: 'This is a test description',
          ProductPrice: 1932,
          ProductStock: 543,
          ProductBought: 772,
          ProductDiscount: 15,
        },
        {
          ProductId: 9,
          ProductTitle: 'Product 9',
          ProductDescription: 'This is a test description',
          ProductPrice: 250,
          ProductStock: 7,
          ProductBought: 824,
          ProductDiscount: 5,
        },
        {
          ProductId: 10,
          ProductTitle: 'Product 10',
          ProductDescription: 'This is a test description',
          ProductPrice: 225,
          ProductStock: 2,
          ProductBought: 627,
          ProductDiscount: 7.5,
        },
        {
          ProductId: 11,
          ProductTitle: 'Product 11',
          ProductDescription: 'This is a test description',
          ProductPrice: 5551,
          ProductStock: 3,
          ProductBought: 893,
          ProductDiscount: 10,
        },
        {
          ProductId: 12,
          ProductTitle: 'Product 12',
          ProductDescription: 'This is a test description',
          ProductPrice: 1932,
          ProductStock: 543,
          ProductBought: 912,
          ProductDiscount: 15,
        },
      ]);
      return true;
    },
  },
  mutations: {
    updatedummyShopItems: (state, dummyShopItems) => {
      state.dummyShopItems = dummyShopItems;
    },
  },
};
