using System.Collections;
using UnityEngine;

namespace CommandQueue
{
    public class GameController : MonoBehaviour
    {
        public Popup firstPopup;
        public Popup secondPopup;
        public Popup thirdPopup;

        private CommandQueue _commandQueue;

        private void Start()
        {
            _commandQueue = new CommandQueue();

            StartCoroutine(Co_StartCommands());
        }

        private IEnumerator Co_StartCommands()
        {
            yield return new WaitForSeconds(2f);

            _commandQueue.Enqueue(new FirstCmd(this));
            _commandQueue.Enqueue(new SecondCmd(this));
            _commandQueue.Enqueue(new ThirdCmd(this));
        }
    }
}
