using Generateur_de_mots_de_passe;
using Newtonsoft.Json;

namespace PwdGen
{
    /// <summary>
    /// Represente un fichier 
    /// </summary>

    internal class PasswordDataFile
    {
        /// <summary>
        /// chemin du ficher
        /// </summary>
        private string filePath;
        /// <summary>
        /// nom du fichier
        /// </summary>
        private string fileName;
        /// <summary>
        /// Répertoire du fichier
        /// </summary>
        private string fileDirectory;

        /// <summary>
        /// Constructeur de la classe PasswordDataFile.
        /// Initialise le fichier de données pour la sauvegarde des mots de passe.
        /// </summary>
        /// <param name="fileName">Nom du fichier</param>
        /// <param name="fileDirectory">Répertoire du fichier (optionnel)</param>
        public PasswordDataFile(string fileName, string fileDirectory)
        {
            if (fileName == string.Empty) { fileName = "pwd"; }
            if (fileDirectory == string.Empty) { fileDirectory = ""; }
            if (string.IsNullOrWhiteSpace(fileName)) throw new ArgumentNullException(nameof(fileName));

            this.fileName = fileName.Trim();

            if (string.IsNullOrWhiteSpace(fileDirectory))
                this.fileDirectory = AppDomain.CurrentDomain.BaseDirectory; // Chemin actuel de l'application
            else
            {
                if (!Directory.Exists(fileDirectory))
                    throw new DirectoryNotFoundException(nameof(fileDirectory));
                this.fileDirectory = fileDirectory.Trim();
            }

            try
            {
                this.filePath = Path.Combine(this.fileDirectory, this.fileName);
            }
            catch { throw; }

        }

        /// <summary>
        /// Effectue la sauvegarde d'une liste de mots de passe
        /// </summary>
        /// <param name="passwordsList">List de mots de passe</param>
        /// <exception cref="ArgumentNullException"></exception>


        public void Save(List<Password> passwordsList)
        {
            if (passwordsList == null)
                throw new ArgumentNullException(nameof(passwordsList));

            try
            {
                using (StreamWriter file = File.CreateText(this.filePath))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, passwordsList);
                }
            }
            catch { throw; }
        }

        /// <summary>
        /// Charge la liste des mots de passe depuis le fichier.
        /// </summary>
        /// <returns>Liste des mots de passe chargée depuis le fichier</returns>
        public List<Password> Load()
        {
            List<Password> loadedPasswordsList = new List<Password>();
            if (!File.Exists(this.filePath))
                throw new FileNotFoundException(nameof(this.filePath));
            try
            {
                using (StreamReader file = File.OpenText(this.filePath))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    loadedPasswordsList = (List<Password>?)serializer.Deserialize(file, typeof(List<Password>));
                }
            }
            catch { throw; }
            return loadedPasswordsList ?? new List<Password>();
        }
    }
}