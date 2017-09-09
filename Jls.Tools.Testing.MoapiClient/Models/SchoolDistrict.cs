using System;

namespace Jls.Tools.Testing.MoapiClient.Models
{
    [Serializable]
    
    public class SchoolDistrict
    {
        private string _name;
        private string _elementarySchool;
        private string _middleSchool;
        private string _highSchool;

        /// <summary>
        /// Gets or sets the district name of the school district
        /// </summary>
        
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Gets or sets the name of the Elementary school in this district
        /// </summary>
        
        public string ElementarySchool
        {
            get { return _elementarySchool; }
            set { _elementarySchool = value; }
        }

        /// <summary>
        /// Gets or sets the name of the Middle school in this district
        /// </summary>
        
        public string MiddleSchool
        {
            get { return _middleSchool; }
            set { _middleSchool = value; }
        }

        /// <summary>
        /// Gets or sets the name of the High school in this district
        /// </summary>
        
        public string HighSchool
        {
            get { return _highSchool; }
            set { _highSchool = value; }
        }
    }
}
