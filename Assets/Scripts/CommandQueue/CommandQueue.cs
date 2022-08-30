using System.Collections.Generic;

namespace CommandQueue
{
    public class CommandQueue
    {
        private readonly Queue<ICommand> _queue;

        // True when a command is running
        private bool _isPending;

        public CommandQueue()
        {
            _queue = new Queue<ICommand>();
            _isPending = false;
        }

        public void Enqueue(ICommand cmd)
        {
            _queue.Enqueue(cmd);

            if(!_isPending)
            {
                DoNext();
            }
        }

        public void DoNext()
        {
            if (_queue.Count == 0)
            {
                return;
            }

            // Get next command
            var cmd = _queue.Dequeue();
            // Command is running now so is pending is true
            _isPending = true;
            // Listen to onfinished event
            cmd.OnFinished += OnCmdFinished;
            // Execute command
            cmd.Execute();
        }

        private void OnCmdFinished()
        {
            _isPending = false;

            DoNext();
        }
    }
}