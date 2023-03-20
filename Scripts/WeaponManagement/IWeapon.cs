using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.WeaponManagement
{
    public interface IWeapon
    {
        void Shoot();
        void ExecuteSkill();
    }
}
