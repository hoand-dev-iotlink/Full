using FullMin.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FullMin.Service.objectAnimation
{
    public class ObjectAnimationService : IObjectAnimationService
    {
        public ConfigAnimationModel ConfigAnimations;
        public ObjectAnimationService()
        {
            ConfigAnimations = GetConfigAnimation();
        }
        public void AddAnimation(string type, ImageList imageList1, ListView listView)
        {
            List<AnimationItem> animationItems = new List<AnimationItem>();
            
            switch (type)
            {
                case "AnimationBackground":
                    animationItems = ConfigAnimations.AnimationBackground;
                    break;
                case "AnimationBorder":
                    animationItems = ConfigAnimations.AnimationBorder;
                    break;
                case "AnimationImage":
                    animationItems = ConfigAnimations.AnimationImage;
                    break;
                case "AnimationText":
                    animationItems = ConfigAnimations.AnimationText;
                    break;
                case "AnimationActive":
                    animationItems = ConfigAnimations.AnimationActive;
                    break;
                default:
                    break;
            }
            
            imageList1.ImageSize = new Size(64, 64);
            string url;
            for (int i = 0; i < animationItems.Count; i++)
            {
                url = String.Format(@"..\..\Animation\{0}\{1}", type, animationItems[i].Image);
                imageList1.Images.Add(Image.FromFile(url));
                listView.LargeImageList = imageList1;
                listView.Items.Add(animationItems[i].Name, i);
            }
            listView.View = View.LargeIcon;
        }

        public ConfigAnimationModel GetConfigAnimation()
        {
            var serializer = new JsonSerializer();
            ConfigAnimationModel teachers = new ConfigAnimationModel();
            using (var streamReader = new StreamReader(@"..\..\Animation\Annimation.json"))
            using (var textReader = new JsonTextReader(streamReader))
            {
                teachers = serializer.Deserialize<ConfigAnimationModel>(textReader);
            }
            return teachers;
        }
    }
}
