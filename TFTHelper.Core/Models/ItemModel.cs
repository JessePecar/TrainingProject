using System;
using Xamarin.Forms;

namespace TFTHelper2.Models
{
    public class ItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get => $"item{Id.ToString().PadLeft(2,'0')}.png"; }
    }
}
