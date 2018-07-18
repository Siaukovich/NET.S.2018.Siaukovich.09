namespace BankAccount
{
    using System;

    using HolderService;

    /// <summary>
    /// Class for base bank account.
    /// </summary>
    public class BaseBankAccount : AbstractBankAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseBankAccount"/> class.
        /// </summary>
        /// <param name="holder">
        /// Bank account holder.
        /// </param>
        /// <param name="accountNumber">
        /// Bank account number.
        /// </param>
        public BaseBankAccount(Holder holder, string accountNumber)
            : base(holder, accountNumber)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseBankAccount"/> class.
        /// </summary>
        /// <param name="accountNumber">
        /// Bank account number.
        /// </param>
        public BaseBankAccount(string accountNumber)
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
        protected override int CalculateBonusPoints(decimal amount) => (int)Math.Log10(decimal.ToDouble(amount));
    }
}