using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Singleton allowing for adding text output to an MMO style text log on screen. Relies on a ScrollRect.
/// 
/// NOTE: Provided with framework, no modification required
/// TODO: Nothing
/// </summary>
public class BattleLog : MonoBehaviour
{
    public static BattleLog instance;
    public GameObject logMessage;
    public ScrollRect scrollRect;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public static void Log(IBattleLogMessage message)
    {
        if(instance == null)
        {
            return;
        }

        GameObject newLog = Instantiate(instance.logMessage, instance.transform);
        newLog.GetComponent<LogHandler>().Init(message);

        instance.StartCoroutine(ScrollToBottom());
    }

    private static IEnumerator ScrollToBottom()
    {
        yield return new WaitForEndOfFrame();
        instance.scrollRect.normalizedPosition = new Vector2(0, 0);
    }
}