using System;
using System.Collections.ObjectModel;

namespace Jls.Tools.Testing.MoapiClient.Models
{
    [Serializable]    
    public class LanguageCollection : Collection<Language>
    {
        /// <summary>
        /// Searches the collection for exitence of an entity by it's identifier. 
        /// </summary>
        /// <param name="languageId">Unique identifier</param>
        /// <returns>Success if exists</returns>
        public bool Contains(int languageId)
        {
            foreach (Language lang in this.Items) {
                if (lang.ID == languageId)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Searches the collection for existence of an entity by it's name. This is a 
        /// case-insensitive search.
        /// </summary>
        /// <param name="languageName">Name of the language</param>
        /// <returns>Success if exists</returns>
        public bool Contains(string languageName)
        {
            foreach (Language lang in this.Items) {
                if (String.Compare(
                    lang.Name,
                    languageName,
                    true,
                    System.Globalization.CultureInfo.CurrentUICulture) == 0) {
                        return true;
                }
            }

            return false;
        }

    }
}
