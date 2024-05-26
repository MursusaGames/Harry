using UnityEngine.SceneManagement;
using UnityEngine;

public class ChalangeMenu : MonoBehaviour
{
    [SerializeField] private MatchData data;
    private int _id;
    public void SetLevel(int id)
    {
        switch (id)
        {
            case 1: _id = id+(6*data.fermStage);
                
                break;
            case 2:
                _id = id + (6 * data.oceanStage);
                break;
            case 3:
                _id = id + (6 * data.forestStage);
                break;
            case 4:
                _id = id + (6 * data.gameStage);
                break;
            case 5:
                _id = id + (6 * data.hellStage);
                break;
            case 6:
                _id = id + (6 * data.technoStage);
                break;
        }
        PlayerPrefs.SetInt(Constant.LEVEL, id);
        data.levelNumber = id;
        Invoke(nameof(LoadScene), 1f);
    }
    private void LoadScene()
    {
        SceneManager.LoadScene(_id);
    }
}
