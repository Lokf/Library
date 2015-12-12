namespace Lokf.Library.User
{
    using System;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// Representation of the swedish personal identity number (personnummer).
    /// </summary>
    public class PersonalIdentityNumber
    {
        private readonly DateTime _dateOfBirth;

        private readonly string _personalIdentityNumber;

        private readonly char _seperator;

        private readonly short _serialNumber;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonalIdentityNumber"/> class.
        /// </summary>
        /// <param name="personalIdentityNumber">The personal identity number, in the format yyyyMMdd-xxxx.</param>
        /// <param name="dateOfBirth">The date of birth.</param>
        /// <param name="serialNumber">The serial number (xxxx).</param>
        /// <param name="separator">The separator, either "-" or "+".</param>
        private PersonalIdentityNumber(string personalIdentityNumber, DateTime dateOfBirth, short serialNumber, char separator)
        {
            _personalIdentityNumber = personalIdentityNumber;
            _dateOfBirth = dateOfBirth;
            _serialNumber = serialNumber;
            _seperator = separator;
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

            if (personalIdentityNumber.Length != 12 && personalIdentityNumber.Length != 13)
            {
                return false;
            }

            if (personalIdentityNumber.Length == 12)
            {
                personalIdentityNumber = personalIdentityNumber.Insert(8, "-");
            }

            DateTime dateOfBirth;
            if (!TryGetDateOfBirth(personalIdentityNumber, out dateOfBirth))
            {
                return false;
            }

            short serialNumber;
            if (!TryGetSerialNumber(personalIdentityNumber, out serialNumber))
            {
                return false;
            }

            if (!Validator.IsValid(personalIdentityNumber.Remove(8, 1).Substring(2)))
            {
                return false;
            }

            result = new PersonalIdentityNumber(personalIdentityNumber, dateOfBirth, serialNumber, '-');

            return true;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var personalIdentityNumber = obj as PersonalIdentityNumber;

            if (personalIdentityNumber == null)
            {
                return false;
            }

            return Equals(personalIdentityNumber);
        }

        public bool Equals(PersonalIdentityNumber personalIdentityNumber)
        {
            return _personalIdentityNumber == personalIdentityNumber.ToString("yyyyMMdd-xxxx");
        }

        public override int GetHashCode()
        {
            return _personalIdentityNumber.GetHashCode();
        }

        /// <summary>
        /// Returns the default string representation of the personal identity number (yyMMdd-xxxx).
        /// </summary>
        /// <returns>The string representation of the personal identity number.</returns>
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
                    return _dateOfBirth.ToString("yyMMdd") + _seperator + _serialNumber;

                case "yyyyMMdd-xxxx":
                    return _dateOfBirth.ToString("yyyyMMdd") + _seperator + _serialNumber;

                case "yyMMddxxxx":
                    return _dateOfBirth.ToString("yyMMdd") + _serialNumber;

                case "yyyyMMddxxxx":
                    return _dateOfBirth.ToString("yyyyMMdd") + _serialNumber;

                default:
                    throw new ArgumentException();
            }
        }

        /// <summary>
        /// Tries to get the date of birth from the personal identity number.
        /// </summary>
        /// <param name="personalIdentityNumber">The personal identity number.</param>
        /// <param name="dateOfBirth">The date of birth.</param>
        /// <returns>Whether or not the date of birth was successfully parsed.</returns>
        private static bool TryGetDateOfBirth(string personalIdentityNumber, out DateTime dateOfBirth)
        {
            if (DateTime.TryParseExact(personalIdentityNumber.Substring(0, 8), "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateOfBirth))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Tries to get the serial number from the personal identity number.
        /// </summary>
        /// <param name="personalIdentiyNumber">The personal identity number string to be parsed.</param>
        /// <param name="serialNumber">The serial number.</param>
        /// <returns>True or false.</returns>
        private static bool TryGetSerialNumber(string personalIdentiyNumber, out short serialNumber)
        {
            if (short.TryParse(personalIdentiyNumber.Substring(9), out serialNumber))
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
            /// <summary>
            /// Gets the numeric value of the digit by subtracting the char value of '0'.
            /// </summary>
            private static readonly Func<char, int> CharToInt = c => c - '0';

            /// <summary>
            /// Doubles the digit and sums the digits in the resulting number.
            /// </summary>
            private static readonly Func<int, int> DoubleDigit = n => (n * 2).ToString().Select(CharToInt).Sum();

            /// <summary>
            /// Determines if the index is odd or not.
            /// </summary>
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
