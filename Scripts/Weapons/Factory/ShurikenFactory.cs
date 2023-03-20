﻿using Assets.Scripts.Weapons.Interface;
using Assets.Scripts.Weapons.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Weapons.Factory
{
    public class ShurikenFactory : WeaponFactory
    {
        public override ISkill CreateSkillOne()
        {
            return new ShurikenSkillOne();
        }

        public override ISkill CreateSkillTwo()
        {
            return new ShurikenSkillTwo();
        }
        public override ISkill CreateSkillThree()
        {
            return new ShurikenSkillThree();
        }

    }
}