import { Buy } from "./buy-sell/buySellApiCall";
import { Investment } from "./Investment";
import { Portfolio } from "./Portfolio";

export interface UpdatePrice {
    investments: Investment[];
    buys: Buy[];
    portfolios: Portfolio[];
}