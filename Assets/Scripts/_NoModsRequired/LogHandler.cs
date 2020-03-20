using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Representation of a single item in our batteLog
/// 
/// NOTE: Provided with framework, no modification required
/// TODO: Nothing
/// </summary>
public class LogHandler : MonoBehaviour
{
    Text logText;
    
    public void Init(IBattleLogMessage message)
    {
        logText = GetComponentInChildren<Text>();
        logText.color = message.GetDefaultColor();
        logText.text = message.GetMessageBody();
    }
}
