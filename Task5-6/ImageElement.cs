using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_6
{
    public class ImageElement : LightNode
    {
        private readonly IImageLoadingStrategy _strategy;
        private readonly string _href;

        public ImageElement(string href, IImageLoadingStrategy strategy)
        {
            _href = href;
            _strategy = strategy;
        }

        public override string InnerHTML() => string.Empty;
        public override string OuterHTML() => _strategy.LoadImage(_href);
    }
}
