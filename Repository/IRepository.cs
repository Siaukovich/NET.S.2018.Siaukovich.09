namespace Repository
{
    using System.Collections.Generic;

    using BankAccount;

    /// <summary>
    /// Interface that every repository class must implement.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Saves passed bank account.
        /// </summary>
        /// <param name="bankAccount">
        /// Bank account.
        /// </param>
        void Save(AbstractBankAccount bankAccount);

        /// <summary>
        /// Gets bank account by number.
        /// </summary>
        /// <param name="accountNumber">
        /// Account number.
        /// </param>
        /// <returns>
        /// The <see cref="AbstractBankAccount"/>.
        /// If account with such number does not exists, returns null.
        /// </returns>
        AbstractBankAccount GetAccountByNumber(string accountNumber);

        /// <summary>
        /// Returns all bank accounts as IEnumerable.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable&lt;AbstractBankAccount&gt;"/>.
        /// </returns>
        IEnumerable<AbstractBankAccount> GetAllBankAccounts();
    }
}
