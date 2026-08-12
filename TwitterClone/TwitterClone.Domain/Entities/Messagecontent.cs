using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    internal class MessageContent
    {
        private string _text;
        private string _imageUrl;

        public MessageContent(string text, string imageUrl)
        {
            _text = text;
            _imageUrl = imageUrl;
        }

        public string Text
        {
            get { return _text; }
        }

        public string ImageUrl
        {
            get { return _imageUrl; }
        }
    }
}
