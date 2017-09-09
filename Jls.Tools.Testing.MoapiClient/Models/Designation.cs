using System;

namespace Jls.Tools.Testing.MoapiClient.Models
{
    [Serializable]    
    public class Designation
    {
        private int _id;
        private string _name;
        private string _abbreviation;
        private MediaLink _logo;
        private int _referenceCounter;

        
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        
        public string Abbreviation
        {
            get { return _abbreviation; }
            set { _abbreviation = value; }
        }

        
        public MediaLink Logo
        {
            get { return _logo; }
            set { _logo = value; }
        }

        
        public int ReferenceCounter
        {
            get { return _referenceCounter; }
            set { _referenceCounter = value; }
        }
    }
}
