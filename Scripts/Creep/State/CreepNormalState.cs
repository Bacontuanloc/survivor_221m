using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class CreepNormalState : CreepState
    {
        public CreepNormalState(Creep creep) : base(creep) { }

        public override void EnterState(Creep character)
        {
            character.GetComponent<Renderer>().material.color = Color.white;
        }

        public override void ExitState(Creep character)
        {
            character.GetComponent<Renderer>().material.color = Color.white;
        }

        public override void UpdateState(Creep character)
        {

        }
    }
}
