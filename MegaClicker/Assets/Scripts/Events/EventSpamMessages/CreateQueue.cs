using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CreateQueue
{
    public static Queue<Message> GetQueueMessages()
    {
        var result = new Queue<Message>();

        result.Enqueue(new Message { text = "yes", isSpam = true });
        result.Enqueue(new Message { text = "no", isSpam = false });
        result.Enqueue(new Message { text = "yes", isSpam = true });
        result.Enqueue(new Message { text = "no", isSpam = false });
        result.Enqueue(new Message { text = "yes", isSpam = true });
        result.Enqueue(new Message { text = "no", isSpam = false });
        result.Enqueue(new Message { text = "yes", isSpam = true });
        result.Enqueue(new Message { text = "no", isSpam = false });
        result.Enqueue(new Message { text = "yes", isSpam = true });
        result.Enqueue(new Message { text = "no", isSpam = false });

        return result;
    }
}
