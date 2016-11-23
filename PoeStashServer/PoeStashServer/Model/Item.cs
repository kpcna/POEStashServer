using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoeStashServer.Model
{
    public class Item
    {
        public bool verified { get; set; }
        public int w { get; set; }
        public int h { get; set; }
        public int ilvl { get; set; }
        public string icon { get; set; }
        public string league { get; set; }
        public string id { get; set; }
        public List<object> sockets { get; set; }
        public string name { get; set; }
        public string typeLine { get; set; }
        public bool identified { get; set; }
        public bool corrupted { get; set; }
        public bool lockedToCharacter { get; set; }
        public List<string> implicitMods { get; set; }
        public int frameType { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public string inventoryId { get; set; }
        public List<Item> socketedItems { get; set; }
        public List<Property> properties { get; set; }
        public List<Requirement> requirements { get; set; }
        public List<string> explicitMods { get; set; }
        public List<string> flavourText { get; set; }
        public string descrText { get; set; }
        public bool? support { get; set; }
        public string secDescrText { get; set; }
    }
}
