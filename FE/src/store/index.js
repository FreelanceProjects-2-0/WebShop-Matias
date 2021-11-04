import Vue from 'vue';
import Vuex from 'vuex';
// import shop from './modules/shop';
import auth from './modules/auth';
import testData from './modules/testData';

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    globalSnackbar: null,
  },
  mutations: {
    SNACKBAR(state, alert) {
      state.globalSnackbar = {
        show: true,
        timeout: 4000,
        ...alert,
      };
    },
  },
  actions: {},
  modules: {
    // shop,
    auth,
    testData,
  },
});
