using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.TextCore.Text;
using UnityEngine;

namespace Assets.Scripts
{
    
    public class CreepOnHitState : CreepState
    {
        private float elapsedTime = 0f;
        private float duration = 1f;
        public CreepOnHitState(Creep creep) : base(creep) { }

        public override void EnterState(Creep creep)
        {
            creep.GetComponent<Renderer>().material.color = Color.red;
        }

        public override void ExitState(Creep creep)
        {
            creep.GetComponent<Renderer>().material.color = Color.white;
        }

        public override void UpdateState(Creep creep)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime > duration)
            {
                creep.ChangeState(new CreepNormalState(creep));
            }
        }
    }
}
