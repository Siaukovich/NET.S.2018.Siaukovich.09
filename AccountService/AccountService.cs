namespace AccountService
{
    using System;

    using BankAccount;
    using Core;
    using CustomExceptions;
    using HolderService;
    using Repository;

    /// <summary>
    /// Account service.
    /// </summary>
    public class AccountService : AbstractAccountService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountService"/> class.
        /// </summary>
        /// <param name="repository">
        /// Repository which stores bank accounts data.
        /// </param>
        /// <param name="accountNumberService">
        /// Account number service that creates unique account numbers.
        /// </param>
        public AccountService(IRepository repository, IAccountNumberService accountNumberService)
            : base(repository, accountNumberService)
        {
        }

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
        public override void OpenAccount(
            string holderName, 
            string holderPhone, 
            string holderEmail, 
            string holderHomeAddress, 
            AbstractBankAccountFactory bankAccountFactory)
        {
            AbstractBankAccount bankAccount = bankAccountFactory.GetNewBankAccount();

            bankAccount.Holder = HolderService.GetHolder(holderName, holderPhone, holderHomeAddress, holderEmail);
            bankAccount.Holder.AddBankAccount(bankAccount);

            this.Repository.Save(bankAccount);
        }

        /// <summary>
        /// Closes account.
        /// </summary>
        /// <param name="accountNumber">
        /// Account number.
        /// </param>
        /// <exception cref="BankAccountNotFoundException">
        /// Thrown if account with such number does not exist.
        /// </exception>
        public override void CloseAccount(string accountNumber)
        {
            AbstractBankAccount bankAccount = this.Repository.GetAccountByNumber(accountNumber);

            bankAccount.Status = BankAccountStatus.Closed;
        }

        /// <summary>
        /// Freezes account.
        /// </summary>
        /// <param name="accountNumber">
        /// Account number.
        /// </param>
        /// <exception cref="BankAccountNotFoundException">
        /// Thrown if account with such number does not exist.
        /// </exception>
        public override void FrozeAccount(string accountNumber)
        {
            AbstractBankAccount bankAccount = this.Repository.GetAccountByNumber(accountNumber);

            bankAccount.Status = BankAccountStatus.Frozen;
        }

        /// <summary>
        /// Unfreezes account.
        /// </summary>
        /// <param name="accountNumber">
        /// Account number.
        /// </param>
        /// <exception cref="BankAccountNotFoundException">
        /// Thrown if account with such number does not exist.
        /// </exception>
        public override void UnfrozeAccount(string accountNumber)
        {
            AbstractBankAccount bankAccount = this.Repository.GetAccountByNumber(accountNumber);

            bankAccount.Status = BankAccountStatus.Open;
        }

        /// <summary>
        /// Deposit money to bank account.
        /// </summary>
        /// <param name="accountNumber">
        /// Bank account number.
        /// </param>
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
        /// <exception cref="BankAccountNotFoundException">
        /// Thrown if account with such number does not exist.
        /// </exception>
        public override void Deposit(string accountNumber, decimal amount)
        {
            AbstractBankAccount bankAccount = this.Repository.GetAccountByNumber(accountNumber);

            bankAccount.Deposit(amount);
        }

        /// <summary>
        /// Withdraw money from this bank account.
        /// </summary>
        /// <param name="accountNumber">
        /// The account Number.
        /// </param>
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
        /// <exception cref="BankAccountNotFoundException">
        /// Thrown if account with such number does not exist.
        /// </exception>
        public override void Withdraw(string accountNumber, decimal amount)
        {
            AbstractBankAccount bankAccount = this.Repository.GetAccountByNumber(accountNumber);

            bankAccount.Deposit(amount);
        }
    }
}