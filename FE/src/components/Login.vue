<template>
  <v-form ref="loginForm" v-model="isValid" @submit="validate">
    <v-card>
      <v-card-title>Log ind</v-card-title>
      <v-card-text>
        <v-row no-gutters>
          <v-col cols="12" md="6" class="px-2">
            <v-text-field v-model.trim="username" :rules="[rules.required]" label="Brugernavn" @ />
          </v-col>
          <v-col cols="12" md="6" class="px-2">
            <v-text-field
              v-model="password"
              label="Kodeord"
              :append-icon="showPassword ? 'mdi-eye' : 'mdi-eye-off'"
              :rules="[rules.required]"
              :type="showPassword ? 'text' : 'password'"
              @click:append="showPassword = !showPassword"
            />
          </v-col>
        </v-row>
        <v-row no-gutters>
          <v-col>
            <v-alert type="error" v-if="errorMessage">
              {{ errorMessage }}
            </v-alert>
          </v-col>
        </v-row>
      </v-card-text>
      <v-card-actions>
        <v-col>
          <v-btn block depressed :disabled="!isValid" color="success" class="mr-4 mb-4" type="submit" :loading="isLoading"> Log ind </v-btn>
        </v-col>
      </v-card-actions>
    </v-card>
  </v-form>
</template>
<script>
import { mapGetters } from 'vuex';

export default {
  name: 'login',
  data: () => ({
    username: null,
    password: null,
    isValid: false,
    isLoading: false,
    showPassword: false,
    errorMessage: null,
    rules: {
      required: (value) => !!value || 'Du skal indtaste en værdi.',
    },
  }),
  computed: {
    ...mapGetters(['user']),
  },
  methods: {
    validate(e) {
      if (this.$refs.loginForm.validate()) {
        this.isLoading = true;
        this.$store
          .dispatch('AUTHENTICATE', { username: this.username, password: this.password })
          .then(() => {
            this.isLoading = false;
            this.$emit("hide-login");
            // this.$router.push({name:'frontPage'});
          })
          .catch(() => {
            this.isLoading = false;
            this.errorMessage = 'Fejl - du kunne ikke logges ind i systemet';
          });
      }
      // we need to do this in order to not actually submit the form (which will reload the site)
      e.preventDefault();
    },
    loginView() {
      this.forgotPasswordView = false;
      this.password = '';
    },
  },
};
</script>