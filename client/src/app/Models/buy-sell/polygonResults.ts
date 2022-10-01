// What is returned from Polygon.io when calling their api https://polygon.io/docs/stocks/get_v2_aggs_ticker__stocksticker__prev
export interface Results {
  ticker: string;
  close: number;
  high: number;
  low: number;
  open: number;
  marketCap: number;
  volume: number;
  volumeW: number;
}
