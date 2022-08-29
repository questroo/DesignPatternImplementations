using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Flyweight
{
    //Illustrates the flyweight pattern
    //Open the profiler and click on Memory to see how much memory is being used
    //Switch between Heavy and Flyweight to compare and you should see that the difference is several hundred megabytes even though the data in this case is just 20 doubles
    public class FlyweightController : MonoBehaviour
    {
        private List<Heavyweight> heavyObjects = new List<Heavyweight>();

        private List<Flyweight> flyweightObjects = new List<Flyweight>();

        private void Start()
        {
            int numberOfObjects = 100000;

            // Generation of the heavy objects
            //for(int i = 0; i < numberOfObjects; i++)
            //{
            //    Heavyweight newHeavy = new Heavyweight();
            //
            //    heavyObjects.Add(newHeavy);
            //}

            // Generation of the flyweight objects
            Data data = new Data();
            
            for (int i = 0; i < numberOfObjects; i++)
            {
                Flyweight newFlyweight = new Flyweight(data);
            
                flyweightObjects.Add(newFlyweight);
            }
        }
    }
}
