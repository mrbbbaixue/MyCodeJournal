using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Ecliptae.Lib.Annotations;

namespace Ecliptae.Lib
{
    public class GuidClass
    {
        public string GUID { get; set; }
        public GuidClass()
        {
            GUID = System.Guid.NewGuid().ToString().ToUpper();
        }
    }
    public class Order : GuidClass
    {
        public string Owner { get; set; }
        public ObservableCollection<Item> Items { get; set; }
    }

    public class Item : GuidClass
    {
        public string Owner { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int Storage { get; set; }
    }

    public class OrderItem
    {
        public Item Item { get; set; }
        public int Count { get; set; }

    }

    public class User : GuidClass
    {
        public string Name { get; set; }
        public string Hash { get; set; }
        public float Balance { get; set; }
        public int Level { get; set; }
    }

    public class Comment : GuidClass
    {
        public string Owner { get; set; }
        public string Item { get; set; }
        public string Content { get; set; }
        public int Star { get; set; }
    }

}