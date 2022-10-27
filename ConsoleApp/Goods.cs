using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Goods
    {
        public Dictionary<int, int> goods { get; set; }
        public Goods ()
        {
            goods = new Dictionary<int, int>();
            goods.Add(1, 3);
            goods.Add(2, 5);
            goods.Add(3, 7);
        }
        /// <summary>
        /// 拿取物品
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Tuple<bool, string> Take(int i)
        {
            var keys = goods.Keys.ToList();

            foreach (var item in keys)
            {
                if (goods[item] == 0)
                {
                    continue;
                }
                if (i > goods[item])
                {
                    return new Tuple<bool, string>(false, "数量不足");
                }
                goods[item] -= i;
                break;
            }

            return new Tuple<bool, string>(true, String.Empty);
        }
    }
}
