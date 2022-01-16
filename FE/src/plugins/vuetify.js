import Vue from "vue";
import Vuetify from "vuetify/lib/framework";

Vue.use(Vuetify);

export default new Vuetify({
    theme: {
        themes: {
            light: {
                primary: '#FFF',
                secondary: '#7A7A7A',
                button: '#0067BF',
            },
            dark: {
                primary: '#000',
                secondary: '#464646',
                button: '#0067BF',
            }
        },
    },
});
