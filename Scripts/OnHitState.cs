using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.TextCore.Text;
using UnityEngine;

namespace Assets.Scripts
{
    
    public class OnHitState : PlayerState
    {
        private float elapsedTime = 0f;
        private float duration = 1f;
        public OnHitState(Player player) : base(player) { }

        public override void EnterState(Player player)
        {
            player.GetComponent<Renderer>().material.color = Color.red;
        }

        public override void ExitState(Player player)
        {
            player.GetComponent<Renderer>().material.color = Color.white;
        }

        public override void UpdateState(Player player)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime > duration)
            {
                player.ChangeState(new NormalState(player));
            }
        }
    }
}
