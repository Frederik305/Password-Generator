namespace Generateur_de_mots_de_passe
{
    /// <summary>
    /// Classe représentant un objet de mot de passe avec ses propriétés et méthodes.
    /// </summary>
    public class Password
    {
        /// <summary>
        /// Constantes pour les ensembles de caractères
        /// </summary>
        public static readonly string LowerCaseCharacters = "abcdefghijklmnopqrstuvwxyz";
        public static readonly string DigitCharacters = "0123456789";

        /// <summary>
        /// Méthode pour générer un mot de passe aléatoire en fonction des paramètres donnés.
        /// </summary>
        /// <param name="specialCharacters">string des charactere speciaux</param>
        /// <param name="length">la longueur du mot de passe</param>
        /// <param name="hasUppercaseCharacters">true si le password contient des maj</param>
        /// <param name="hasDigitCharacters">true si le password contient chiffres</param>
        /// <param name="hasSpecialCharacters">true si le password contient des charactere speciaux</param>
        public void GenerateRandomPassword(string specialCharacters, int length, bool hasUppercaseCharacters, bool hasDigitCharacters, bool hasSpecialCharacters, int minLowercases, int minUppercases, int minDigit, int minSpecial)
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

            if (hasSpecialCharacters)
            {
                validCharacters += specialCharacters;
            }

            string password = "";

            for (int i = 0; i < minLowercases; i++)
            {
                password += LowerCaseCharacters[random.Next(LowerCaseCharacters.Length)];
            }

            for (int i = 0; i < minUppercases; i++)
            {
                password += UpperCaseCharacters()[random.Next(UpperCaseCharacters().Length)];
            }

            for (int i = 0; i < minDigit; i++)
            {
                password += DigitCharacters[random.Next(DigitCharacters.Length)];
            }

            for (int i = 0; i < minSpecial; i++)
            {
                password += specialCharacters[random.Next(specialCharacters.Length)];
            }

            for (int i = password.Length; i < length; i++)
            {
                password += validCharacters[random.Next(validCharacters.Length)];
            }

            password = new string(password.ToCharArray().OrderBy(x => random.Next()).ToArray());

            PasswordValue = new string(password);
        }

        /// <summary>
        /// Propriété : Stocke la valeur du mot de passe généré.
        /// </summary>
        public string? PasswordValue { get; set; }

        /// <summary>
        /// Propriété : Stocke la description du mot de passe.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Propriété : Stocke le URL d'un site lier au mot de passe.
        /// </summary>
        public string? URL { get; set; }

        /// <summary>
        /// Propriété : Stocke une Note de reference au site lier au mot de passe.
        /// </summary>
        public string? Note { get; set; }

        /// <summary>
        /// Propriété : Définit ou récupère la longueur du mot de passe. La valeur par défaut est de 12 caractères.
        /// </summary>
        public int Length { get; set; } = 12;

        /// <summary>
        /// Propriété : Stocke le compte utilisateur associé au mot de passe.
        /// </summary>
        public string? UserAccount { get; set; }

        /// <summary>
        /// Propriété : Stocke les caractères spéciaux à inclure dans le mot de passe.
        /// </summary>
        public string? SpecialCharacters { get; set; }

        /// <summary>
        /// Propriété : Indique si le mot de passe doit contenir des caractères majuscules.
        /// </summary>
        public bool HasUppercaseCharacters { get; set; }

        /// <summary>
        /// Propriété : Indique si le mot de passe doit contenir des chiffres.
        /// </summary>
        public bool HasDigitCharacters {  get; set; }

        /// <summary>
        /// Propriété : Indique si le mot de passe doit contenir des charactere speciaux.
        /// </summary>
        public bool HasSpecialCharacters {  get; set; }

        public int MinCharacters { get; set; }

        public int ValDefault { get; set; }

        /// <summary>
        /// Méthode statique : Retourne une chaîne de caractères en majuscules basée sur l'ensemble de caractères en minuscules.
        /// </summary>
        /// <returns>Retourne un string de lettre maj</returns>
        public static string UpperCaseCharacters()
        {
            return LowerCaseCharacters.ToUpper();
        }

        /// <summary>
        /// Méthode pour obtenir une représentation textuelle de l'objet, renvoyant la description du mot de passe.
        /// </summary>
        public override string ToString()
        {
            return Description;
        }
    }
}
