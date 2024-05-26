using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchScreenSystem : MonoBehaviour 
{
    RectTransform knifeParent;    
    [SerializeField] GamePlaySystem playSystem;
    [SerializeField] private GamePlayMenu playMenu;
    [SerializeField] private GameObject winWindow;    
    [SerializeField] private MatchData data;
    [SerializeField] private StageControllerSystem stageController;
    public GameObject _halfMonster;
    private Knife _knife;
    private int count;
    private bool win;
    

    private void OnEnable()
    {
        
    }
    public void GetKnifeParent(RectTransform _knifeParent)
    {
        knifeParent = _knifeParent;
    }
    public void GetKnife(Knife knife)
    {
        _knife = knife;        
    }
    public void SetKnifeParent(Knife knife)
    {
        knife.gameObject.transform.SetParent(knifeParent);
        
    }
    

    public void Go()
    {
        _knife.KnifeGo();
    }  
}
