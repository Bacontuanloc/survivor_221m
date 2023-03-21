using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFactory : MonoBehaviour
{
    public GameObject Create(string type)
    {
        GameObject item;
        switch (type)
        {
            case "heal":
                var normal = Resources.Load("Prefabs/Items/Heal") as GameObject;
                item = Instantiate(normal);
                return item;
            case "bomb":
                var fast = Resources.Load("Prefabs/Items/Bomb") as GameObject;
                item = Instantiate(fast);
                return item;
            case "freeze":
                var tank = Resources.Load("Prefabs/Items/Freeze") as GameObject;
                item = Instantiate(tank);
                return item;
            default:
                return null;

        }
    }

}
