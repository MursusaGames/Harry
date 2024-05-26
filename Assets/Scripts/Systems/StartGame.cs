using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Security.Cryptography;

public class StartGame : MonoBehaviour
{
    [SerializeField] private MatchData data;
    private int _id;
    private void OnEnable()
    {
        var id = data.levelNumber;
        switch (id)
        {
            case 1:
                _id = id + (6 * data.fermStage);
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
        SceneManager.LoadScene(_id);           
    }
}
