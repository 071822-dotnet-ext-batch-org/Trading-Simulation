export interface callBuySellApi {
  tickerSymbol: string,
  price: number
}

export interface Buy {
  buyID: string;
  fk_portfolioID: string;
  symbol: string;
  currentPrice: number;
  amountBought: number;
  priceBought: number;
  dateBought: Date;
}

export interface BuyDto {
  fk_portfolioID: string;
  symbol: string;
  amountBought: number;
  priceBought: number;
}

export interface Sell {
  symbol: string,
  amount: number,
  price: number
}
