export interface Options {
  value: string,
  viewValue: string
}

export class BuySellOptions {
  options: Options[] = [
    { value: 'Buy', viewValue: 'Buy' },
    { value: 'Buy at the open', viewValue: 'Buy at open' },
    { value: 'Buy at the close', viewValue: 'Buy at close' },
    { value: 'Set buy limit', viewValue: 'Set buy limit' },
    { value: 'Sell', viewValue: 'Sell' },
    { value: 'Sell at the open', viewValue: 'Sell at open' },
    { value: 'Sell at the close', viewValue: 'Sell at close' },
    { value: 'Set sell limit', viewValue: 'Set sell limit' }

  ]
};

export interface Details{
  value: string;
}

export class BuySellDetails {
  buy = "'Buy' means your are buying stock when there is enough sell volume to fill your request!";
  buyOpen = "'Buy at the open' means you will be buying at the beginning of the day when/if your order can be filled! Note that your order may not be filled if there is not enough volume!";
  buyClose = "'Buy at the close' means you will be buying at the end of the day when/if your order can be filled! Note that your order may not be filled if there is not enough volume!";
  buySet = "'Set buy limit' means that you are setting the price you are willing to buy and the quantity of stock entered will be bought up to that price if there is enough volume!"
  sell = "'Sell' means your are selling stock when there is enough buy volume to fill your request!";
  sellOpen = "'Sell at the open' means you will be selling at the beginning of the day when/if your order can be filled! Note that your order may not be filled if there is not enough volume!";
  sellClose = "'Sell at the close' means you will be selling at the end of the day when/if your order can be filled! Note that your order may not be filled if there is not enough volume!";
  sellSet = "'Set sell limit' means that you are setting the price you are willing to sell and the quantity of stock entered will be sold up to that price if there is enough volume!"
}
