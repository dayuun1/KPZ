using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_6
{
    public class WebStrategy : IImageLoadingStrategy
    {
        public string LoadImage(string href)
        {
            return $"<img src='{href}' />";
        }
    }
}
