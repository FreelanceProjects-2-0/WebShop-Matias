// import axios from 'axios';
import Vue from "vue";
import VueI18n from 'vue-i18n';
import App from "./App.vue";
import router from "./router";
import store from "./store";
import vuetify from "./plugins/vuetify";
import util from '@/plugins/util';
import translations from '@/plugins/translations';

Vue.config.productionTip = false;

Vue.use(VueI18n);

Object.defineProperty(Vue.prototype, '$util', { value: util });

// Create VueI18n instance with options
const i18n = new VueI18n({
  locale: 'da', // set locale
  fallbackLocale: 'en', // set fallback language
  messages: translations, // set locale messages
});

new Vue({
  router,
  store,
  vuetify,
  util,
  i18n,
  render: (h) => h(App),
}).$mount("#app");
