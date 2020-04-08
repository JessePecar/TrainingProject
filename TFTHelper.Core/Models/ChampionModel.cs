using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace TFTHelper2.Core.Models
{
    public class ChampionModel
    {
        #region Model Property
        // Base Champion information
        public string ChampionId { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public List<string> Traits { get; set; }
        // Derived information
        public string TraitsString { get; set; }
        public string ChampionIcon
        {
            get
            {
                try { return $"{Name.Replace(" ", "").Replace("'", "").ToLower()}.png"; }
                catch { return "darkstar.png"; }
            }
        }

        #endregion
    }
}
