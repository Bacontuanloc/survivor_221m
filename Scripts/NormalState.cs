using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class NormalState:PlayerState
    {
        public NormalState(Player player) : base(player) { }

        public override void EnterState(Player player)
        {
            player.GetComponent<Renderer>().material.color = Color.white;
        }

        public override void ExitState(Player player)
        {
            player.GetComponent<Renderer>().material.color = Color.white;
        }

        public override void UpdateState(Player player)
        {

        }
    }
}
