using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DayliPrizeMenu : MonoBehaviour
{
    [SerializeField] private List<GameObject> receiveds;
    [SerializeField] private List<GameObject> btns;
    [SerializeField] private MatchData data;

    private void OnEnable()
    {
        for (int i = 0; i < receiveds.Count; i++)
        {
            if(PlayerPrefs.HasKey(Constant.PRIZE_BAG + i))
            {
                receiveds[i].SetActive(true);
                btns[i].GetComponent<Button>().interactable = false;
            }            
        }
    }
    public void SetReceived(int id)
    {
        receiveds[id].SetActive(true);
        btns[id].GetComponent<Button>().interactable = false;
    }
}
