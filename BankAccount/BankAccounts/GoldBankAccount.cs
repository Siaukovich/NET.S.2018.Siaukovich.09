namespace BankAccount
{
    using System;

    using HolderService;

    /// <summary>
    /// Class for gold bank account.
    /// </summary>
    public class GoldBankAccount : AbstractBankAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GoldBankAccount"/> class.
        /// </summary>
        /// <param name="holder">
        /// Bank account holder.
        /// </param>
        /// <param name="accountNumber">
        /// Bank account number.
        /// </param>
        public GoldBankAccount(Holder holder, string accountNumber)
            : base(holder, accountNumber)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GoldBankAccount"/> class.
        /// </summary>
        /// <param name="accountNumber">
        /// Bank account number.
        /// </param>
        public GoldBankAccount(string accountNumber)
            : base(accountNumber)
        {
        }

        /// <summary>
        /// Calculates bonus points based on money amount.
        /// </summary>
        /// <param name="amount">
        /// Amount of money that were withdrawn or deposit on current account.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        protected override int CalculateBonusPoints(decimal amount) => 3 * (int)Math.Log10(decimal.ToDouble(amount));
    }
}