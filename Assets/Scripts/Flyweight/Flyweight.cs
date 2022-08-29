using UnityEngine;

namespace Flyweight
{
    public class Flyweight : MonoBehaviour
    {
        // Data for each object
        private float hp;

        // This is data that's shared among all the objects
        private Data data;

        public Flyweight(Data data)
        {
            hp = Random.Range(10f, 100f);

            this.data = data;
        }
    }
}
