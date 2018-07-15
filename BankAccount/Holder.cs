namespace BankAccount
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Class that describes a single customer by his name, contact phone and revenue.
    /// </summary>
    public class Holder
    {
        #region Private fields

        /// <summary>
        /// Customer's name.
        /// </summary>
        private string name;

        /// <summary>
        /// Customer's contact phone.
        /// </summary>
        private string contactPhone;

        /// <summary>
        /// Customer's revenue.
        /// </summary>
        private string homeAdress;

        #endregion

        #region Propereties

        /// <summary>
        /// Gets or sets current holder's name.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Thrown if passed name is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if passed name doesn't satisfy given rules:
        /// 1. Name can be only in English.
        /// 2. Name must contain at least two words. 
        /// 3. All words separated by one whitespace.
        /// 4. Only first letter of each word must be uppercase.
        /// </exception>
        public string Name
        {
            get => this.name;

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                const string PATTERN = @"^([A-Z][a-z]* )+[A-Z][a-z]*$";
                var regex = new Regex(PATTERN);
                if (!regex.IsMatch(value))
                {
                    throw new ArgumentException("Name must be in English, contain at least two words separated by " + 
                                                "single whitespace and only first letter of each name must be uppercase.");
                }

                this.name = value;
            }
        }

        /// <summary>
        /// Gets or sets current holders's contact phone.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Thrown if passed number is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if passed number not in form "+X (XXX) XXX-XXXX".
        /// </exception>
        public string ContactPhone
        {
            get => this.contactPhone;

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                const string PATTERN = @"^\+\d \(\d{3}\) \d{3}-\d{4}";
                var regex = new Regex(PATTERN);
                if (!regex.IsMatch(value))
                {
                    throw new ArgumentException("Number must be in form \"+X (XXX) XXX-XXXX\".");
                }

                this.contactPhone = value;
            }
        }

        /// <summary>
        /// Gets or sets current customer's revenue.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Thrown if passed value is negative or contain more than 2 decimal places.
        /// </exception>
        public string HomeAdress
        {
            get => this.homeAdress;

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                const string PATTERN = @"^\d+ [A-Z][a-z]* st\.$";
                var regex = new Regex(PATTERN);
                if (!regex.IsMatch(value))
                {
                    throw new ArgumentException("Adress must be in form \"house-numer street-name st.\".");
                }

                this.homeAdress = value;
            }
        }

        #endregion
    }
}