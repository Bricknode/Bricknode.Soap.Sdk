namespace Bricknode.Soap.Sdk.Lookups
{
    public class BfsAccounType
    {
        /// <summary>
        ///     This type is used for legal entities that are companies and that should act as counterparties to trades.
        /// </summary>
        public const string CounterpartyAccount = "CounterpartyAccount";

        /// <summary>
        ///     This is the most standard of accounts and is a simple holding account that can hold any asset type in BFS
        /// </summary>
        public const string HoldingAccount = "HoldingAccount";

        /// <summary>
        ///     This account type is usually used for accounting transactions done on behalf of the house.
        /// </summary>
        public const string HouseAccountingAccount = "HouseAccountingAccount";

        /// <summary>
        ///     This is an account type that should only be owned by the house and mirrors an account keept outside of BFS and
        ///     works as a custody account.
        /// </summary>
        public const string HouseCustodyAccount = "HouseCustodyAccount";

        /// <summary>
        ///     This account type should only be created for the house and works as a standard holding account in BFS but that is
        ///     owned by the house.
        /// </summary>
        public const string HouseSystemAccount = "HouseSystemAccount";

        /// <summary>
        ///     This account type should be used for reflecting an account that has an insurance cover.
        /// </summary>
        public const string InsuranceAccount = "InsuranceAccount";

        /// <summary>
        ///     This account type is used for the Swedish account type called Investerings Spar Konto.
        /// </summary>
        public const string ISKAccount = "ISKAccount";

        /// <summary>
        ///     This account type is used for a legal entity that is a company and that is enabled to be an Issuer of financial
        ///     products.
        /// </summary>
        public const string IssuerAccount = "IssuerAccount";

        /// <summary>
        ///     This account type is used when a customer has an account that is only used for execution only and once a trade is
        ///     executed the asset is transferred out of BFS to the financial institution that is used for settlement for the
        ///     customer.
        /// </summary>
        public const string ExecutionAccount = "Kas_Account";
    }
}