using System;
using UnityEngine;

namespace Observer
{
    public class Enemy : MonoBehaviour
    {
        public static event Action<Enemy> onAnyEnemyDie;

        public int enemyValue { get; private set; }

        private void OnDisable()
        {
            enemyValue = UnityEngine.Random.Range(0, 5);

            onAnyEnemyDie?.Invoke(this);
        }
    }
}
