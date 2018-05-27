using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PlayerInfo {
    public float lastBank;
    public float lastUpdate;
    public string side;
}
public static class PlayerBase {
    public static Dictionary<string, int> unitCosts = new Dictionary<string, int>
    {
        { "DRILL", 10 },
        { "SENTRY", 30 },
        { "CHERRYBOMB", 100 }
    };

    public static readonly float CASH_PER_SEC = 10;
    private static Dictionary<string, PlayerInfo> players = new Dictionary<string, PlayerInfo>();
    private static bool lastSide = false;
    public static void register(string id) {
        PlayerInfo pi = new PlayerInfo();
        pi.lastBank = 0;
        pi.lastUpdate = Time.time;
        pi.side = lastSide ? "LEFT" : "RIGHT";
        players[id] = pi;
        lastSide = !lastSide;
    }
    public static int balance(string id) {
        if(!players.ContainsKey(id)) {
            register(id);
        }
        PlayerInfo pi = players[id];
        float currentTime = Time.time;
        float newMoney = (CASH_PER_SEC * (currentTime - pi.lastUpdate) + pi.lastBank);
        pi.lastUpdate = Time.time;
        pi.lastBank = newMoney;
        return (int)newMoney;
    }
    public static int charge(string id, int delta) {
        if (!players.ContainsKey(id)) {
            register(id);
        }
        PlayerInfo pi = players[id];
        float currentTime = Time.time;
        float newMoney = (CASH_PER_SEC * (currentTime - pi.lastUpdate) + pi.lastBank);

        newMoney += delta;

        pi.lastUpdate = Time.time;
        pi.lastBank = newMoney;
        return (int)newMoney;
    }
    public static string getSide(string id) {
        if (!players.ContainsKey(id)) {
            register(id);
        }
        PlayerInfo pi = players[id];
        return pi.side;
    }
}