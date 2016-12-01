using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;

namespace HMServices.Models {
    [BsonIgnoreExtraElements]
    public class Filing {
        public ObjectId Id { get; set; }
        public string EntityRegistrantName {get; set; }
        public string CurrentFiscalYearEndDate { get; set; }
        public string EntityCentralIndexKey {get; set;}
        public string EntityFilerCategory { get; set; }
        public string TradingSymbol { get; set; }
        public string DocumentPeriodEndDate { get; set; }
        public string DocumentFiscalYearFocus { get; set; }
        public string DocumentFiscalPeriodFocus { get ;set; }
        public string DocumentFiscalYearFocusContext { get; set; }
        public string DocumentFiscalPeriodFocusContext { get; set; }
        public string DocumentType { get; set; }
        public string BalanceSheetDate { get; set; }
        public string IncomeStatementPeriodYTD { get; set; }
        public string ContextForInstants { get; set; }
        public string ContextForDurations { get; set; }
        public decimal Assets { get; set; }
        public decimal CurrentAssets { get; set; }
        public decimal NoncurrentAssets { get; set; }
        public decimal LiabilitiesAndEquity { get; set; }
        public decimal Liabilities { get; set; }
        public decimal CurrentLiabilities { get; set; }
        public decimal NoncurrentLiabilities { get; set; }
        public decimal CommitmentsAndContingencies { get; set; }
        public decimal TemporaryEquity { get; set; }
        public decimal Equity { get; set; }
        public decimal EquityAttributableToNoncontrollingInterest { get; set; }
        public decimal EquityAttributableToParent { get; set; }
        public decimal Revenues { get; set; }
        public decimal CostOfRevenue { get; set; }
        public decimal GrossProfit { get; set; }
        public decimal OperatingExpenses { get; set; }
        public decimal CostsAndExpenses { get; set; }
        public decimal OtherOperatingIncome { get; set; }
        public decimal OperatingIncomeLoss { get; set; }
        public decimal NonoperatingIncomeLoss { get; set; }
        public decimal InterestAndDebtExpense { get; set; }
        public decimal IncomeBeforeEquityMethodInvestments { get; set; }
        public decimal IncomeFromEquityMethodInvestments { get; set; }
        public decimal IncomeFromContinuingOperationsBeforeTax { get; set; }
        public decimal IncomeTaxExpenseBenefit { get; set; }
        public decimal IncomeFromContinuingOperationsAfterTax { get; set; }
        public decimal IncomeFromDiscontinuedOperations { get; set; }
        public decimal ExtraordaryItemsGainLoss { get; set; }
        public decimal NetIncomeLoss { get; set; }
        public decimal NetIncomeAvailableToCommonStockholdersBasic { get; set; }
        public decimal PreferredStockDividendsAndOtherAdjustments { get; set; }
        public decimal NetIncomeAttributableToNoncontrollingInterest { get; set; }
        public decimal NetIncomeAttributableToParent { get; set; }
        public decimal OtherComprehensiveIncome { get; set; }
        public decimal ComprehensiveIncome { get; set; }
        public decimal ComprehensiveIncomeAttributableToParent { get; set; }
        public decimal ComprehensiveIncomeAttributableToNoncontrollingInterest { get; set; }
        public decimal NonoperatingIncomeLossPlusInterestAndDebtExpense { get; set; }
        public decimal NonoperatingIncomePlusInterestAndDebtExpensePlusIncomeFromEquityMethodInvestments { get; set; }
        public decimal NetCashFlow { get; set; }
        public decimal NetCashFlowsOperating { get; set; }
        public decimal NetCashFlowsInvesting { get; set; }
        public decimal NetCashFlowsFinancing { get; set; }
        public decimal NetCashFlowsOperatingContinuing { get; set; }
        public decimal NetCashFlowsInvestingContinuing { get; set; }
        public decimal NetCashFlowsFinancingContinuing { get; set; }
        public decimal NetCashFlowsOperatingDiscontinued { get; set; }
        public decimal NetCashFlowsInvestingDiscontinued { get; set; }
        public decimal NetCashFlowsFinancingDiscontinued { get; set; }
        public decimal NetCashFlowsDiscontinued { get; set; }
        public decimal ExchangeGainsLosses { get; set; }
        public decimal NetCashFlowsContinuing { get; set; }
        public double SGR { get; set; }
        public double ROA { get; set; }
        public double ROE { get; set; }
        public double ROS { get; set; }
        public string htmlURL { get; set; }
        public string zipURL { get; set; }
        public DateTime dateFiled { get; set; }
    }
}