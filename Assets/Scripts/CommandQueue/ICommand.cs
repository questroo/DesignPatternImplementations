using System;
namespace CommandQueue
{
    public interface ICommand
    {
        Action OnFinished { get; set; }

        void Execute();
    }
}
