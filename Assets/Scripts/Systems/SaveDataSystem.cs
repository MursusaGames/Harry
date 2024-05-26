using UnityEngine;
using UniRx;
using Unity.VisualScripting;

public class SaveDataSystem : MonoBehaviour
{
    [SerializeField] private MatchData data;
    [SerializeField] private UserData userData;
    [SerializeField] private Sprite defoultSprite;
    [SerializeField] private GetForAppleSystem getForAppleSystem;

    private void Start()
    {
        if (!PlayerPrefs.HasKey(Constant.SOUND))
        {
            PlayerPrefs.SetFloat(Constant.SOUND, 0.5f);            
        }
        if (!PlayerPrefs.HasKey(Constant.MUSIC))
        {
            PlayerPrefs.SetFloat(Constant.MUSIC, 0.5f);            
        }
        if (!PlayerPrefs.HasKey(Constant.VIBRO))
        {
            PlayerPrefs.SetFloat(Constant.VIBRO, 1);            
        }
        if (!PlayerPrefs.HasKey(Constant.SPEED))
        {
            PlayerPrefs.SetFloat(Constant.SPEED, 200F);
        }
        LoadPlayerData();
    }
    private void OnEnable()
    {
        data.monsterDy = false;
    }
    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
            SavePlayerData();
    }

    private void OnApplicationQuit() => SavePlayerData();
    private void OnDestroy()
    {
        SavePlayerData();
    }
    public void SaveData() => SavePlayerData();

    #region LOADS
    private void SavePlayerData()
    {
        //PlayerPrefs.SetInt(Constants.STAGE, data.stage);
        
    }

   
    #endregion

    #region LOADS
    private void LoadPlayerData()
    {
        
        data.levelNumber = PlayerPrefs.GetInt(Constant.LEVEL, 1);
        data.kitchenLevel = PlayerPrefs.GetInt(Constant.kitchenLEVEL, 0);
        data.seaLevel = PlayerPrefs.GetInt(Constant.seaLEVEL, 0);
        data.desertLevel = PlayerPrefs.GetInt(Constant.desertLEVEL, 0);
        data.bugwardsLevel = PlayerPrefs.GetInt(Constant.bugwardsLEVEL, 0);
        data.hellLevel = PlayerPrefs.GetInt(Constant.hellLEVEL, 0);
        data.gameStage = PlayerPrefs.GetInt(Constant.GAMESTAGE,0);
        data.technoStage = PlayerPrefs.GetInt(Constant.TECHNOSTAGE, 0);
        data.forestStage = PlayerPrefs.GetInt(Constant.FORESTSTAGE, 0);
        data.fermStage = PlayerPrefs.GetInt(Constant.FERMSTAGE, 0);
        data.hellStage = PlayerPrefs.GetInt(Constant.HELLSTAGE, 0);
        data.oceanStage = PlayerPrefs.GetInt(Constant.OCEANSTAGE, 0);
        userData.apple.Value = PlayerPrefs.GetInt(Constant.SCORE);
        data.speed = PlayerPrefs.GetFloat(Constant.SPEED);
        if (PlayerPrefs.HasKey("FirstDay"))
        {
            data.firstDay = PlayerPrefs.GetInt("FirstDay");
        }
        data.currentTag = PlayerPrefs.GetString("CurentTag", "Knife");
        if (PlayerPrefs.GetFloat(Constant.SOUND) > 0)
        {
            data.sound = true;
        }
        else
        {
            data.sound = false;
        }

        if (PlayerPrefs.GetFloat(Constant.MUSIC) > 0)
        {
            data.music = true;
        }
        else
        {
            data.music = false;
        }

        if (PlayerPrefs.GetFloat(Constant.VIBRO) == 1)
        {
            data.vibro = true;
        }
        else
        {
            data.vibro = false;
        }
    }
   
    #endregion
}
