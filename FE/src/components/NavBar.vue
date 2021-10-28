<template>
  <v-container fluid class="pa-0 pa-md-4 px-md-8">
    <v-container class="pa-0">
      <v-row no-gutters class="py-md-0 py-5 pt-10 pb-md-10" align="center" justify="space-between">
        <v-col cols="6" md="auto" class="mr-0 mr-md-6 pa-0 d-flex flex-row">
          <v-img width="5vw" src="@/assets/placeholder.jpg"></v-img>
        </v-col>
        <v-col class="ma-0 px-0 pb-0 pt-2" v-if="!$vuetify.breakpoint.smAndDown">
          <div class="d-flex justify-space-between align-center ml-3">
            <h1>Webshop</h1>
            <div class="d-flex ml-3">
              <v-btn :x-large="$vuetify.breakpoint.mdAndUp" tile text depressed :to="{ name: 'Home' }" class="black--text" exact-path>Forside</v-btn>
              <v-btn :x-large="$vuetify.breakpoint.mdAndUp" tile text depressed :to="{ name: 'Products' }" class="black--text" exact-path>Products</v-btn>
            </div>
            <div class="ml-auto d-flex">
              <div v-if="cartItems.length">
                <v-btn large icon depressed @click="$store.commit('setCartOpen', true)">
                  <v-icon color="black font-weight-bold">mdi-cart-outline</v-icon>
                </v-btn>
              </div>
              <v-menu offset-y bottom left>
                <template v-slot:activator="{ on, attrs }">
                  <v-btn large title="Info" icon v-bind="attrs" v-on="on" :color="user ? 'primary' : 'secondary'">
                    <v-icon>mdi-account-circle</v-icon>
                  </v-btn>
                </template>
                <v-card>
                  <v-card-text>
                    <user-menu @show-login="showLoginDialog = true" @show-password-change="showPasswordEditDialog = true" />
                  </v-card-text>
                </v-card>
              </v-menu>
            </div>
          </div>
          <v-divider />
          <v-divider />
        </v-col>
      </v-row>
    </v-container>
  </v-container>
</template>

<script>
import { mapGetters } from 'vuex';
// import login from "../components/modals/Login.vue";

export default {
  components: {},
  computed: {
    ...mapGetters(['cartItems']),
  },
  methods: {},
};
</script>

<style></style>
