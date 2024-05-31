using System;
using UnityEngine;

public class PlayerInfo
{
    public PlayerData playerData = new PlayerData();

    [Serializable]
    public class PlayerData //classe que define os dados do player
    {
        public PlayerDataValues[] playerDataValues;
    }

    [Serializable]
    public class PlayerDataValues //classe que define os valores do player
    {
        public int pla_id = 0;
        public string pla_nome = "";
        public float pla_hp = 0f;
        public int pla_score = 0;

    }

    public PlayerData CreateFromJson(string json)
    {
        return JsonUtility.FromJson<PlayerData>(json);//converte o json para um objeto PlayerData
    }

    public string CreateJsonFromObject()
    {
        return JsonUtility.ToJson(playerData);//converte o objeto para um json
    }
}
