using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerSystem : MonoBehaviour
{
    [SerializeField] MatchData data;
    [SerializeField] private List<CustomsDataContainer> containers;
    [SerializeField] private Image knifeImg;
    private int row;
    private int column;
    
    private void Start()
    {
        row = PlayerPrefs.GetInt("row", 0);
        column = PlayerPrefs.GetInt("column", 0);
        LoadCurrentImage();
    }
    private void LoadCurrentImage()
    {
        data.currentKnife = containers[row].CustomsItems[column].CustomSprites;
        data.currentTag = containers[row].CustomsItems[column].CustomNames;
        knifeImg.sprite = data.currentKnife;
    }
    public void SetWeapon(int row, int column)
    {
        PlayerPrefs.SetString("CurentTag", data.currentTag);
        PlayerPrefs.SetInt("row", row);
        PlayerPrefs.SetInt("column", column);
        LoadCurrentImage();
    }
}
