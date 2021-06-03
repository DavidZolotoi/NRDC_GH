using System;

namespace ReminderReciver
{
    public interface IReminderResiver:IDisposable;
    {
        event EventHandler<MessageReceivedEventArgs> MessageReceived;
    }

    public class MessageReceivedEventArgs
    {

    }
}
