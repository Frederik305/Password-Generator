using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generateur_de_mots_de_passe
{
    internal class Password
    {
        private string passwordValue;
        private string description;
        private string specialCharacters;
        static readonly string LowerCaseCharacters;
        static readonly string DigitCharacters;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        /*public int Length
        {
            get { }
            set { }
        }
        public string UserAccount
        {
            get { }
            set { }
        }*/
        public string SpecialCharacters
        {
            get { return specialCharacters; }
            set { specialCharacters = value; }
        }
        /*public bool HasUppercaseCharacters
        {
            get { }
            set { }
        }
        public bool HasDigitCharacters
        {
            get { }
            set { }
        }*/
    }
}
