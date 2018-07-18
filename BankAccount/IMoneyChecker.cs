namespace BankAccount
{
    /// <summary>
    /// Interface that every class that checks money validness must implement.
    /// </summary>
    public interface IMoneyChecker
    {
        /// <summary>
        /// Gets the error message.
        /// </summary>
        string ErrorMessage { get; }

        /// <summary>
        /// Checks if given money amount is valid.
        /// </summary>
        /// <param name="amount">
        /// The amount of money.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// True if valid, false otherwise.
        /// </returns>
        bool IsValidAmount(decimal amount);
    }
}