export class TransactionInfo {
  symbol: string;
  tickPrice: number;
  quantity: number;
  date: Date;
  cost: number;

  constructor(data: any) {
    this.symbol = data.symbol.toUpperCase();
    this.tickPrice = data.tickPrice;
    this.quantity = data.quantity;
    this.date = new Date(data.date);
    this.cost = data.cost;
  }
}
