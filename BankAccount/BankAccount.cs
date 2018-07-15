namespace BankAccount
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Class for saving bank account info.
    /// </summary>
    public sealed class BankAccount
    {
        #region Private fields

        private string _number;

        #endregion

        #region Propereties

        /// <summary>
        /// Gets the balance.
        /// </summary>
        public decimal Balance { get; private set; }

        /// <summary>
        /// Gets the bonus points.
        /// </summary>
        public int BonusPoints { get; private set; }

        /// <summary>
        /// Gets or sets the holder of this account.
        /// </summary>
        public Holder Holder { get; set; }

        /// <summary>
        /// Gets this bank account number.
        /// Bank account number is 28 digits and letters.
        /// </summary>
        public string Number
        {
            get => this._number;

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                const string PATTERN = @"^[\d|A-Z]{28}$";
                var regex = new Regex(PATTERN);
                if (!regex.IsMatch(value))
                {
                    throw new ArgumentException("Bank account number must be a 28 sybol long string that contains digits and uppercase letters.");
                }

                this._number = value;
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccount"/> class.
        /// </summary>
        /// <param name="holder">
        /// Bank account holder.
        /// </param>
        /// <param name="accountNumber">
        /// Bank account number.
        /// </param>
        public BankAccount(Holder holder, string accountNumber)
        {
            this.Holder = holder;
            this.Number = accountNumber;
        }
    }
}
