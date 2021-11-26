using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Session2.Helpers
{
    public static class ProcessIMG
    {
        private static Uri _uri = null;
        private static BitmapImage _bitmapImage = null;

        public static BitmapImage GetBitmapImage(Agent agent, string other = "")
        {
            if (agent.Logo == "не указано" || agent.Logo == "нет" || agent.Logo == "отсутствует")
                _uri = new Uri(other + "Resources/agents/picture.png", UriKind.RelativeOrAbsolute);
            else 
                _uri = new Uri(other + "Resources" + agent.Logo.Replace("\\", "/"), UriKind.RelativeOrAbsolute);

            _bitmapImage = new BitmapImage(_uri);

            return _bitmapImage;
        }
    }
}
