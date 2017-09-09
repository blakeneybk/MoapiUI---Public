namespace Jls.Tools.Testing.MoapiClient.Models
{    
    public class Language
    {
        private int _id;
        private string _name;
        private string _description;
        private int _brokerCount;

        /// <summary>
        /// Gets the unique language identifier
        /// </summary>
        
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// Gets or sets the friendly language name
        /// </summary>
        
        public string Name 
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Gets or sets a brief description of the language and how it is to be used.
        /// </summary>
        
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        /// <summary>
        /// Gets or sets the number of this language instance is referenced by a broker object.
        /// </summary>
        
        public int ReferenceCounter
        {
            get { return _brokerCount; }
            set { _brokerCount = value; }
        }

    }
}
