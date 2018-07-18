namespace HolderService
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Class for creating Holders objects.
    /// </summary>
    public static class HolderService
    {
        /// <summary>
        /// Holders storage.
        /// </summary>
        private static readonly Dictionary<Holder, Holder> Holders = new Dictionary<Holder, Holder>();

        /// <summary>
        /// Returns Holder object with specified fields, creates new object with this fields if it is not exists.
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
        /// New Holder. Null if holder with same parameters already exists.
        /// </returns>
        public static Holder GetHolder(string name, string contactPhone, string homeAddress, string email)
        {
            var newHolder = new Holder(name, contactPhone, homeAddress, email);

            if (Holders.ContainsKey(newHolder))
            {
                return Holders[newHolder];
            }

            Holders.Add(newHolder, newHolder);

            return newHolder;
        }

        /// <summary>
        /// Returns all holders.
        /// </summary>
        /// <returns>
        /// The <see cref="List&lt;Holder&gt;"/>.
        /// </returns>
        public static IEnumerable<Holder> GetAllHolders() => Holders.Values;
    }
}
