<template>
  <v-container fluid class="pa-0 px-md-4">
    <v-container class="pa-0">
      <v-row no-gutters class="py-md-0 py-5 pt-10 pb-md-10" align="center" justify="space-between">
        <v-col class="ma-0 pb-0 pt-2" v-if="!$vuetify.breakpoint.xs">
          <div class="d-flex justify-space-between align-center ml-3">
            <h1 class="text-xl-h3">Webshop</h1>
            <div class="d-flex ml-3">
              <v-btn x-large tile text depressed :to="{ path: '/' }" class="black--text text-xl-h5 font-weight-medium" exact-path>Home</v-btn>
              <v-btn x-large tile text depressed :to="{ name: 'products' }" class="black--text text-xl-h5 font-weight-medium" exact-path>Products</v-btn>
            </div>
            <div class="ml-auto d-flex">
              <!-- <div v-if="!cartItems.length"> -->
              <div>
                <v-btn x-large icon depressed @click="$store.commit('setCartState', true)">
                  <v-icon :size="iconSizing() == true ? '50px' : '30'" color="black font-weight-bold">mdi-cart-outline</v-icon>
                </v-btn>
              </div>
              <v-menu offset-y bottom left>
                <template v-slot:activator="{ on, attrs }">
                  <v-btn x-large title="Info" icon v-bind="attrs" v-on="on">
                    <v-icon :size="iconSizing() == true ? '50px' : '30'" :color="user ? 'primary' : 'secondary'">mdi-account-circle</v-icon>
                  </v-btn>
                </template>
                <v-card>
                  <v-card-text>
                    <user-menu @show-login="showLoginDialog = true" />
                  </v-card-text>
                </v-card>
              </v-menu>
            </div>
          </div>
          <v-divider />
          <v-divider />
        </v-col>
        <v-col v-else class="text-right">
          <div class="d-flex justify-space-between align-center ml-3">
            <h1>Webshop</h1>
            <v-menu transition="slide-y-transition" offset-y bottom>
              <template v-slot:activator="{ on, attrs }">
                <v-btn large v-bind="attrs" v-on="on" icon><v-icon large color="black">mdi-menu</v-icon></v-btn>
              </template>
              <v-card>
                <v-list>
                  <v-list-item :to="{ name: 'home' }" exact>
                    <v-list-item-title>Home</v-list-item-title>
                  </v-list-item>
                  <v-list-item :to="{ name: 'products' }" exact>
                    <v-list-item-title>Products</v-list-item-title>
                  </v-list-item>
                  <!-- <v-list-item v-if="!cartItems.length" @click="$store.commit('setCartState', true)"> -->
                  <v-list-item @click="$store.commit('setCartState', true)">
                    <v-list-item-title>Cart</v-list-item-title>
                  </v-list-item>
                </v-list>
                <v-divider></v-divider>
                <user-menu class="mt-2" @show-login="showLoginDialog = true" />
              </v-card>
            </v-menu>
          </div>
          <v-divider />
          <v-divider />
        </v-col>
      </v-row>
    </v-container>
    <v-dialog v-model="showLoginDialog" width="500">
      <login @hide-login="showLoginDialog = false" />
    </v-dialog>
  </v-container>
</template>

<script>
import { mapGetters } from 'vuex';
import UserMenu from './UserMenu.vue';
import Login from './Login.vue';

export default {
  components: { UserMenu, Login },
  computed: {
    // ...mapGetters(['cartItems', 'user']),
    ...mapGetters(['user']),
  },
  data: () => ({
    showLoginDialog: false,
  }),
  methods: {
    iconSizing() {
      return this.$vuetify.breakpoint.xl;
    },
  },
  created() {
  },
};
</script>

<style></style>
