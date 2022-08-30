using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Observer.FromScratchNoEvent
{
    public class GameManager : MonoBehaviour
    {
        private Subject subject;

        private void Awake()
        {
            subject = new Subject();
        }

        private void Start()
        {
            CoolObserver newCool1 = new CoolObserver("Cool Guy 1");
            CoolObserver newCool2 = new CoolObserver("Cool Guy 2");
            CoolObserver newCool3 = new CoolObserver("Cool Guy 3");

            subject.AddObserver(newCool1);
            subject.AddObserver(newCool2);
            subject.AddObserver(newCool3);
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                subject.Notify();
            }
        }
    }
}
