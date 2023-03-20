using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class CreepDieState : CreepState
    {
        public CreepDieState(Creep creep) : base(creep)
        {
        }

        public override void EnterState(Creep creep)
        {
            creep.GetComponent<Renderer>().material.color = Color.blue;
        }

        public override void ExitState(Creep creep)
        {
            
        }

        public override void UpdateState(Creep creep)
        {
            
        }
    }
}
