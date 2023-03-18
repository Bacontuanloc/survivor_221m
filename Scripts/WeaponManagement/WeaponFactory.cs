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
        public GameObject InstantiateWeapon(WeaponType weaponType)
        {
            GameObject weapon;
            switch (weaponType)
            {
                case WeaponType.Pistol:
                    var pistol = Resources.Load("Prefabs/Gun") as GameObject;
                    weapon = Instantiate(pistol);
                    return weapon;
                case WeaponType.Kunai:
                    var kunai = Resources.Load("Prefabs/Gun") as GameObject;
                    weapon = Instantiate(kunai);
                    return weapon;
                case WeaponType.Bat:
                    var bat = Resources.Load("Prefabs/Gun") as GameObject;
                    weapon = Instantiate(bat);
                    return weapon;
                default:
                    return null;
            }
        }
    }
}
