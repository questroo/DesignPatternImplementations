using System;
using System.Collections.Generic;
using UnityEngine;

namespace CommandQueue
{
    public class Popup : MonoBehaviour
    {
        public Action onClose;

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Close();
            }
        }
        public void Close()
        {
            onClose?.Invoke();
        }
    }
}