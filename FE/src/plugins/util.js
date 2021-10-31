const util = {
    stockNumberColor(number){
        if (number <= 5){
            return 'red--text';
        }
        if (number <= 10){
            return 'orange--text';
        }
        return 'black--text';
    },
};

export default util;