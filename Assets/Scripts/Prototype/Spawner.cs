using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype
{
    public class Spawner
    {
        private Monster prototype;

        public Spawner(Monster prototype)
        {
            this.prototype = prototype;
        }

        public Monster SpawnMonster()
        {
            return prototype.Clone();
        }
    }
}
