namespace BankAccount
{
    using Core;

    /// <summary>
    /// Base bank account factory.
    /// </summary>
    public class BaseBankAccountFactory : AbstractBankAccountFactory
    {
        /// <summary>
        /// Returns new bank account.
        /// </summary>
        /// <returns>
        /// The <see cref="BaseBankAccount"/>.
        /// </returns>
        public override AbstractBankAccount GetNewBankAccount()
        {
            string bankAccoutNumber = GuidAccountNumberService.Instance.GenerateNewAccountNumber();
            return new BaseBankAccount(bankAccoutNumber);
        }
    }
}