using System;

namespace Generateur_de_mots_de_passe
{
    public class Password
    {
        private string passwordValue;
        private string description;
        private string specialCharacters;

        public static readonly string LowerCaseCharacters = "abcdefghijklmnopqrstuvwxyz";
        public static readonly string DigitCharacters = "0123456789";

        public void GenerateRandomPassword(string specialCharacters, int length, bool hasUppercaseCharacters, bool hasDigitCharacters)
        {
            Random random = new Random();
            string validCharacters = LowerCaseCharacters;

            if (hasUppercaseCharacters)
            {
                validCharacters += UpperCaseCharacters();
            }

            if (hasDigitCharacters)
            {
                validCharacters += DigitCharacters;
            }

            if (HasSpecialCharacters(specialCharacters))
            {
                validCharacters += specialCharacters;
            }

            char[] passwordValue = new char[length];

            for (int i = 0; i < length; i++)
            {
                passwordValue[i] = validCharacters[random.Next(validCharacters.Length)];
            }

            PasswordValue = new string(passwordValue); // Set the generated password value
        }

        public string PasswordValue { get; private set; }


        public string Description { get; set; }

        public int Length { get; set; } = 12;

        public string UserAccount { get; set; }

        public string SpecialCharacters { get; set; }

        public bool HasUppercaseCharacters { get; set; }

        public bool HasDigitCharacters {  get; set; }

        public static string UpperCaseCharacters()
        {
            return LowerCaseCharacters.ToUpper();
        }

        public bool HasSpecialCharacters(string specialCharacters)
        {
            return !string.IsNullOrEmpty(specialCharacters);
        }

        public override string ToString()
        {
            return Description;
        }
    }
}
