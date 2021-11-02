<template>
  <div>
    <div v-if="user" class="text-center">
      Logget ind som<br />
      <strong>{{ user.name }}</strong>
      <v-list class="text-left">
        <v-list-item v-if="$route.name !== 'Home'" :to="{ name: 'Home' }" exact>
          <v-list-item-content>
            <v-list-item-title> Til forsiden </v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item v-if="isAdmin" :to="{ name: 'Admin' }" exact>
          <v-list-item-content>
            <v-list-item-title> Administrer </v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list>
      <v-divider />
    </div>

    <v-list>
      <v-list-item v-if="user" @click="$emit('show-password-change')">
        <v-list-item-content>
          <v-list-item-title>
            <v-icon left>mdi-lock-reset</v-icon>
            Skift kodeord
          </v-list-item-title>
        </v-list-item-content>
      </v-list-item>
      <v-list-item v-if="user" @click="logout">
        <v-list-item-title>
          <v-icon left>mdi-logout</v-icon>
          Log ud
        </v-list-item-title>
      </v-list-item>
      <v-list-item v-else @click="$emit('show-login')">
        <v-list-item-title>
          <v-icon left>mdi-login</v-icon>
          Log ind
        </v-list-item-title>
      </v-list-item>
    </v-list>
  </div>
</template>
<script>
import { mapGetters } from 'vuex';

export default {
  name: 'user-menu',
  computed: {
    ...mapGetters(['user', 'isAdmin']),
  },
  methods: {
    logout() {
      this.$store.dispatch('LOGOUT');
      this.$router.push({ name: 'Home' });
    },
  },
  created() {
    this.$store.dispatch('fetchUserData');
  },
};
</script>
