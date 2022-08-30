using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Observer.FromScratchNoEvent
{
    public abstract class Observer
    {
        public abstract void OnNotify();
    }
}
