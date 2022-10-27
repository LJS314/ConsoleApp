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
        public void AddPlayer(Player player)
        {
            players.Add(player);
        }
        public Player GetNextPlayer()
        {
            nextPlayer = players[next];
            return nextPlayer;
        }
        public Tuple<bool, string> NextPlayerTake(int amount)
        {
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
