namespace BankAccount
{
    using System;

    using HolderService;

    /// <summary>
    /// Class for silver bank account.
    /// </summary>
    public class SilverBankAccount : AbstractBankAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SilverBankAccount"/> class.
        /// </summary>
        /// <param name="holder">
        /// Bank account holder.
        /// </param>
        /// <param name="accountNumber">
        /// Bank account number.
        /// </param>
        public SilverBankAccount(Holder holder, string accountNumber)
            : base(holder, accountNumber)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SilverBankAccount"/> class.
        /// </summary>
        /// <param name="accountNumber">
        /// Bank account number.
        /// </param>
        public SilverBankAccount(string accountNumber)
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
        protected override int CalculateBonusPoints(decimal amount) => 2 * (int)Math.Log10(decimal.ToDouble(amount));
    }
}