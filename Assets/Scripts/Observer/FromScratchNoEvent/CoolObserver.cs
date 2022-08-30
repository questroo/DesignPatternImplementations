using UnityEngine;

namespace Observer.FromScratchNoEvent
{
    public class CoolObserver : Observer
    {
        private string myCoolName;

        public CoolObserver(string name)
        {
            myCoolName = name;
        }

        public override void OnNotify()
        {
            Foo();
        }

        private void Foo()
        {
            Debug.Log($"{myCoolName} has been notified.");
        }
    }
}
