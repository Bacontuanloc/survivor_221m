using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFactory : MonoBehaviour
{ 
public GameObject Create(string type)
    {
        GameObject monster;
        switch (type)
        {
            case "normal":
                var normal= Resources.Load("Prefabs/Monsters/Monster") as GameObject;
                monster= Instantiate(normal);
                return monster;
            case "fast":
                var fast = Resources.Load("Prefabs/Monsters/FastMonster") as GameObject;
                monster = Instantiate(fast);
                return monster;
            case "tank":
                var tank = Resources.Load("Prefabs/Monsters/TankMonster") as GameObject;
                monster = Instantiate(tank);
                return monster;
            default:
                return null;

        }
    }

}
