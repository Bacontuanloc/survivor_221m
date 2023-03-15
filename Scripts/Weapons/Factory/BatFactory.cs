using Assets.Scripts.Weapons.Interface;
using Assets.Scripts.Weapons.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Weapons.Factory
{
    public class BatFactory : WeaponFactory
    {
        public override ISkill CreateSkillOne()
        {
            return new BatSkillOne();
        }

        public override ISkill CreateSkillThree()
        {
            return new BatSkillThree();
        }

        public override ISkill CreateSkillTwo()
        {
            return new BatSkillTwo();
        }
    }
}
