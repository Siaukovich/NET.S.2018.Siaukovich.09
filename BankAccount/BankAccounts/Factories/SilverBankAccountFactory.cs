namespace BankAccount
{
    using Core;

    /// <summary>
    /// Base bank account factory.
    /// </summary>
    public class SilverBankAccountFactory : AbstractBankAccountFactory
    {
        /// <summary>
        /// Returns new bank account.
        /// </summary>
        /// <returns>
        /// The <see cref="SilverBankAccount"/>.
        /// </returns>
        public override AbstractBankAccount GetNewBankAccount()
        {
            string bankAccoutNumber = GuidAccountNumberService.Instance.GenerateNewAccountNumber();
            return new SilverBankAccount(bankAccoutNumber);
        }
    }
}