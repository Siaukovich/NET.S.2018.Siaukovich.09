namespace BankAccount
{
    /// <summary>
    /// Class that checks that given currency has only 100 coins per each money unit (i.e. 2 decimal places).
    /// </summary>
    public class HundredCoinsPerUnitChecker : IMoneyChecker
    {
        /// <summary>
        /// Gets the error message.
        /// </summary>
        public string ErrorMessage { get; } = "Amount must have two decimal places.";

        /// <summary>
        /// Checks that given currency has only 100 coins per each money unit (i.e. 2 decimal places).
        /// </summary>
        /// <param name="amount">
        /// The amount of money.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// True if contains only two decimal places, false otherwise.
        /// </returns>
        public bool IsValidAmount(decimal amount) => decimal.Round(amount, 2) == amount;
    }
}