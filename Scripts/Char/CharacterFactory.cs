using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Char
{
    public class CharacterFactory : MonoBehaviour
    {
        public GameObject Create(string type)
        {
            GameObject character;
            switch (type)
            {
                case "luciano":
                    var luciano = Resources.Load("Prefabs/Character/Luciano") as GameObject;
                    character = Instantiate(luciano);
                    return character;
                case "geran":
                    var geran = Resources.Load("Prefabs/Character/Geran") as GameObject;
                    character = Instantiate(geran);
                    return character;
                case "tomee":
                    var tomee = Resources.Load("Prefabs/Character/Tomee") as GameObject;
                    character = Instantiate(tomee);
                    return character;
                default:
                    return null;

            }
        }

        public GameObject CreateLuciano()
        {
            GameObject luciano = Instantiate(Resources.Load<GameObject>("Prefabs/Character/Luciano"));
            return luciano;
        }

        public GameObject CreateGeran()
        {
            GameObject geran = Instantiate(Resources.Load<GameObject>("Prefabs/Character/Geran"));
            return geran;
        }

        public GameObject CreateTomee()
        {
            GameObject tomee = Instantiate(Resources.Load<GameObject>("Prefabs/Character/Tomee"));
            return tomee;
        }

    }
}
