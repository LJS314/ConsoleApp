using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Game
    {
        Goods Goods { get; set; }
        List<Player> players { get; set; }
        Player nextPlayer { get; set; }
        Player lastPlater { get; set; }
        int next { get; set; }
        public Game(Goods goods)
        {
            Goods = goods;
            lastPlater = null;
            nextPlayer = null;
            next = 0;
            players = new List<Player>();
        }
        /// <summary>
        /// 添加玩家
        /// </summary>
        /// <param name="player"></param>
        public void AddPlayer(Player player)
        {
            players.Add(player);
        }
        /// <summary>
        /// 获取下一位玩家信息
        /// </summary>
        /// <returns></returns>
        public Player GetNextPlayer()
        {
            nextPlayer = players[next];
            return nextPlayer;
        }
        /// <summary>
        /// 下一位玩家拿取物品
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public Tuple<bool, string> NextPlayerTake(int amount)
        {
            if (amount <= 0)
                return new Tuple<bool, string>(false, "数量不能小于1");

            var tuple = nextPlayer.TakeGoods(Goods, amount);
            if (tuple.Item1)
            {
                if ((next + 1) >= players.Count)
                    next = 0;
                else
                    next++;

                lastPlater = nextPlayer;
            }
            return tuple;
        }
        /// <summary>
        /// 获胜玩家
        /// </summary>
        /// <returns></returns>
        public Tuple<bool, List<Player>> GetWinner()
        {
            if (Goods.goods[1] == 0 && Goods.goods[2] == 0 && Goods.goods[3] == 0)
            {
                var winners = players.Where(a => a.Id != lastPlater.Id).ToList();
                return new Tuple<bool, List<Player>>(true, winners);
            }
            return new Tuple<bool, List<Player>>(false, null);
        }
    }
}
