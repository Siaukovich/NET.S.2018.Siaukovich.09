namespace Core
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    /// <inheritdoc />
    /// <summary>
    /// Singleton class for generating unique account numbers.
    /// </summary>
    public class GuidAccountNumberService : IAccountNumberGenerator
    {
        /// <summary>
        /// All existing accounts.
        /// </summary>
        private static readonly HashSet<string> Accounts = new HashSet<string>();

        /// <summary>
        /// Lazy singleton realization.
        /// </summary>
        private static readonly Lazy<GuidAccountNumberService> LazyInstance = 
            new Lazy<GuidAccountNumberService>(() => new GuidAccountNumberService(), LazyThreadSafetyMode.PublicationOnly);

        /// <summary>
        /// Gets the class instance.
        /// </summary>
        public IAccountNumberGenerator Instance => LazyInstance.Value;

        /// <summary>
        /// Generates new account number.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// Account number.
        /// </returns>
        public string GenerateNewAccountNumber()
        {
            string newAccountNumber = Guid.NewGuid().ToString("N").ToUpperInvariant();

            // Because of using 36 symbols (26 letters + 10 digits) in string 
            // with length 32 we have 36^32 (6.3e^49) possible account numbers, 
            // so chances to get already existing account number at least once are extremly low.
            // Because of that, we won't stay inside the while loop for a long time (most likely we even won't get inside it).
            while (!Accounts.Contains(newAccountNumber))
            {
                newAccountNumber = Guid.NewGuid().ToString("N").ToUpperInvariant();
            }

            Accounts.Add(newAccountNumber);

            return newAccountNumber;
        }

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
        public bool Exists(string accountNumber) => Accounts.Contains(accountNumber);
    }
}