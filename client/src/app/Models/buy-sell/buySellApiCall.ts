export interface callBuySellApi {
  tickerSymbol: string,
  price: number
}

export interface Buy {
  symbol: string,
  currentPrice: number,
  amountBought: number,
  price: number
}

export interface Sell {
  symbol: string,
  amount: number,
  price: number
}
