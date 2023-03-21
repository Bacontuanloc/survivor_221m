using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.WeaponManagement
{
    public class WeaponFactory : MonoBehaviour
    {
        public GameObject InstantiateWeapon(string character)
        {
            GameObject weapon;
            switch (character)
            {
                case "luciano":
                    var pistol = Resources.Load("Prefabs/Pistol") as GameObject;
                    weapon = Instantiate(pistol);
                    return weapon;
                case "tomee":
                    var kunai = Resources.Load("Prefabs/Kunai") as GameObject;
                    weapon = Instantiate(kunai);
                    return weapon;
                case "geran":
                    var bat = Resources.Load("Prefabs/Bat") as GameObject;
                    weapon = Instantiate(bat);
                    return weapon;
                default:
                    return null;
            }
        }
        public GameObject CreateWeapon(string character)
        {
            switch (character)
            {
                case "luciano":
                    var pistol = Resources.Load("Prefabs/Pistol") as GameObject;
                    return pistol;
                case "tomee":
                    var kunai = Resources.Load("Prefabs/Kunai") as GameObject;
                    return kunai;
                case "geran":
                    var bat = Resources.Load("Prefabs/Bat") as GameObject;
                    return bat;
                default:
                    return null;
            }
        }
    }
}
