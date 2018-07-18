namespace Core
{
    /// <summary>
    /// Singleton class that every account number generator must inherit from.
    /// </summary>
    public interface IAccountNumberService
    {
        /// <summary>
        /// Generates new account number.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// Account number.
        /// </returns>
        string GenerateNewAccountNumber();
    }
}
