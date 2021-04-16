using ExitGames.Client.Photon;
using Photon.Realtime;

public static class GamePlayerProperty
{
    private const string  MoneyKey = "Money";

    private static readonly Hashtable propsToSet = new Hashtable();

    // プレイヤーのスコアを取得する
    public static int GetMoney(this Player player)
    {
        if (player.CustomProperties[MoneyKey] is int value)
        {
            return value;
        }
        else
        {
            return 0;
        }
    }

    // プレイヤーのスコアを加算する
    public static void AddMoney(this Player player, int value)
    {
        propsToSet[MoneyKey] = player.GetMoney() + value;
        player.SetCustomProperties(propsToSet);
        propsToSet.Clear();
    }
}