export interface Investment {
    investmentID: string;
    fk_PortfolioID: string;
    symbol: string;
    amountInvested: number;
    currentAmount: number;
    currentPrice: number;
    totalAmountBought: number;
    totalAmountSold: number;
    averagedBuyPrice: number;
    totalPNL: number;
    dateCreated: Date;
    dateModified: Date;
}