using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.TextCore.Text;

namespace Assets.Scripts
{
    public abstract class CharacterState
    {
        protected Character character;
        public CharacterState(Character character)
        {
            this.character = character;
        }

        public abstract void EnterState(Character character);
        public abstract void UpdateState(Character character);
        public abstract void ExitState(Character character);
    }
}
