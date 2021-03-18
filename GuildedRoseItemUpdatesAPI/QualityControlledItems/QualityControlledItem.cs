using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildedRoseItemUpdatesAPI
{
    public abstract class QualityControlledItem
    {
        internal readonly Item item;

        public QualityControlledItem(Item item)
        {
            this.item = item;
        }

        public abstract void UpdateItem();
    }
}
