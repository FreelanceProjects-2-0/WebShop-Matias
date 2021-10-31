<template>
  <v-app>
    <v-container class="px-10">
      <NavBar />
      <v-snackbar v-if="snackbar" v-model="snackbar.show" :color="snackbar.color" class="mt-4 pa-4" bottom right transition="fade-transition" :timeout="parseInt(snackbar.timeout)">
        <h3 class="black--text py-2">{{ snackbar.title }}</h3>
        <h4 class="black--text py2-">{{ snackbar.message }}</h4>
        <template v-slot:action="{ attrs }">
          <v-btn color="black" text v-bind="attrs" @click="snackbar.show = false">Close </v-btn>
        </template>
      </v-snackbar>
      <v-main>
        <router-view />
      </v-main>
    </v-container>
  </v-app>
</template>

<script>
import NavBar from '@/components/NavBar';
import { mapState } from 'vuex';

export default {
  name: 'App',
  computed: {
    ...mapState({
      snackbar: (state) => state.globalSnackbar,
    }),
  },
  components: { NavBar },

  data: () => ({
    //
  }),
};
</script>
