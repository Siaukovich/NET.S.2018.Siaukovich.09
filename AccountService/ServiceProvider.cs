namespace AccountService
{
    using Core;

    using Repository;

    /// <summary>
    /// Class for providing service to bank accounts.
    /// </summary>
    public static class ServiceProvider
    {
        /// <summary>
        /// Returns service.
        /// </summary>
        /// <returns>
        /// The <see cref="AbstractAccountService"/>.
        /// </returns>
        public static AbstractAccountService GetService() => new AccountService(FakeRepository.Instance, GuidAccountNumberService.Instance);
    }
}