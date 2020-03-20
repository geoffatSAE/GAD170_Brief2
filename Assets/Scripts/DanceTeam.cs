using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Object that holds and represents a Dance Troupe or Team. A list of dancers on the roster, the ones still able to dance.
/// It is also responsible for holding team specific data like where to line them up, their colors, and so on.
/// 
/// TODO: 
///     This needs to handle adding and removing dancers from the active and/or all dancers lists
///     This is where you might add additional feedback for team actions
/// </summary>
public class DanceTeam : MonoBehaviour
{
    const float DancerSpaceing = 2;

    public Color teamColor = Color.white;
    [SerializeField]
    protected string danceTeamName;
    public Transform lineUpStart;
    public Text troupeNameText;
    public List<Character> allDancers;
    public List<Character> activeDancers;
    public GameObject fightWinContainer;

    public void AddNewDancer(Character dancer)
    {
        Debug.LogWarning("AddNewDancer called, it needs to put dancer in both lists and set the dancers team.");
    }

    public void RemoveFromActive(Character dancer)
    {
        Debug.LogWarning("RemoveFromActive called, it needs to take the dancer out of the active list and possibly update selectedness, mojo etc.");
    }


    #region Pre-Existing
    //init prefabs in order and call addnewdancer
    public void InitaliseTeamFromNames(GameObject dancerPrefab, float direction, CharacterName[] names)
    {
        for (int i = 0; i < names.Length; i++)
        {
            //make one
            var newDancer = Instantiate(dancerPrefab, lineUpStart.position + lineUpStart.right * i * DancerSpaceing * direction, dancerPrefab.transform.rotation);
            //fix its rotation, animations are often a pain
            newDancer.transform.forward = -lineUpStart.right;

            //give it a name and add it to the team
            var aChar = newDancer.GetComponent<Character>();
            aChar.AssignName(names[i]);
            AddNewDancer(aChar);
        }
    }

    //called by other scripts, also updates are text element
    public void SetTroupeName(string name)
    {
        danceTeamName = name;
        if (troupeNameText != null)
        {
            troupeNameText.text = name;
        }
    }

    //toggle on the win effect if one exists
    public void EnableWinEffects()
    {
        if (fightWinContainer != null)
        {
            fightWinContainer.SetActive(true);
            var l = fightWinContainer.GetComponentInChildren<Light>();
            if (l != null)
            {
                l.color = teamColor;
            }
        }
    }

    //toggle off win effects is one exists
    public void DisableWinEffects()
    {
        if (fightWinContainer != null)
        {
            fightWinContainer.SetActive(false);
        }
    }
    #endregion
}
