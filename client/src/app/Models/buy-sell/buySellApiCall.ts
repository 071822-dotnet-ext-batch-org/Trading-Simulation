export interface callBuySellApi {
  tickerSymbol: string,
  price: number
}

// Used in createBuy Service
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

// Used in createSell service
export interface Sell {
  sellID: string;
  fk_PortfolioID: string;
  symbol: string,
  amountSold: number,
  priceSold: number,
  dateSold: Date
}

export interface SellDto {
  fk_PortfolioID: string;
  symbol: string;
  amountSold: number;
  priceSold: number;
}
