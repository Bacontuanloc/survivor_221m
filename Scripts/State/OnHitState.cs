using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.TextCore.Text;
using UnityEngine;

namespace Assets.Scripts
{
    
    public class OnHitState : CharacterState
    {
        private float elapsedTime = 0f;
        private float duration = 1f;
        public OnHitState(Character character) : base(character) { }

        public override void EnterState(Character character)
        {
            character.GetComponent<Renderer>().material.color = Color.red;
        }

        public override void ExitState(Character character)
        {
            character.GetComponent<Renderer>().material.color = Color.white;
        }

        public override void UpdateState(Character character)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime > duration)
            {
                character.ChangeState(new NormalState(character));
            }
        }
    }
}
