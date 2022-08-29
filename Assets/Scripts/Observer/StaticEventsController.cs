using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Observer
{
    public class StaticEventsController : MonoBehaviour
    {
        public Enemy enemyPrefab;

        private int score;

        private int enemiesKilled = 0;

        private void Awake()
        {
            Enemy.onAnyEnemyDie += AddToScore;
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                var newEnemy = Instantiate(enemyPrefab.gameObject, Random.insideUnitSphere, Quaternion.identity);

                // Kill enemy after 3 seconds triggering the event
                Destroy(newEnemy, 3f);
            }
        }

        private void AddToScore(Enemy enemyScript)
        {
            score += enemyScript.enemyValue;

            enemiesKilled += 1;

            Debug.Log($"You've killed {enemiesKilled} enemies and the score is: {score}");
        }
    }
}
