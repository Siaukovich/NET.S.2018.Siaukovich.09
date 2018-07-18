namespace BankAccount
{
    using Core;

    /// <summary>
    /// Base bank account factory.
    /// </summary>
    public class GoldBankAccountFactory : AbstractBankAccountFactory
    {
        /// <summary>
        /// Returns new bank account.
        /// </summary>
        /// <returns>
        /// The <see cref="GoldBankAccount"/>.
        /// </returns>
        public override AbstractBankAccount GetNewBankAccount()
        {
            string bankAccoutNumber = GuidAccountNumberService.Instance.GenerateNewAccountNumber();
            return new GoldBankAccount(bankAccoutNumber);
        }
    }
}