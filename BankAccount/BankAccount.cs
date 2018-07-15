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

        /// <summary>
        /// International bank account number.
        /// </summary>
        private string number;

        /// <summary>
        /// Gets the bonus points percent based on account status.
        /// </summary>
        private double bonusPointsPercent;

        /// <summary>
        /// Bank account status.
        /// </summary>
        private BankAccountStatus status;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccount"/> class.
        /// </summary>
        /// <param name="holder">
        /// Bank account holder.
        /// </param>
        /// <param name="accountNumber">
        /// Bank account number.
        /// </param>
        /// <param name="status">
        /// Bank account status.
        /// </param>
        public BankAccount(Holder holder, string accountNumber, BankAccountStatus status)
        {
            this.Holder = holder;
            this.Number = accountNumber;
            this.Status = status;

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
        public Holder Holder { get; set; }

        /// <summary>
        /// Gets this bank account number.
        /// Bank account number is 28 digits and letters.
        /// </summary>
        public string Number
        {
            get => this.number;

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

                this.number = value;
            }
        }

        /// <summary>
        /// Gets or sets this bank account maximum withdraw amount.
        /// </summary>
        public decimal MaxWithdraw { get; set; }

        /// <summary>
        /// Gets or sets the bank account status based on accounts BonusPoints.
        /// </summary>
        public BankAccountStatus Status
        {
            get => this.status;
            set
            {
                this.status = value;
                this.SetBonusPointsPercent();
            }
        }

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
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Deposit amount can not be less or equal to zero.");
            }

            if (!HaveMoreThanTwoDecimalPlaces(amount))
            {
                throw new ArgumentException("Amount must have two decimal places.", nameof(amount));
            }

            this.Balance += amount;
            this.BonusPoints += (int)((double)amount * this.bonusPointsPercent);
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
            this.BonusPoints -= (int)((double)amount * this.bonusPointsPercent);
        }
        
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

        /// <summary>
        /// Sets bonus points percent based on account status.
        /// </summary>
        private void SetBonusPointsPercent()
        {
            switch (this.Status)
            {
                case BankAccountStatus.Base:
                    this.bonusPointsPercent = 0.01;
                    break;

                case BankAccountStatus.Silver:
                    this.bonusPointsPercent = 0.03;
                    break;

                case BankAccountStatus.Gold:
                    this.bonusPointsPercent = 0.05;
                    break;

                case BankAccountStatus.Platinum:
                    this.bonusPointsPercent = 0.07;
                    break;
            }
        }

        #endregion
    }
}
