using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message
{
    public string text { get; set; }
    public bool isSpam { get; set; }

    public Message (string text, bool isSpam)
    {
        this.text = text;
        this.isSpam = isSpam;
    }
}
