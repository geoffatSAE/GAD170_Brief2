[System.Serializable]
public class FightEventData
{
    public Character lhs, rhs;

    public FightEventData(Character _lhs, Character _rhs)
    {
        lhs = _lhs;
        rhs = _rhs;
    }
}

[System.Serializable]
public class FightResultData
{
    public Character winner, defeated;
    public float outcome;

    public FightResultData(Character _win, Character _defeat, float outcomeValue)
    {
        winner = _win;
        defeated = _defeat;
        outcome = outcomeValue;
    }
}

/// <summary>
/// Central routing for all game events. These are most commonly subscribed to with a += in an OnEnable and then 
/// unsubed in a OnDisable
/// 
/// NOTE: Provided with framework, no modification required
/// TODO: Nothing
/// </summary>
public static class GameEvents
{
    #region delegate declares
    public delegate void BattleInitialiseDel();
    public delegate void RequestFightersDel();
    public delegate void FightRequestDel(FightEventData data);
    public delegate void FightCompleteDel(FightResultData data);
    public delegate void BattleFinishedDel(DanceTeam winner);
    #endregion

    public static event BattleInitialiseDel OnBattleInitialise;
    public static void IntialiseBattle()
    {
        if (OnBattleInitialise != null)
            OnBattleInitialise();
    }

    public static event RequestFightersDel OnRequestFighters;
    public static void RequestFighters()
    {
        if (OnRequestFighters != null)
            OnRequestFighters();
    }

    public static event FightRequestDel OnFightRequested;
    public static void RequestFight(FightEventData data)
    {
        if (OnFightRequested != null)
            OnFightRequested(data);
    }

    public static event FightCompleteDel OnFightComplete;
    public static void FightCompleted(FightResultData data)
    {
        if (OnFightComplete != null)
            OnFightComplete(data);
    }

    public static event BattleFinishedDel OnBattleFinished;
    public static void BattleFinished(DanceTeam winner)
    {
        if (OnBattleFinished != null)
            OnBattleFinished(winner);
    }
}
