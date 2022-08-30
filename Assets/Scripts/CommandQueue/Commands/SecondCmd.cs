using System;

namespace CommandQueue
{
    public class SecondCmd : ICommand
    {
        private readonly GameController _owner;

        public Action OnFinished { get; set; }

        public SecondCmd(GameController owner)
        {
            this._owner = owner;
        }

        public void Execute()
        {
            // activate gameobject
            _owner.secondPopup.gameObject.SetActive(true);

            _owner.secondPopup.onClose += OnClose;
        }

        private void OnClose()
        {
            _owner.secondPopup.onClose -= OnClose;

            _owner.secondPopup.gameObject.SetActive(false);

            OnFinished?.Invoke();
        }
    }
}