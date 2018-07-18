namespace HolderService
{
    /// <summary>
    /// Class for creating Holders objects.
    /// </summary>
    public static class HolderFactory
    {
        /// <summary>
        /// Total amount of created holders. Used for setting new Holder's id.
        /// </summary>
        private static long nextHolderId;

        /// <summary>
        /// Creates new Holder object.
        /// </summary>
        /// <param name="name">
        /// Holder's name.
        /// </param>
        /// <param name="contactPhone">
        /// Holder's contact phone.
        /// </param>
        /// <param name="homeAddress">
        /// Holder's home address.
        /// </param>
        /// <param name="email">
        /// Holder's email.
        /// </param>
        /// <returns>
        /// The <see cref="Holder"/>.
        /// New Holder.
        /// </returns>
        public static Holder GetNewHolder(string name, string contactPhone, string homeAddress, string email)
        {
            var holder = new Holder(name, contactPhone, homeAddress, email, nextHolderId);

            nextHolderId++;

            return holder;
        }
    }
}
