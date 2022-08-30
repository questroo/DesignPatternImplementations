using System;

namespace CommandQueue
{
    public class ThirdCmd : ICommand
    {
        private readonly GameController _owner;

        public Action OnFinished { get; set; }

        public ThirdCmd(GameController owner)
        {
            this._owner = owner;
        }

        public void Execute()
        {
            // activate gameobject
            _owner.thirdPopup.gameObject.SetActive(true);

            _owner.thirdPopup.onClose += OnClose;
        }

        private void OnClose()
        {
            _owner.thirdPopup.onClose -= OnClose;

            _owner.thirdPopup.gameObject.SetActive(false);

            OnFinished?.Invoke();
        }
    }
}