using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype
{
    public class SpawnController : MonoBehaviour
    {
        private Ghost ghostPrototype;
        private Demon demonPrototype;
        private Sorcerer sorcererPrototype;

        private Spawner[] monsterSpawners;

        private void Start()
        {
            ghostPrototype = new Ghost(15, 8);
            demonPrototype = new Demon(11, 7);
            sorcererPrototype = new Sorcerer(6, 9);

            monsterSpawners = new Spawner[]
            {
                new Spawner(ghostPrototype),
                new Spawner(demonPrototype),
                new Spawner(sorcererPrototype)
            };
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                //Spawner ghostSpawner = new Spawner(ghostPrototype);
                //
                //Ghost newGhost = ghostSpawner.SpawnMonster() as Ghost;
                //
                //newGhost.Talk();

                Spawner randomSpawner = monsterSpawners[Random.Range(0, monsterSpawners.Length)];

                Monster randomMonster = randomSpawner.SpawnMonster();

                randomMonster.Talk();
            }
        }
    }
}