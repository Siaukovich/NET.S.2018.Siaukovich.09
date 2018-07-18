namespace BankAccount
{
    using System;
    using System.Text.RegularExpressions;

    using HolderService;

    /// <summary>
    /// Class for saving bank account info.
    /// </summary>
    public abstract class AbstractBankAccount : IEquatable<AbstractBankAccount>
    {
        #region Private fields

        /// <summary>
        /// Bank account number.
        /// </summary>
        private readonly string number;

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
        protected AbstractBankAccount(Holder holder, string accountNumber) : this(accountNumber)
        {
            this.Holder = holder;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractBankAccount"/> class.
        /// </summary>
        /// <param name="accountNumber">
        /// Bank account number.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <see cref="holder"/> if <see cref="accountNumber"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if <see cref="accountNumber"/> does not consist of only digits and uppercase latin letters.
        /// </exception>
        protected AbstractBankAccount(string accountNumber)
        {
            ThrowForInvalidAccountNumber();
            this.number = accountNumber;
            this.Status = BankAccountStatus.Open;

            this.MaxWithdraw = 200;

            void ThrowForInvalidAccountNumber()
            {
                if (string.IsNullOrEmpty(accountNumber))
                {
                    throw new ArgumentNullException(nameof(accountNumber));
                }

                const string PATTERN = @"^[\d|A-Z]*$";
                var regex = new Regex(PATTERN);
                if (!regex.IsMatch(accountNumber))
                {
                    throw new ArgumentException("Bank account number must contain only digits and uppercase latin letters.");
                }
            }
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
            set => this.holder = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Gets this bank account number.
        /// It must consist of only digits and letters.
        /// </summary>
        public string Number => this.number;

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
        /// <exception cref="InvalidOperationException">
        /// Thrown if this account status was "Closed" of "Frozen".
        /// Status will be saved under the "accountStatus" key in exception Data property.
        /// </exception>
        public void Deposit(decimal amount)
        {
            if (this.Status != BankAccountStatus.Open)
            {
                var exception = new InvalidOperationException($"Can not perform {nameof(this.Deposit)} operation.");
                exception.Data["accountStatus"] = this.Status;

                throw exception;
            }

            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Deposit amount can not be less or equal to zero.");
            }

            if (!HasTwoDecimalPlaces(amount))
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
        /// Thrown if amount &gt; this account's max withdraw 
        /// or amount &gt; this account's balance
        /// or amount have more than two decimal places.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown if this account status was "Closed" of "Frozen".
        /// Status will be saved under the "accountStatus" key in exception Data property.
        /// </exception>
        public void Withdraw(decimal amount)
        {
            if (this.Status != BankAccountStatus.Open)
            {
                var exception = new InvalidOperationException($"Can not perform {nameof(this.Withdraw)} operation.");
                exception.Data["accountStatus"] = this.Status;

                throw exception;
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

            if (!HasTwoDecimalPlaces(amount))
            {
                throw new ArgumentException("Amount must have two decimal places.", nameof(amount));
            }

            this.Balance -= amount;
            this.BonusPoints -= this.CalculateBonusPoints(amount) / 2;
        }

        #endregion

        #region Equality Protocol

        /// <summary>
        /// Equality comparison from <see cref="IEquatable&lt;AbstractBankAccount&gt;"/>.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// True if account numbers are equal, false otherwise.
        /// </returns>
        public bool Equals(AbstractBankAccount other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(this.number, other.number);
        }

        /// <summary>
        /// Object's Equals.
        /// </summary>
        /// <param name="obj">
        /// Object with which to compare this account.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// True if equal, false otherwise.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((AbstractBankAccount)obj);
        }

        /// <summary>
        /// Returns this bank account hash code.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return this.number != null ? this.number.GetHashCode() : 0;
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

        #region Private heplers

        /// <summary>
        /// Checks if passed decimal has two decimal places.
        /// </summary>
        /// <param name="amount">
        /// The amount.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private static bool HasTwoDecimalPlaces(decimal amount) => decimal.Round(amount, 2) == amount;

        #endregion
    }
}
