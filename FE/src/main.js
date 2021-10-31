// import axios from 'axios';
import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import vuetify from "./plugins/vuetify";
import util from '@/plugins/util';

Vue.config.productionTip = false;

Object.defineProperty(Vue.prototype, '$util', {value: util});

new Vue({
  router,
  store,
  vuetify,
  util,
  render: (h) => h(App),
}).$mount("#app");
