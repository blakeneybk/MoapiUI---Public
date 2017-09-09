using System;

namespace Jls.Tools.Testing.MoapiClient.Models
{
    [Serializable]
    
    public class Feature
    {
        private int _id;
        private string _key;
        private FeatureType _type;
        private string _name;
        private string _description;

        public Feature()    { }

        public Feature(string name, FeatureType type) : this(name, type, null) { }        

        public Feature(string name, FeatureType type, string key)
        {
            _name = name;
            _type = type;
            _key = key;
        }

        /// <summary>
        /// Gets or sets the unique feature identifer
        /// </summary>        
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// Gets or sets the unique key identifer for this feature
        /// </summary>        
        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }

        /// <summary>
        /// Gets or sets the feature type/category 
        /// </summary>        
        public FeatureType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        /// <summary>
        /// Gets or sets the common name for this feature
        /// </summary>        
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Gets or sets a description that describes this feature and its use
        /// </summary>        
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

    }
}
