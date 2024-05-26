using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class GiftSystem : MonoBehaviour
{
    [SerializeField] private MatchData data;
    [SerializeField] private List<Button> giftBtns;    
    [SerializeField] private UserData userData;
    private int date;
    private int index;

    private void OnEnable()
    {
        date = DateTime.Now.DayOfYear;
        if (!PlayerPrefs.HasKey("DateOfYears"))
        {
            PlayerPrefs.SetInt("DateOfYears", date);
            PlayerPrefs.SetInt("FirstsDay", date);
            data.firstDay = date;
        }
        else
        {
            data.firstDay = PlayerPrefs.GetInt("FirstsDay");
            index = date - data.firstDay;
            if (index > 15)
            {
                index = 15;
            }
        }
        for (int i = 0; i <= index; i++)
        {
            //giftBtns[i].gameObject.SetActive(true);
            giftBtns[i].interactable = true;
        } 
    }
    
    
    public void GetPrize(int id)
    {
        PlayerPrefs.SetString(Constant.PRIZE_BAG + id, "yes");
        data.isGift = false;
    }
   
}
