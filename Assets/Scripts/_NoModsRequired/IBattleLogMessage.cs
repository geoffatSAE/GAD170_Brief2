using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base interface for BattleLogMessages, allows for different types or objects to log themselves out.
/// 
/// NOTE: Provided with framework, no modification required
/// TODO: Nothing
/// </summary>
public interface IBattleLogMessage
{
    Color GetDefaultColor();
    string GetMessageBody();
}
