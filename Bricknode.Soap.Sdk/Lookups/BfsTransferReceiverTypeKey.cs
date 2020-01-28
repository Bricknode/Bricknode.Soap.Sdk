namespace Bricknode.Soap.Sdk.Lookups
{
    /// <summary>
    /// This is the types of transfer receivers that are supported in BFS.
    /// </summary>
    public class BfsTransferReceiverTypeKey
    {
        /// <summary>
        /// This transfer receiver type is used for AutoGiro payments in Sweden.
        /// </summary>
        public const string AutoGiro = "TransferReceiverTypeAutoGiro";
        /// <summary>
        /// This transfer receiver type is used for BankGiro payments in Sweden.
        /// </summary>
        public const string BankGiro = "TransferReceiverTypeBankGiro";
        /// <summary>
        /// This transfer receiver type is used for making direct bank payment within the country of where you are located.
        /// </summary>
        public const string DirectBankDomestic = "TransferReceiverTypeDirectBankDomestic";
        /// <summary>
        /// This transfer receiver type is used for making direct bank payment outside the country of where you are located.
        /// </summary>
        public const string DirectBankForeign = "TransferReceiverTypeDirectBankForeign";
        /// <summary>
        /// This transfer receiver type is used for PlusGiro payments in Sweden.
        /// </summary>
        public const string PlusGiro = "TransferReceiverTypePlusGiro";
        /// <summary>
        /// This transfer receiver type is used for transferring financial securities.
        /// </summary>
        public const string Securities = "TransferReceiverTypeSecurities";
        /// <summary>
        /// This transfer receiver type is used to represent an account with EuroClear or other clearing agency.
        /// </summary>
        public const string SecuritiesAccount = "TransferReceiverTypeSecuritiesAccount";
        /// <summary>
        /// This transfer receiver type is used to represent an account with a settlement counterparty. For example, if a legal entity
        /// has an account with a brokerage firm that can receive securities and the securities are to be sent to a clearing agency like EuroClear
        /// the brokerage firm will have an account with EuroClear and that account is the SettlementCounterparty.
        /// </summary>
        public const string SettlementCounterparty = "TransferReceiverTypeSettlementCounterParty";
    }
}