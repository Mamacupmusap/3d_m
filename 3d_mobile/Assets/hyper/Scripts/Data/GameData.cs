using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public Vector3 playerPos;

    //public SerializeDictionary<string,bool> item;

    //start new game
    public GameData()
    {
        playerPos = new Vector3(5, 1, -1);

        //item = new SerializeDictionary<string, bool>();
    }
}
