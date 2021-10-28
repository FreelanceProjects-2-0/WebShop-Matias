import Vue from "vue";
import Vuex from "vuex";
import shop from './modules/shop';

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    globalSnackbar: null,},
  mutations: {
    SNACKBAR(state, alert){
      state.globalSnackbar = {
        show: true,
        timeout: 4000,
        ...alert
      };
    },
  },
  actions: {},
  modules: {
  shop,
  },
});
