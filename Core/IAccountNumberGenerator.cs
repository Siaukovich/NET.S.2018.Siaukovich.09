namespace Core
{
    /// <summary>
    /// Singleton class that every account number generator must inherit from.
    /// </summary>
    public interface IAccountNumberGenerator
    {
        /// <summary>
        /// Gets the class instance.
        /// </summary>
        IAccountNumberGenerator Instance { get; }

        /// <summary>
        /// Generates new account number.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// Account number.
        /// </returns>
        string GenerateNewAccountNumber();

        /// <summary>
        /// Checks if given account number exists.
        /// </summary>
        /// <param name="accountNumber">
        /// The account number.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// True if exists, false otherwise.
        /// </returns>
        bool Exists(string accountNumber);
    }
}
