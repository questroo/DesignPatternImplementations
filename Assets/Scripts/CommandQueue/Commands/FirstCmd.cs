using System;

namespace CommandQueue
{
    public class FirstCmd : ICommand
    {
        private readonly GameController _owner;

        public Action OnFinished { get; set; }

        public FirstCmd(GameController owner)
        {
            this._owner = owner;
        }

        public void Execute()
        {
            // activate gameobject
            _owner.firstPopup.gameObject.SetActive(true);

            _owner.firstPopup.onClose += OnClose;
        }

        private void OnClose()
        {
            _owner.firstPopup.onClose -= OnClose;

            _owner.firstPopup.gameObject.SetActive(false);

            OnFinished?.Invoke();
        }
    }
}