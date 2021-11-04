<template>
  <v-container fluid>
    <h1 v-if="errorMessage">{{ errorMessage }}</h1>
    <v-row no-gutters v-else>
      <v-col cols="12" v-for="(item, index) in productList" :key="index" class="mb-2 px-4 text-left">
        <v-card class="d-flex flex-column" style="height: 100%">
          <v-row no-gutters>
            <v-col>
              <v-card-title>
                {{ item.ProductTitle }}
              </v-card-title>
              <v-card-subtitle class="text-xl-h5">
                <v-row no-gutters>
                  <v-col cols="9">
                    {{ item.ProductDescription + 'ajsdjioj diosa jdoias jdoiasjdoiajoidajoidjasoisaoi djia jdoias jdisa jdoas' }}
                  </v-col>
                  <v-col cols="3">
                    <div class="d-flex justify-end mt-0">
                      <v-img width="250px" src="@/assets/placeholder.jpg"></v-img>
                    </div>
                  </v-col>
                </v-row>
              </v-card-subtitle>
            </v-col>
            <v-card-text class="text-xl-h5 text-lg-h6 text-subtitle-1 black--text">
              <v-row no-gutters>
                <v-col>
                  <h4>Price&nbsp;</h4>
                  <h4>${{ $util.dicountCalculator(item.ProductPrice, item.ProductDiscount) }}</h4>
                  <h4 class="text-decoration-line-through grey--text">${{ item.ProductPrice }}</h4>
                </v-col>
                <v-col class="justify-end" cols="3">
                  <div class="d-flex justify-end" v-if="item.ProductStock <= 50">
                    <h4 :class="$util.stockNumberColor(item.ProductStock)">{{ item.ProductStock }}</h4>
                    <h4>&nbsp;Items in stock</h4>
                  </div>
                  <div class="d-flex justify-end">
                    <h4>{{ item.ProductBought }}</h4>
                    <h4>&nbsp;Items sold</h4>
                  </div>
                </v-col>
              </v-row>
            </v-card-text>
          </v-row>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
export default {
  data: () => ({
    productList: [],
    errorMessage: '',
  }),
  props: {
    data: Array,
  },
  created() {
    if (!this.data) {
      this.errorMessage = 'No products loaded...';
    } else {
      this.productList = this.data;
    }
  },
};
</script>

<style></style>
