namespace BankAccount
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Class for saving bank account info.
    /// </summary>
    public abstract class AbstractBankAccount
    {
        #region Private fields

        /// <summary>
        /// Bank account number.
        /// </summary>
        private string number;

        /// <summary>
        /// The upper limit for a single withdraw.
        /// </summary>
        private decimal maxWithdraw;

        /// <summary>
        /// This bank account's holder.
        /// </summary>
        private Holder holder;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractBankAccount"/> class.
        /// </summary>
        /// <param name="holder">
        /// Bank account holder.
        /// </param>
        /// <param name="accountNumber">
        /// Bank account number.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <see cref="holder"/> if <see cref="accountNumber"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if <see cref="accountNumber"/> does not consist of only digits and uppercase latin letters.
        /// </exception>
        protected AbstractBankAccount(Holder holder, string accountNumber)
        {
            this.Holder = holder;
            this.Number = accountNumber;

            this.Status = BankAccountStatus.Open;

            this.MaxWithdraw = 200;
        }

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
        /// <exception cref="ArgumentNullException">
        /// Thrown if passed value was null.
        /// </exception>
        public Holder Holder
        {
            get => this.holder;
            set
            {
                if (this.Holder == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this.holder = value;
            } 
        }

        /// <summary>
        /// Gets this bank account number.
        /// Bank account number must consist of only digits and letters.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Thrown if passed value is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if passed value does not consist of only digits and uppercase latin letters.
        /// </exception>
        public string Number
        {
            get => this.number;

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                const string PATTERN = @"^[\d|A-Z]*$";
                var regex = new Regex(PATTERN);
                if (!regex.IsMatch(value))
                {
                    throw new ArgumentException("Bank account number must contain only digits and uppercase latin letters.");
                }

                this.number = value;
            }
        }

        /// <summary>
        /// Gets or sets this bank account maximum withdraw amount.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if passed value &lt;= 0.
        /// </exception>
        public decimal MaxWithdraw
        {
            get => this.maxWithdraw;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Maximum withdraw can not be <= 0.");
                }

                this.maxWithdraw = value;
            }
        }

        /// <summary>
        /// Gets or sets the bank account status.
        /// </summary>
        public BankAccountStatus Status { get; set; }
         
        #endregion

        #region Public methods

        /// <summary>
        /// Add money to this bank account.
        /// </summary>
        /// <param name="amount">
        /// The amount to add.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if amount &lt;= 0.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if amount have more than two decimal places.
        /// </exception>
        public void Deposit(decimal amount)
        {
            if (this.Status != BankAccountStatus.Open)
            {
                var exception = new InvalidOperationException($"Can not perform {nameof(this.Deposit)} operation.");
                exception.Data["accountStatus"] = this.Status;
            }

            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Deposit amount can not be less or equal to zero.");
            }

            if (!HaveMoreThanTwoDecimalPlaces(amount))
            {
                throw new ArgumentException("Amount must have two decimal places.", nameof(amount));
            }

            this.Balance += amount;
            this.BonusPoints += this.CalculateBonusPoints(amount);
        }

        /// <summary>
        /// Withdraw money from this bank account.
        /// </summary>
        /// <param name="amount">
        /// The amount to withdraw.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if amount &lt;= 0;
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if amount &gt; this account's max withdraw or amount &gt; this account's balance.
        /// </exception>
        public void Withdraw(decimal amount)
        {
            if (this.Status != BankAccountStatus.Open)
            {
                var exception = new InvalidOperationException($"Can not perform {nameof(this.Withdraw)} operation.");
                exception.Data["accountStatus"] = this.Status;
            }

            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Deposit amount can not be less or equal to zero.");
            }

            if (amount > this.MaxWithdraw)
            {
                throw new ArgumentException($"Can not withdraw more than {nameof(this.MaxWithdraw)}.");
            }

            if (amount > this.Balance)
            {
                throw new ArgumentException($"Can not withdraw more than {nameof(this.Balance)}.");
            }

            this.Balance -= amount;
            this.BonusPoints -= this.CalculateBonusPoints(amount);
        }

        #endregion

        #region Protected methods

        /// <summary>
        /// Calculates bonus points based on money amount.
        /// </summary>
        /// <param name="amount">
        /// Amount of money that were withdrawn or deposit on current account.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        protected abstract int CalculateBonusPoints(decimal amount);

        #endregion

        #region Private helpers

        /// <summary>
        /// Checks if passed decimal value have more than two decimal places.
        /// </summary>
        /// <param name="value">
        /// Value that needs to be checked.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// True of number have more than two decimal places, false otherwise.
        /// </returns>
        private static bool HaveMoreThanTwoDecimalPlaces(decimal value) => decimal.Round(value, 2) == value;

        #endregion
    }
}
