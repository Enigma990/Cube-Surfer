using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    private static string playerDataPP = "PlayerData";

    private static PlayerData _instance;

    public static PlayerData instance
    {
        get
        {
            if (_instance == null)
            {
                if (PlayerPrefs.HasKey(playerDataPP))
                {
                    _instance = JsonUtility.FromJson<PlayerData>(PlayerPrefs.GetString(playerDataPP));
                }
                else
                    _instance = new PlayerData();
            }
            return _instance;
        }
        set
        {
            _instance = value;
            PlayerPrefs.SetString(playerDataPP, JsonUtility.ToJson(_instance));
        }
    }

    public int level = 1;
}
