using FullMin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FullMin.Service.objectAnimation
{
    public interface IObjectAnimationService
    {
        ConfigAnimationModel GetConfigAnimation();
        void AddAnimation(string type, ImageList imageList1, ListView listView);
        
    }
}
