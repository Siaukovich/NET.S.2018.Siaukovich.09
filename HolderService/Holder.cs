namespace HolderService
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Class that describes a single holder by his name, contact phone, email and home address.
    /// </summary>
    public sealed class Holder : IEquatable<Holder>
    {
        #region Private fields

        /// <summary>
        /// Holder's id. 
        /// Must be unique for every holder, because only id is used for comparison.
        /// </summary>
        private readonly long id;

        /// <summary>
        /// Holder's name.
        /// </summary>
        private string name;

        /// <summary>
        /// Holder's contact phone.
        /// </summary>
        private string contactPhone;

        /// <summary>
        /// Holder's revenue.
        /// </summary>
        private string homeAddress;

        /// <summary>
        /// Holder's email.
        /// </summary>
        private string email;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Holder"/> class.
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
        /// <param name="id">
        /// Holder's id.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if any of the passed string is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if passed string doesn't match property requirements. 
        /// For additional info see properties' description.
        /// </exception>
        public Holder(string name, string contactPhone, string homeAddress, string email, long id)
        {
            this.Name = name;
            this.ContactPhone = contactPhone;
            this.HomeAddress = homeAddress;
            this.Email = email;

            this.id = id;
        }

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
        /// Gets or sets current holder's contact phone.
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
                ThrowForInvalidString(
                    value: value,
                    regexpPattern: @"^\+\d \(\d{3}\) \d{3}-\d{4}$",
                    errorMessage: "Number must be in form \"+X (XXX) XXX-XXXX\"."
                );

                this.contactPhone = value;
            }
        }

        /// <summary>
        /// Gets or sets current customer's home address.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Thrown if passed home address is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if passed home address not in form "house-number street-name st.".
        /// </exception>
        public string HomeAddress
        {
            get => this.homeAddress;

            set
            {
                ThrowForInvalidString(
                    value: value,
                    regexpPattern: @"^\d+ [A-Z][a-z]* st\.$",
                    errorMessage: "Adress must be in form \"house-number street-name st.\"."
                );

                this.homeAddress = value;
            }
        }

        /// <summary>
        /// Gets or sets current customer's email.
        /// </summary>
        public string Email
        {
            get => this.email;
            set
            {
                ThrowForInvalidString(
                    value: value, 
                    regexpPattern: @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})$", 
                    errorMessage: "Wrong email format."
                );

                this.email = value;
            }
        }

        #endregion

        #region Equality protocol

        /// <summary>
        /// Equality comparison from <see cref="IEquatable&lt;Holder&gt;"/>.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// True if all field are equal, false otherwise.
        /// </returns>
        public bool Equals(Holder other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.id == other.id;
        }

        /// <summary>
        /// Equality comparison from object.
        /// </summary>
        /// <param name="obj">
        /// The other.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// False if some fields are not equal 
        /// or passed object is null 
        /// or operands have different types, 
        /// true otherwise.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((Holder)obj);
        }

        /// <summary>
        /// Returns this Holder's hash code.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetHashCode() => this.id.GetHashCode();

        #endregion

        #region Private helpers

        /// <summary>
        /// Checks passed value string for null and for matching provided regular expression pattern.
        /// </summary>
        /// <param name="value">
        /// Value that needs to be checked.
        /// </param>
        /// <param name="regexpPattern">
        /// Regular expression pattern that validates passed value.
        /// </param>
        /// <param name="errorMessage">
        /// Error message for ArgumentException.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if passed value is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if passed value doesn't match provided regular expression pattern.
        /// </exception>
        private static void ThrowForInvalidString(string value, string regexpPattern, string errorMessage)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            var regex = new Regex(regexpPattern);
            if (!regex.IsMatch(value))
            {
                throw new ArgumentException(errorMessage);
            }
        }

        #endregion
    }
}