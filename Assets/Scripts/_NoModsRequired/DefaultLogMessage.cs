using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple log message that is given the information by some third party to give to the battle log, useful for generic messages
/// 
/// NOTE: Provided with framework, no modification required
/// TODO: Nothing
/// </summary>
public class DefaultLogMessage : IBattleLogMessage
{
    Color messageColour = Color.green;
    string messageBody;

    public Color GetDefaultColor()
    {
        return messageColour;
    }

    public string GetMessageBody()
    {
        return messageBody;
    }

    public DefaultLogMessage(string msg, Color col)
    {
        messageBody = msg;
        messageColour = col;
    }
}
