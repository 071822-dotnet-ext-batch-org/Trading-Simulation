export interface Portfolio {
    portfolioID: string;
    fk_UserID: string;
    name: string;
    privacyLevel: number;
    type: number;
    originalLiquid: number;
    currentInvestment: number;
    liquid: number;
    currentTotal: number;
    symbols: number;
    totalPNL: number;
    dateCreated: Date;
    dateModified: Date;
}