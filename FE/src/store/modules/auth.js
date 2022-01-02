import apiService from '@/services/apiService';

export default {
  state: {
    authToken: null,
    user: null,
  },
  getters: {
    authToken: (state) => state.authToken,
    user: (state) => state.user,
    isAdmin: (state) => state.user?.roles.includes('admin'),
    
    // Is manager or admin
    isManager: (state) => (state.user?.roles.includes('manager') || state.user?.roles.includes('admin')),
  },
  actions: {
    async AUTHENTICATE({ commit }, credentials) {
      const response = await apiService.login(credentials);

      commit('setAuthToken', response.data.auth_token);
      commit('setUserData', response.data);
      localStorage.setItem('authToken', response.data.auth_token);
    },
    LOGOUT({ commit }) {
      localStorage.removeItem('authToken');
      commit('setAuthToken', null);
      commit('setUserData', null);
    }
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
