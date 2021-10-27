import Vue from "vue";
import Vuex from "vuex";

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
  modules: {},
});
