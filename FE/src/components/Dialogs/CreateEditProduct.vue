<template>
  <v-dialog v-model="show" max-width="650">
    <v-card>
      <v-card-title>
        {{ isEditing ? 'Edit product: ' + _title : 'Add new product' }}
      </v-card-title>
      <div>
        <v-card-text>
          <v-text-field v-model="currentProduct.title" label="Title" />
          <v-text-field v-model="currentProduct.description" label="Description" />
          <v-text-field v-model="currentProduct.price" label="Price ($)" />
          <v-text-field v-model="currentProduct.stock" label="Stock" />
          <v-text-field v-model="currentProduct.bought" label="Bought" />
          <v-text-field v-model="currentProduct.discount" label="Discount (%)" />
        </v-card-text>
        <v-card-actions>
          <div class="ml-auto my-2">
            <v-btn class="mx-2" @click="cancel">Cancel</v-btn>
            <v-btn class="mx-2" color="success" @click="saveCurrentProduct">Save</v-btn>
          </div>
        </v-card-actions>
      </div>
      <!-- <div v-else>
        <v-card-text> NAI </v-card-text>
      </div> -->
    </v-card>
  </v-dialog>
</template>

<script>
import _ from 'lodash';
import apiService from '@/services/apiService.js';

export default {
  name: 'Create_Edit_Product',
  computed: {
    isEditing() {
      return this.currentProduct?.id ? true : false;
    },
  },
  data: () => ({
    _title: '',
    isLoading: false,
    show: false,
    currentProduct: {},
  }),
  methods: {
    createProduct() {
      this.show = true;
      this.currentProduct = {
        title: '',
        description: '',
        price: 0,
        Stock: 0,
        Bought: 0,
        Discount: 0,
      };
    },
    editProduct(product) {
      this.show = true;
      this.currentProduct = _.cloneDeep(product);
      this._title = this.currentProduct.title;
    },
    async saveCurrentProduct() {
      this.isLoading = true;
      await apiService
        .createOrEditShopItem(this.currentProduct)
        .then(() => {
          this.show = false;
          this.$emit('product-updated');
        })
        .finally(() => {
          this.isLoading = false;
        });
    },
    cancel() {
      this.show = false;
    },
  },
};
</script>

<style></style>
