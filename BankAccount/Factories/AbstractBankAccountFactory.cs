namespace BankAccount
{
    /// <summary>
    /// Class that every bank account factory must inherit from.
    /// </summary>
    public abstract class AbstractBankAccountFactory
    {
        /// <summary>
        /// Returns new bank account.
        /// </summary>
        /// <returns>
        /// The <see cref="AbstractBankAccount"/>.
        /// </returns>
        public abstract AbstractBankAccount GetNewBankAccount();
    }
}