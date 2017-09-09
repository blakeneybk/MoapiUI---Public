using System;
using System.Runtime.InteropServices;

namespace Jls.Tools.Testing.MoapiClient.Models
{
    [Serializable]    
    public class MediaLink
    {
        private Uri _target;
        private Uri _thumbnail;
        private MediaType _type;
        private MediaBounds _bounds;
        private string _title;        

        public MediaLink() { }

        public MediaLink(string target, MediaType type) : this(target, null, type) { }       

        /// <summary>
        /// Creates and instantiates a new Media Link entity
        /// </summary>
        /// <param name="target">The target Url</param>
        /// <param name="thumbnail">The thumbnail Url</param>
        /// <param name="type">The type of the media link</param>
        public MediaLink(string target, string thumbnail, MediaType type) 
            : this(new Uri(target, UriKind.RelativeOrAbsolute), (thumbnail != null) ? new Uri(thumbnail, UriKind.RelativeOrAbsolute) : null, type) { }

        /// <summary>
        /// Creates and instantiates a new Media Link Entity.
        /// </summary>
        /// <param name="target">The target Url</param>
        /// <param name="thumbnail">The thumbnail Url</param>
        /// <param name="type">The type of the media link</param>
        public MediaLink(Uri target, Uri thumbnail, MediaType type)
        {
            _target = target;
            _thumbnail = thumbnail;
            _type = type;
        }

        /// <summary>
        /// Creates a new Media Link Entity targeted for generic web urls
        /// </summary>
        /// <param name="target">Target Url</param>
        /// <param name="type">Type of the MediaLink</param>
        /// <param name="title">Title/label to display</param>
        public MediaLink(string target, MediaType type, string title)
        {
            _target = new Uri(target);
            _type = type;
            _title = title;
        }
        
        public Uri Target
        {
            get { return _target; }
            set { _target = value; }
        }

        public Uri Thumbnail
        {
            get { return _thumbnail; }
            set { _thumbnail = value; }
        }

        public MediaType Type
        {
            get { return _type; }
            set { _type = value; }
        }
        
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public override string ToString()
        {
            if (_target != null) {
                return _target.ToString();
            }
            else
                return base.ToString();
        }

        public MediaBounds Bounds
        {
            get { return _bounds; }
            set { _bounds = value; }
        }
    }

    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    public struct MediaBounds
    {
        public int Width;
        public int Height;
    }

}
