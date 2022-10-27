// See https://aka.ms/new-console-template for more information
using ConsoleApp;

Console.WriteLine("开始");
Goods goods = new Goods();
Console.WriteLine("请输入一号玩家名称：");
var playerName1 = Console.ReadLine();
Player player1 = new Player(playerName1);
Console.WriteLine("请输入二号玩家名称：");
var playerName2 = Console.ReadLine();
Player player2 = new Player(playerName2);
Game game = new Game(goods);
game.AddPlayer(player1);
game.AddPlayer(player2);

while (true)
{
    var winner = game.GetWinner();
    if (winner.Item1)
    {
        foreach (var item in winner.Item2)
            Console.WriteLine("获胜玩家是：" + item.Name);

        break;
    }

    var nextPlayer = game.GetNextPlayer();
    Console.WriteLine("请玩家：" + nextPlayer.Name + ",输入拿取数量");

    var amountStr = Console.ReadLine();
    int amount = 0;
    if (!int.TryParse(amountStr, out amount))
    {
        Console.WriteLine("输入错误：" + amountStr);
        continue;
    }

    var takeTuple = game.NextPlayerTake(amount);
    if (!takeTuple.Item1)
        Console.WriteLine(takeTuple.Item2);

    foreach (var item in goods.goods)
        Console.WriteLine(string.Format("第{0}行：{1}", item.Key, item.Value));

}
