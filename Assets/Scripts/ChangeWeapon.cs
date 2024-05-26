using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    [SerializeField] MatchData data;
    [SerializeField] private List<CustomsDataContainer> containers;
    
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
    }
    public void SetWeapon(int row, int column)
    {
        PlayerPrefs.SetString("CurentTag", data.currentTag);
        PlayerPrefs.SetInt("row", row);
        PlayerPrefs.SetInt("column", column);
        LoadCurrentImage();
    }
}
