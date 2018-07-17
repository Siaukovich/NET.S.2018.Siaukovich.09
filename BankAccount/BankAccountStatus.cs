namespace BankAccount
{
    /// <summary>
    /// Bank account status.
    /// </summary>
    public enum BankAccountStatus
    {
        /// <summary>
        /// Open account. Holder can perform all operations.
        /// </summary>
        Open,

        /// <summary>
        /// Closed account. Holder can not perform any operations.
        /// </summary>
        Closed,

        /// <summary>
        /// Frozen account. Holder can not perform any operations, but account may be unfrozen later.
        /// </summary>
        Frozen
    }
}