using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using TFTHelper2.Core.Models;
using TFTHelper2.Models;

namespace TFTHelper2.Core.Champions
{
    public static class Champions
    {
        #region Public properties
        public static List<ChampionModel> ChampionsData { get; private set; }
        public static List<string> FilterSelection { get; private set; }
        public static List<string> SortSelection { get; private set; }
        public static List<ClassModel> ClassData { get; private set; }
        public static List<ItemModel> ItemData { get; private set; }
        #endregion

        #region Private properties
        private static Assembly assembly = typeof(Champions).GetTypeInfo().Assembly;
        private static string championJsonFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "champion.json");
        private static string sortJsonFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "sortSelection.json");
        private static string traitsJsonFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "traits.json");
        private static string itemsJsonFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "items.json");
        #endregion

        public static void CheckForFirstTimeSetup(bool createOverride = false)
        {
            if(createOverride)
            {
                if (File.Exists(championJsonFile))
                {
                    File.Delete(championJsonFile);
                }
                if (File.Exists(traitsJsonFile))
                {
                    File.Delete(traitsJsonFile);
                }
                if (File.Exists(sortJsonFile))
                {
                    File.Delete(sortJsonFile);
                }
                if (File.Exists(itemsJsonFile))
                {
                    File.Delete(itemsJsonFile);
                }
            }
            if (!File.Exists(championJsonFile))
            {
                string champions;
                Stream championStream = assembly.GetManifestResourceStream("TFTHelper.Core.champions.json");
                using (var reader = new StreamReader(championStream))
                {
                    champions = reader.ReadToEnd();
                }
                using(var writer = new StreamWriter(championJsonFile, true))
                {
                    writer.Write(champions);
                }
            }
            if (!File.Exists(sortJsonFile))
            {
                string sort;
                Stream sortStream = assembly.GetManifestResourceStream("TFTHelper.Core.sortSelection.json");
                using (var reader = new StreamReader(sortStream))
                {
                    sort = reader.ReadToEnd();
                }
                using (var write = new StreamWriter(sortJsonFile, true))
                {
                    write.Write(sort);
                }
            }
            if (!File.Exists(traitsJsonFile))
            {
                string trait;
                Stream traitStream = assembly.GetManifestResourceStream("TFTHelper.Core.traits.json");
                using (var reader = new StreamReader(traitStream))
                {
                    trait = reader.ReadToEnd();
                }
                using (var write = new StreamWriter(traitsJsonFile, true))
                {
                    write.Write(trait);
                }
            }
            if (!File.Exists(itemsJsonFile))
            {
                string item;
                Stream itemStream = assembly.GetManifestResourceStream("TFTHelper.Core.items.json");
                using (var reader = new StreamReader(itemStream))
                {
                    item = reader.ReadToEnd();
                }
                using (var write = new StreamWriter(itemsJsonFile, true))
                {
                    write.Write(item);
                }
            }
        }

        public static List<ChampionModel> ReadChampions()
        {
            List<ChampionModel> retVal = new List<ChampionModel>();
            if (File.Exists(championJsonFile))
            {
                string champ = File.ReadAllText(championJsonFile);
                retVal = JsonConvert.DeserializeObject<List<ChampionModel>>(champ);
            }
            return retVal;
        }

        public static List<string> ReadSort()
        {
            List<string> retVal = new List<string>();
            if (File.Exists(sortJsonFile))
            {
                string sort = File.ReadAllText(sortJsonFile);
                retVal = JsonConvert.DeserializeObject<List<string>>(sort);
            }
            return retVal;
        }

        public static List<ClassModel> ReadClass()
        {
            List<ClassModel> retVal = new List<ClassModel>();
            if (File.Exists(traitsJsonFile))
            {
                string trait = File.ReadAllText(traitsJsonFile);
                retVal = JsonConvert.DeserializeObject<List<ClassModel>>(trait);
            }
            //retVal.Insert(0, new ClassModel() { Name = "--Select All--" });
            return retVal;
        }
        public static List<ItemModel> ReadItems()
        {
            List<ItemModel> retVal = new List<ItemModel>();
            if (File.Exists(traitsJsonFile))
            {
                string trait = File.ReadAllText(itemsJsonFile);
                retVal = JsonConvert.DeserializeObject<List<ItemModel>>(trait);
            }
            return retVal;
        }

        public static List<ChampionModel> GetChampions()
        {
            if(ChampionsData == null || ChampionsData.Count == 0)
            {
                ChampionsData = ReadChampions();
                foreach (ChampionModel champ in ChampionsData)
                {
                    champ.TraitsString = string.Join(", ", champ.Traits); 
                }
            }
            return ChampionsData;
        }
        public static List<string> GetSort()
        {
            if (SortSelection == null || SortSelection.Count == 0)
            {
                SortSelection = ReadSort();
            }
            return SortSelection;
        }
        public static List<ClassModel> GetClass()
        {
            if (ClassData == null || ClassData.Count == 0)
            {
                ClassData = ReadClass();
            }
            return ClassData;
        }
        public static List<ItemModel> GetItems()
        {
            if (ItemData == null || ItemData.Count == 0)
            {
                ItemData = ReadItems();
            }
            return ItemData;
        }
    }
}
