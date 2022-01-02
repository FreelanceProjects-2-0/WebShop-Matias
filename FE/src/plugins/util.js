const util = {
  stockNumberColor(number) {
    if (number <= 5) {
      return 'red--text';
    }
    if (number <= 10) {
      return 'orange--text';
    }
    return 'black--text';
  },
  dicountCalculator(price, discountPercentage) {
    const priceAfterDiscount = price - (discountPercentage / 100) * price;
    return priceAfterDiscount;
  },
  calculateAverageSoldItems(items) {
    let averageSold;
    let timesRun = 0;
    items.forEach((element) => {
      averageSold = +element.bought;
      timesRun++;
    });
    averageSold = averageSold / timesRun;
    return averageSold;
  },
};

export default util;
