using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.TextCore.Text;

namespace Assets.Scripts
{
    public abstract class CreepState
    {
        protected Creep creep;
        public CreepState(Creep creep)
        {
            this.creep = creep;
        }

        public abstract void EnterState(Creep character);
        public abstract void UpdateState(Creep character);
        public abstract void ExitState(Creep character);
    }
}
