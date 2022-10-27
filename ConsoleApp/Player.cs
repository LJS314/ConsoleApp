using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Player
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int GoodsAmount { get; set; }
        public Player(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            GoodsAmount = 0;
        }
        public Tuple<bool, string> TakeGoods(Goods goods, int amount)
        {
            var tuple = goods.Take(amount);
            if (tuple.Item1)
            {
                GoodsAmount += amount;
            }
            return tuple;
        }
    }
}
