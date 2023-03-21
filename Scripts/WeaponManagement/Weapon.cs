using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.WeaponManagement
{
    public abstract class Weapon : MonoBehaviour
    {
        public abstract void Attack();
        public abstract void Skill();
    }
}
