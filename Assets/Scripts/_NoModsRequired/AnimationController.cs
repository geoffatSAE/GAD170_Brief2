using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Routes game state and to the unity animator on this GO/children, also handles display of built in feedback such as character mojo
/// 
/// NOTE: Provided with framework, no modification required
/// TODO: Nothing
/// </summary>
public class AnimationController : MonoBehaviour
{
    private Animator anim;
    public Light ourSpot;
    public float baseLightInten, selectedInten, defeatedInten;
    public float lightIntenLerpSpeed = 10;
    protected Character character;
    public AnimationCurve mojoToSpeedCurve = AnimationCurve.Linear(0, 1, 1, 1);

    [SerializeField]
    protected Image hpImage;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        character = GetComponentInChildren<Character>();
    }

    private void OnEnable()
    {
        //GameEvents.OnBattleBegin += Dance;
        GameEvents.OnFightComplete += BattleResult;
    }

    private void OnDisable()
    {
        //GameEvents.OnBattleBegin -= Dance;
        GameEvents.OnFightComplete -= BattleResult;
    }

    public void BattleResult(FightResultData data)
    {
        if (data.winner.gameObject == gameObject)
        {
            anim.SetTrigger("Win");
        }
        else if (data.defeated.gameObject == gameObject)
        {
            if (data.outcome == 0)
            {
                anim.SetTrigger("Win");
            }
            else
            {
                anim.SetTrigger("Lose");
            }
        }
    }

    private void Update()
    {
        ourSpot.intensity = Mathf.Lerp(ourSpot.intensity, character.isSelected ? selectedInten : baseLightInten, lightIntenLerpSpeed * Time.deltaTime);
        ourSpot.intensity = Mathf.Lerp(defeatedInten, ourSpot.intensity, character.mojoRemaining);
        anim.speed = mojoToSpeedCurve.Evaluate(1 - character.mojoRemaining);

        if (hpImage != null)
        {
            hpImage.fillAmount = Mathf.Lerp(hpImage.fillAmount, character.mojoRemaining, Time.deltaTime);
        }
    }

    public void Dance()
    {
        anim.SetTrigger("Dance");
    }
}
