// Used in createBuy Service for our database original
export interface Buy {
  buyID: string;
  fk_portfolioID: string;
  symbol: string;
  currentPrice: number;
  amountBought: number;
  priceBought: number;
  dateBought: Date;
}

// Data transfer object for sending to database UPDATED!!!!!
export interface BuyDto {
  fk_portfolioID: string;
  symbol: string;
  amountBought: number;
  priceBought: number;
}

// Used in createSell service original
export interface Sell {
  sellID: string;
  fk_PortfolioID: string;
  symbol: string,
  amountSold: number,
  priceSold: number,
  dateSold: Date
}

// Data transfer object for sending to database UPDATED!!!!!
export interface SellDto {
  fk_PortfolioID: string;
  symbol: string;
  amountSold: number;
  priceSold: number;
}
