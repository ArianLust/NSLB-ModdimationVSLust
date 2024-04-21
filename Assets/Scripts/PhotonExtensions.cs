using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

using Photon.Pun;
using Photon.Realtime;

public static class PhotonExtensions {

    private static readonly Dictionary<string, string> SPECIAL_PLAYERS = new() {
        ["8b2be94ce988ddc093db72b0df70fb6a08c3c89baea3a8ccb09ce1d630031c2b"] = "LustoUnity",
        ["0288cebe1525464f9b86e59582a684296883acfe39d988070a5ec7eabbd0710a"] = "Lust",
        ["778543884795a152b54d3d158a3f6f6f7f16e46e81a7f4ddbc54a4ee054b0820"] = "Moddimation",
        ["8dfd75acdb7a7f68d58f270a689fd1ea2b04745c0b2c06e8da983b5de4019e7d"] = "notModdimation",
        ["4b4352dcb5222a0d206a7065eff1deb87db17f7de5a3e83ee2b534811496e4f4"] = "VibriIsHot",
        ["7090d5d86aca51be27bd9840687fd0587b7b00b996638e76101f73b57484331e"] = "NandDollLover",
        ["2fc21940d1fa408fe52bf16ce5a904481606b887a3ee4d3a5b84bc207bd5d41d"] = "MrYoshiNL",
    };

    public static bool IsMineOrLocal(this PhotonView view) {
        return !view || view.IsMine;
    }

    public static bool HasRainbowName(this Player player) {
        if (player == null || player.UserId == null)
            return false;

        byte[] bytes = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(player.UserId));
        StringBuilder sb = new();
        foreach (byte b in bytes)
            sb.Append(b.ToString("X2"));

        string hash = sb.ToString().ToLower();
        return SPECIAL_PLAYERS.ContainsKey(hash) && player.NickName == SPECIAL_PLAYERS[hash];
    }

    //public static void RPCFunc(this PhotonView view, Delegate action, RpcTarget target, params object[] parameters) {
    //    view.RPC(nameof(action), target, parameters);
    //}
}