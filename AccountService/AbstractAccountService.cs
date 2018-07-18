namespace AccountService
{
    using System;
    using BankAccount;
    using Core;
    using Repository;

    /// <summary>
    /// Base class for all account services.
    /// </summary>
    public abstract class AbstractAccountService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractAccountService"/> class.
        /// </summary>
        /// <param name="repository">
        /// Repository which stores bank accounts data.
        /// </param>
        /// <param name="accountNumberService">
        /// Account number service that creates unique account numbers.
        /// </param>
        protected AbstractAccountService(IRepository repository, IAccountNumberService accountNumberService)
        {
            this.AccountNumberService = accountNumberService ?? throw new ArgumentNullException(nameof(accountNumberService));
            this.Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        /// <summary>
        /// Gets repository for storing bank accounts.
        /// </summary>
        protected IRepository Repository { get; }

        /// <summary>
        /// Gets factory for account numbers.
        /// </summary>
        protected IAccountNumberService AccountNumberService { get; }

        /// <summary>
        /// Opens new account.
        /// </summary>
        /// <param name="holderName">
        /// Holder's name.
        /// </param>
        /// <param name="holderPhone">
        /// Holder's phone.
        /// </param>
        /// <param name="holderEmail">
        /// Holder's email.
        /// </param>
        /// <param name="holderHomeAddress">
        /// Holder's home address.
        /// </param>
        /// <param name="bankAccountFactory">
        /// Factory that creates bank account.
        /// </param>
        /// <param name="accountNumberFactory">
        /// Account number factory that will generate new account number.
        /// </param>
        public abstract void OpenAccount(
            string holderName,
            string holderPhone,
            string holderEmail,
            string holderHomeAddress,
            AbstractBankAccountFactory bankAccountFactory);
        
        /// <summary>
        /// Closes account.
        /// </summary>
        /// <param name="accountNumber">
        /// Account number.
        /// </param>
        public abstract void CloseAccount(string accountNumber);

        /// <summary>
        /// Freezes account.
        /// </summary>
        /// <param name="accountNumber">
        /// Account number.
        /// </param>
        public abstract void FrozeAccount(string accountNumber);

        /// <summary>
        /// Unfreezes account.
        /// </summary>
        /// <param name="accountNumber">
        /// Account number.
        /// </param>
        public abstract void UnfrozeAccount(string accountNumber);

        /// <summary>
        /// Deposit money on bank account.
        /// </summary>
        /// <param name="accountNumber">
        /// Account number.
        /// </param>
        /// <param name="amount">
        /// The amount of money to deposit.
        /// </param>
        public abstract void Deposit(string accountNumber, decimal amount);

        /// <summary>
        /// Withdraw money from bank account.
        /// </summary>
        /// <param name="accountNumber">
        /// Account number.
        /// </param>
        /// <param name="amount">
        /// The amount of money to withdraw.
        /// </param>
        public abstract void Withdraw(string accountNumber, decimal amount);
    }
}
