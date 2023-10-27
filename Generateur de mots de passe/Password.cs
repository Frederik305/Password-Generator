namespace Generateur_de_mots_de_passe
{
    public class Password
    {
        // Classe Password : Cette classe représente un objet de mot de passe avec ses propriétés et méthodes.

        // Attributs de la classe Password
        private string passwordValue;
        private string description;
        private string specialCharacters;

        // Constantes pour les ensembles de caractères
        public static readonly string LowerCaseCharacters = "abcdefghijklmnopqrstuvwxyz";
        public static readonly string DigitCharacters = "0123456789";

        // Méthode pour générer un mot de passe aléatoire
        public void GenerateRandomPassword(string specialCharacters, int length, bool hasUppercaseCharacters, bool hasDigitCharacters)
        {
            // Génération du mot de passe aléatoire en fonction des paramètres
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

            PasswordValue = new string(passwordValue); // Définir la valeur du mot de passe généré
        }

        // Propriété : Stocke la valeur du mot de passe généré.
        public string PasswordValue { get; private set; }

        // Propriété : Stocke la description du mot de passe.
        public string Description { get; set; }

        // Propriété : Définit ou récupère la longueur du mot de passe. La valeur par défaut est de 12 caractères.
        public int Length { get; set; } = 12;

        // Propriété : Stocke le compte utilisateur associé au mot de passe.
        public string UserAccount { get; set; }

        // Propriété : Stocke les caractères spéciaux à inclure dans le mot de passe.
        public string SpecialCharacters { get; set; }

        // Propriété : Indique si le mot de passe doit contenir des caractères majuscules.
        public bool HasUppercaseCharacters { get; set; }

        // Propriété : Indique si le mot de passe doit contenir des chiffres.
        public bool HasDigitCharacters {  get; set; }

        // Méthode statique : Retourne une chaîne de caractères en majuscules basée sur l'ensemble de caractères en minuscules.
        public static string UpperCaseCharacters()
        {
            return LowerCaseCharacters.ToUpper();
        }

        // Méthode : Vérifie si des caractères spéciaux sont spécifiés pour le mot de passe.
        public bool HasSpecialCharacters(string specialCharacters)
        {
            return !string.IsNullOrEmpty(specialCharacters);
        }

        // Méthode pour convertir un objet Password en une chaîne (utilisée dans la ListBox)
        public override string ToString()
        {
            return Description;
        }
    }
}
