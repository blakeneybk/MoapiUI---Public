using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Jls.Tools.Testing.MoapiClient.Models
{
    [Serializable]    
    public class FeatureCollection : Collection<Feature>
    {
        private Hashtable _ftCache = new Hashtable();

        public List<Feature> this[FeatureType type]
        {
            get
            {
                // Cache hit?
                if (_ftCache.Contains(type))
                    return (List<Feature>)_ftCache[type];   

                // Find all features by the provided type
                List<Feature> features = FindFeaturesByType(type);
                
                // Add the catagorized feature collection to our 
                // hashtable cache.  This will speed up
                // subsequent lookups.
                _ftCache.Add(type, features);

                return features;       
            }            
        }

        
        public Feature this[string key]
        {
            get
            {
                return LookupFeature(key);
            }
        }        

        //public int Add(Feature feature)
        //{
        //    return (Items.Add(feature));
        //}

        //public int IndexOf(Feature feature)
        //{
        //    return (Items.IndexOf(feature));
        //}

        //public void Insert(int index, Feature feature)
        //{
        //    Items.Insert(index, feature);
        //}

        //public void Remove(Feature feature)
        //{
        //    Items.Remove(feature);
        //}

        //public bool Contains(Feature feature)
        //{
        //    return (List.Contains(feature));
        //}

        public List<Feature> FindFeaturesByType(FeatureType type)
        {
            List<Feature> ftList = new List<Feature>();

            foreach (Feature feature in Items) {
                if (feature.Type == type)
                    ftList.Add(feature);
            }

            return ftList;
        }

        public Feature LookupFeature(string key)
        {
            Feature f = null;

            foreach (Feature feature in Items) {
                if (feature.Key == key)
                    f = feature;
            }

            return f;
        }
       
    }
}
