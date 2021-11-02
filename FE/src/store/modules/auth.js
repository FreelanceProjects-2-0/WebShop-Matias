// import apiService from '@/services/apiService';

export default {
  state: {
    authToken: null,
    user: null,
  },
  getters: {
    authToken: (state) => state.authToken,
    user: (state) => state.user,
  },
  actions: {
    fetchUserData({ commit }) {
      //   let response = this.state.user; // Change to API when made.
      commit('setUserData', { name: 'TestName' });
      commit('setAuthToken', 'response.data.authToken');
      localStorage.setItem('userData', { name: 'TestName' });
    },
  },
  mutations: {
    setUserData: (state, user) => {
      state.user = user;
    },
    setAuthToken: (state, authToken) => {
      state.authToken = authToken;
    },
  },
};
