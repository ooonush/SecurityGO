using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class CreateQueue
{
    private const int numberOfMessages = 5;

    public static Queue<Message> GetQueueMessages()
    {
        var result = new Queue<Message>();
        var indexesOfSelectedMessages = new List<int>();
        var sr = new StreamReader(@"Assets\Scripts\Events\EventSpamMessages\Messages.txt");
        var messages = sr.ReadToEnd().Split(new char[] { '|' }, System.StringSplitOptions.RemoveEmptyEntries);

        var rnd = new Random();

        while(result.Count < numberOfMessages)
        {
            var index = rnd.Next(0, messages.Length - 1);
            if (!indexesOfSelectedMessages.Contains(index))
            {
                result.Enqueue(new Message(messages[index], index >= messages.Length / 2));
                indexesOfSelectedMessages.Add(index);
            }
        }

        return result;
    }
}
