using UnityEngine;

namespace Flyweight
{
    public class Heavyweight : MonoBehaviour
    {
        private float hp;

        private Data data;

        public Heavyweight()
        {
            hp = Random.Range(10f, 100f);

            data = new Data();
        }
    }
}
