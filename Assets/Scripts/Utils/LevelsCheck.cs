using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsCheck : MonoBehaviour
{
    [SerializeField] private ChangeWeapon changeWeapon;
    [SerializeField] private Transform parent;
    [SerializeField] private Transform pos;
    [SerializeField] private Transform parent2;
    [SerializeField] private Transform pos2;
    [SerializeField] private LevelController levelController;
    [SerializeField] private MatchData data;
    [SerializeField] private int level;
    public bool kitchen;
    public bool sea;
    public bool desert;
    public bool bugwards;
    public bool hell;
    private int currentLevel;
    public int weaponROW;
    public int weaponColumn;
    void OnEnable()
    {
        changeWeapon.SetWeapon(weaponROW,Random.Range(0,weaponColumn));  
        if (kitchen)
        {
            currentLevel = data.kitchenLevel;
        }
        else if(sea)
        {
            currentLevel = data.seaLevel;
        }
        else if (desert)
        {
            currentLevel = data.desertLevel;
        }
        else if (bugwards)
        {
            currentLevel = data.bugwardsLevel;
        }
        else if (hell)
        {
            currentLevel = data.hellLevel;
        }
        if (level == currentLevel)
        {
            Invoke(nameof(SetWeapons), 2f);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void SetWeapons()
    {
        levelController.GetKnifeInfo(parent, pos, true);
        levelController.GetKnifeInfo(parent2, pos2, false);
    }
}
