using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.TextCore.Text;

namespace Assets.Scripts
{
    public abstract class PlayerState
    {
        protected Player player;
        public PlayerState(Player player)
        {
            this.player = player;
        }

        public abstract void EnterState(Player player);
        public abstract void UpdateState(Player player);
        public abstract void ExitState(Player player);
    }
}
