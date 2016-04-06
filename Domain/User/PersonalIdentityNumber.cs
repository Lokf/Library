namespace Lokf.Library.Users
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// Representation of the swedish personal identity number (personnummer).
    /// </summary>
    public class PersonalIdentityNumber
    {
        private DateTime _dateOfBirth;

        private string _personalIdentityNumber;

        private char _separator;

        private short _serialNumber;

        private PersonalIdentityNumber(string personalIdentityNumber)
        {
            _personalIdentityNumber = personalIdentityNumber;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonalIdentityNumber"/> class.
        /// </summary>
        /// <param name="personalIdentityNumber">The personal identity number, in the format yyyyMMdd-xxxx.</param>
        /// <param name="dateOfBirth">The date of birth.</param>
        /// <param name="serialNumber">The serial number (xxxx).</param>
        /// <param name="separator">The separator, either "-" or "+".</param>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Format string.")]
        private PersonalIdentityNumber(string personalIdentityNumber, DateTime dateOfBirth, short serialNumber, char separator)
        {
            _personalIdentityNumber = personalIdentityNumber;
            _dateOfBirth = dateOfBirth;
            _serialNumber = serialNumber;
            _separator = separator;
        }

        /// <summary>
        /// Parses a string into a personal identity number.
        /// </summary>
        /// <param name="personalIdentityNumber">The string representation of a personal identity number.</param>
        /// <returns>The personal identity number.</returns>
        public static PersonalIdentityNumber Parse(string personalIdentityNumber)
        {
            PersonalIdentityNumber result;

            if (TryParse(personalIdentityNumber, out result))
            {
                return result;
            }

            throw new Exception();
        }

        /// <summary>
        /// Tries to parse the supplied string into a <seealso cref="PersonalIdentityNumber"/>.
        /// </summary>
        /// <param name="personalIdentityNumber">The personal identity number to be parsed.</param>
        /// <param name="result">The parsed personal identity number.</param>
        /// <returns>Whether or not the personal identity number was successfully parsed.</returns>
        public static bool TryParse(string personalIdentityNumber, out PersonalIdentityNumber result)
        {
            result = null;

            if (string.IsNullOrWhiteSpace(personalIdentityNumber))
            {
                return false;
            }

            var temp = new PersonalIdentityNumber(personalIdentityNumber);

            if (!temp.TryParseSeparator())
            {
                return false;
            }

            if (!temp.TryParseDateOfBirth())
            {
                return false;
            }

            if (!temp.TryParseSerialNumber())
            {
                return false;
            }

            if (!temp.IsValidCheckDigit())
            {
                return false;
            }

            result = temp;

            return true;
        }

        /// <summary>
        /// Compares if this instance is equal to <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The other object to compare equality to.</param>
        /// <returns>True if they are equal. Otherwise false.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var personalIdentityNumber = obj as PersonalIdentityNumber;

            return Equals(personalIdentityNumber);
        }

        /// <summary>
        /// Compares if this instance is equal to <paramref name="personalIdentityNumber"/>.
        /// </summary>
        /// <param name="personalIdentityNumber">The other personal identity number to compare equality to.</param>
        /// <returns>True if they are equal. Otherwise false.</returns>
        public bool Equals(PersonalIdentityNumber personalIdentityNumber)
        {
            if (personalIdentityNumber == null)
            {
                return false;
            }

            return _personalIdentityNumber == personalIdentityNumber.ToString("yyyyMMdd-xxxx");
        }

        /// <summary>
        /// Gets the hash code.
        /// </summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode()
        {
            return _personalIdentityNumber.GetHashCode();
        }

        /// <summary>
        /// Returns the default string representation of the personal identity number (yyMMdd-xxxx).
        /// </summary>
        /// <returns>The string representation of the personal identity number.</returns>
        [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Format string.")]
        public override string ToString()
        {
            return ToString("yyMMdd-xxxx");
        }

        /// <summary>
        /// Returns a string representation of the personal identity number.
        /// </summary>
        /// <param name="format">The format of the string representation.</param>
        /// <returns>The string representation of the personal identity number.</returns>
        public string ToString(string format)
        {
            switch (format)
            {
                case "yyMMdd-xxxx":
                    return _dateOfBirth.ToString("yyMMdd") + _separator + _serialNumber;

                case "yyyyMMdd-xxxx":
                    return _dateOfBirth.ToString("yyyyMMdd") + _separator + _serialNumber;

                case "yyMMddxxxx":
                    return _dateOfBirth.ToString("yyMMdd") + _serialNumber;

                case "yyyyMMddxxxx":
                    return _dateOfBirth.ToString("yyyyMMdd") + _serialNumber;

                default:
                    throw new ArgumentException("Unknown format.", "format");
            }
        }

        private int GetCenturyDigits()
        {
            var thisYear = DateTime.Today.Year % 100;

            var thisCentury = DateTime.Today.Year / 100;

            var year = int.Parse(_personalIdentityNumber.Substring(0, 2));

            int century;

            if (year <= thisYear)
            {
                century = thisCentury;
            }
            else
            {
                century = thisCentury - 1;
            }

            if (_separator == '+')
            {
                century--;
            }

            return century;
        }

        private bool IsValidCheckDigit()
        {
            return Validator.IsValid(_personalIdentityNumber.Remove(8, 1).Substring(2));
        }

        private bool TryParseDateOfBirth()
        {
            if (_personalIdentityNumber.Length == 11)
            {
                var centuryDigits = GetCenturyDigits();

                _personalIdentityNumber = centuryDigits.ToString() + _personalIdentityNumber;
            }

            DateTime dateOfBirth;

            if (!DateTime.TryParseExact(_personalIdentityNumber.Substring(0, 8), "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateOfBirth))
            {
                return false;
            }

            _dateOfBirth = dateOfBirth;

            return true;
        }

        private bool TryParseSeparator()
        {
            if (_personalIdentityNumber.Length == 10)
            {
                _personalIdentityNumber.Insert(6, "-");
            }
            else if (_personalIdentityNumber.Length == 12)
            {
                _personalIdentityNumber.Insert(8, "-");
            }

            if (_personalIdentityNumber.Length == 11)
            {
                _separator = _personalIdentityNumber.ElementAt(6);
            }
            else if (_personalIdentityNumber.Length == 13)
            {
                _separator = _personalIdentityNumber.ElementAt(8);
            }

            if (_separator == '-' || _separator == '+')
            {
                return true;
            }

            return false;
        }

        private bool TryParseSerialNumber()
        {
            if (_personalIdentityNumber.Length != 13)
            {
                return false;
            }

            if (short.TryParse(_personalIdentityNumber.Substring(9), out _serialNumber))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Validator using the Luhn algorithm for calculating the check digit.
        /// </summary>
        private class Validator
        {
            private static readonly Func<char, int> CharToInt = c => c - '0';

            private static readonly Func<int, int> DoubleDigit = n => (n * 2).ToString().Select(CharToInt).Sum();

            private static readonly Func<int, bool> IsOddIndex = index => index % 2 == 0;

            /// <summary>
            /// Validates a personal identity number.
            /// </summary>
            /// <param name="personalIdentityNumber">The personal identity number.</param>
            /// <returns>Whether or not the personal identity number is valid.</returns>
            public static bool IsValid(string personalIdentityNumber)
            {
                var checkSum = personalIdentityNumber
                    .Select(CharToInt)
                    .Reverse()
                    .Select((digit, index) => IsOddIndex(index) ? digit : DoubleDigit(digit))
                    .Sum();

                return checkSum % 10 == 0;
            }
        }
    }
}
