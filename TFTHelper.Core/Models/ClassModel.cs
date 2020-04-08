using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace TFTHelper2.Models
{
    public class ClassModel
    {
        public string Name { get; set; }
        public string Key { get; set; }
        public string Type { get; set; }
        public string Descriptions { get; set; }
        public List<SetModel> Sets { get; set; }
        public string ClassIcon { get => (Name == "Void") ? "voidIcon.png" : $"{Name.Replace(" ", "").Replace("-","").ToLower()}.png"; }
    }
}
