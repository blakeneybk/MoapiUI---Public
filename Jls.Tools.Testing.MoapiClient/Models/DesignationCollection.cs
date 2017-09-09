using System;
using System.Collections.ObjectModel;

namespace Jls.Tools.Testing.MoapiClient.Models
{
    /// <summary>
    /// Generic collection for broker designation lists.
    /// 
    /// </summary>
    [Serializable]    
    public class DesignationCollection : Collection<Designation>
    {
        /// <summary>
        /// Searches the collection for exitence of an entity by it's identifier. 
        /// </summary>
        /// <param name="languageId">Unique identifier</param>
        /// <returns>Success if exists</returns>
        public bool Contains(int designationId)
        {
            foreach (Designation lang in this.Items) {
                if (lang.ID == designationId)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Searches the collection for existence of an entity by it's name. This is a 
        /// case-insensitive search.
        /// </summary>
        /// <param name="languageName">Name of the designation</param>
        /// <returns>Success if exists</returns>
        public bool Contains(string designationName)
        {
            foreach (Designation lang in this.Items) {
                if (String.Compare(
                    lang.Name,
                    designationName,
                    true,
                    System.Globalization.CultureInfo.CurrentUICulture) == 0) {
                    return true;
                }
            }

            return false;
        }
    }
}
