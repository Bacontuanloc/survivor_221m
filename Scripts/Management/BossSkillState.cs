using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.RuleTile.TilingRuleOutput;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Management
{
    public class BossSkillState:State
    {
        private Boss Boss;

        public BossSkillState(Boss boss)
        {
            this.Boss = boss;
        }
        public override void EnterState()
        {
            
        }

        public override void ExitState()
        {
            
        }

        public override void UpdateState()
        {
            Boss.Skill1();
            Boss.ChangeState(new BossChaseState(Boss));
        }

    }
}
