namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using BankAccount;
    using CustomExceptions;

    /// <summary>
    /// Fake repository.
    /// </summary>
    public class FakeRepository : IRepository
    {
        /// <summary>
        /// Bank accounts storage.
        /// </summary>
        private static readonly Dictionary<string, AbstractBankAccount> BankAccounts = 
            new Dictionary<string, AbstractBankAccount>();

        /// <summary>
        /// Lazy singleton realization.
        /// </summary>
        private static readonly Lazy<FakeRepository> LazyInstance = 
            new Lazy<FakeRepository>(() => new FakeRepository(), LazyThreadSafetyMode.PublicationOnly);

        /// <summary>
        /// Prevents a default instance of the <see cref="FakeRepository"/> class from being created.
        /// </summary>
        private FakeRepository()
        {
        }

        /// <summary>
        /// Gets the instance of repository class.
        /// </summary>
        public static IRepository Instance => LazyInstance.Value;

        /// <summary>
        /// Saves passed bank account.
        /// </summary>
        /// <param name="bankAccount">
        /// Bank account.
        /// </param>
        public void Save(AbstractBankAccount bankAccount)
        {
            if (!BankAccounts.ContainsKey(bankAccount.Number))
            {
                BankAccounts.Add(bankAccount.Number, bankAccount);
            }
        }

        /// <summary>
        /// Gets bank account by number. If account with such number does not exists, returns null
        /// </summary>
        /// <param name="accountNumber">
        /// Account number.
        /// </param>
        /// <returns>
        /// The <see cref="AbstractBankAccount"/>.
        /// If account with such number does not exists, returns null.
        /// </returns>
        /// <exception cref="BankAccountNotFoundException">
        /// Thrown if account with such number does not exist.
        /// </exception>
        public AbstractBankAccount GetAccountByNumber(string accountNumber)
        {
            // If dict does not contain this account, backAccount reference is set to null.
            BankAccounts.TryGetValue(accountNumber, out AbstractBankAccount bankAccount);

            if (bankAccount == null)
            {
                throw new BankAccountNotFoundException();
            }

            return bankAccount;
        }

        /// <summary>
        /// Returns all bank accounts as IEnumerable.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable&lt;AbstractBankAccount&gt;"/>.
        /// </returns>
        public IEnumerable<AbstractBankAccount> GetAllBankAccounts() => BankAccounts.Values;
    }
}