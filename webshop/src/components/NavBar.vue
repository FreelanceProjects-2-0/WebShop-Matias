<template>
  <v-app-bar app color="primary">
    <v-row no-gutters v-if="!$vuetify.breakpoint.xs">
      <v-btn :x-large="$vuetify.breakpoint.mdAndUp" tile text depressed :to="{ name: 'Home' }" class="white--text" exact-path>Forside</v-btn>
      <v-btn :x-large="$vuetify.breakpoint.mdAndUp" tile text depressed :to="{ name: 'Movies' }" class="white--text" exact-path>Film</v-btn>
      <v-btn :x-large="$vuetify.breakpoint.mdAndUp" tile text depressed :to="{ name: 'Actors' }" class="white--text" exact-path>Skuespillere</v-btn>
      <v-btn :x-large="$vuetify.breakpoint.mdAndUp" tile text depressed :to="{ name: 'Directors' }" class="white--text" exact-path>Instruktøre</v-btn>
      <v-btn :x-large="$vuetify.breakpoint.mdAndUp" tile text depressed :to="{ name: 'Seats' }" class="white--text" exact-path>Booking</v-btn>
      <v-btn v-if="isAdmin" :x-large="$vuetify.breakpoint.mdAndUp" tile text depressed :to="{ name: 'Users' }" class="white--text" exact-path>Users (ADMIN)</v-btn>
      <div class="ml-auto">
        <v-btn v-if="user" :x-large="$vuetify.breakpoint.mdAndUp" tile text depressed @click="logout" class="white--text" exact-path>Log ud</v-btn>
        <v-btn v-if="!user" :x-large="$vuetify.breakpoint.mdAndUp" tile text depressed @click="login" class="white--text" exact-path>Log in</v-btn>
      </div>
    </v-row>
    <div v-if="$vuetify.breakpoint.xs">
      <v-menu bottom left>
        <template v-slot:activator="{ on, attrs }">
          <v-btn dark icon v-bind="attrs" v-on="on">
            <v-icon>mdi-menu </v-icon>
          </v-btn>
        </template>
        <v-list>
          <v-list-item>
            <v-btn block tile text depressed :to="{ name: 'Home' }" class="black--text" exact-path>Forside</v-btn>
          </v-list-item>
          <v-list-item>
            <v-btn block tile text depressed :to="{ name: 'Movies' }" class="black--text" exact-path>Film</v-btn>
          </v-list-item>
          <v-list-item>
            <v-btn block tile text depressed :to="{ name: 'Actors' }" class="black--text" exact-path>Skuespillere</v-btn>
          </v-list-item>
          <v-list-item>
            <v-btn block tile text depressed :to="{ name: 'Actors' }" class="black--text" exact-path>Instruktøre</v-btn>
          </v-list-item>
          <v-list-item>
            <v-btn block tile text depressed :to="{ name: 'Seats' }" class="black--text" exact-path>Booking</v-btn>
          </v-list-item>
          <!-- <v-list-item>
                        <v-btn
                            v-if="user"
                            block
                            tile
                            text
                            depressed
                            @click="logout"
                            >Log ud</v-btn
                        >
                        <v-btn
                            v-if="!user"
                            block
                            tile
                            text
                            depressed
                            @click="login"
                            >Log ind</v-btn
                        >
                    </v-list-item> -->
        </v-list>
      </v-menu>
    </div>
    <!-- <login ref="login" /> -->
  </v-app-bar>
</template>

<script>
// import { mapGetters } from 'vuex';
// import login from "../components/modals/Login.vue";

export default {
  components: {},
  computed: {
    // ...mapGetters(["isAdmin", "user"]),
  },
  methods: {},
};
</script>

<style></style>
