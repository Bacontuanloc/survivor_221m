using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class DieState : CharacterState
    {
        public DieState(Character character) : base(character)
        {
        }

        public override void EnterState(Character character)
        {
            character.GetComponent<Renderer>().material.color = Color.blue;
        }

        public override void ExitState(Character character)
        {
            
        }

        public override void UpdateState(Character character)
        {
            
        }
    }
}
