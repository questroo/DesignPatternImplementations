using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TypeObject
{
    public class TypeObjectController : MonoBehaviour
    {
        private void Start()
        {
            Bird ostrich = new("ostrich", canFly: false);

            Bird pigeon = new("pigeon", canFly: true);

            Mammal rat = new("rat", canFly: false);

            Mammal bat = new("bat", canFly: true);

            Fish flyingFish = new("flyingFish", canFly: true);

            ostrich.Talk();
            pigeon.Talk();
            rat.Talk();
            bat.Talk();
            flyingFish.Talk();
        }
    }
}