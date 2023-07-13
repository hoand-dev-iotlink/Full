using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullMin.Model
{
    public class ConfigAnimationModel
    {
        public List<AnimationItem> AnimationBackground { get; set; }
        public List<AnimationItem> AnimationBorder { get; set; }
        public List<AnimationItem> AnimationImage { get; set; }
        public List<AnimationItem> AnimationText { get; set; }
        public List<AnimationItem> AnimationActive { get; set; }
    }
    public class AnimationItem
    {
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
