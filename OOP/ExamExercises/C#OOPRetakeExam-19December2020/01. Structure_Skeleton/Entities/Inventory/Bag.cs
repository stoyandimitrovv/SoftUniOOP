using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Items;
using WarCroft.Constants;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private readonly List<Item> items;

        protected Bag(int capacity = 100)
        {
            this.items = new List<Item>();
            this.Capacity = capacity;
        }

        public int Capacity { get; set; }

        public int Load => this.Items.Sum(x => x.Weight);

        //When we have IReadOnly instans in ctor
        public IReadOnlyCollection<Item> Items => this.items;

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            //Should be with Any and not null
            if (!this.items.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            Item item = this.items.FirstOrDefault(x => x.GetType().Name == name);

            if (item == null)
            {
                //Use string.Format for message format + name
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }

            return item;
        }
    }
}
