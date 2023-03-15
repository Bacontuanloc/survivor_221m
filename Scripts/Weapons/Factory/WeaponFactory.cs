using Assets.Scripts.Weapons.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Weapons.Factory
{
    public abstract class WeaponFactory
    {
        public abstract ISkill CreateSkillOne();
        public abstract ISkill CreateSkillTwo();
        public abstract ISkill CreateSkillThree();
    }
}
