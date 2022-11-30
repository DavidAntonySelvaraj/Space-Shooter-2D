using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUiController : MonoBehaviour
{




    public static GameOverUiController instance;

    [SerializeField]
    private Canvas playerInfoCanvas, shipsAndMeteorInfoCanvas, GameOverUiCanvas;

    [SerializeField]
    private Text shipsDestroyedInfoFinalTxt, meteorDestroyedInfoFinalTxt, wavesInfoFinalTxt;

    [SerializeField]
    private Text shipsDestroyedHighScorelTxt, meteorDestroyedHighScoreTxt, wavesHighScoreTxt;




    private void Awake()
    {
        if(instance == null)
            instance = this;

        GameOverUiCanvas.enabled = false;
    }

    public void OpenGameOverPannel()
    {
        playerInfoCanvas.enabled = shipsAndMeteorInfoCanvas.enabled = false;

        GameOverUiCanvas.enabled = true;

        int shipsDestroyedFinalCount = GameplayUIController.Instance.GetEnemyDestroyedCount();
        int meteorDestroyedFinalCount = GameplayUIController.Instance.GetMeteorDestroyedCount();
        int waveFinalCount = GameplayUIController.Instance.GetWaveCount();

        waveFinalCount--;

        shipsDestroyedInfoFinalTxt.text = "x" + shipsDestroyedFinalCount;
        meteorDestroyedInfoFinalTxt.text = "x" + meteorDestroyedFinalCount;
        wavesInfoFinalTxt.text = "Wave: " + waveFinalCount;
        //calculate highscore
        CalculateHighScore(shipsDestroyedFinalCount,meteorDestroyedFinalCount,waveFinalCount);

    }    



    public void PlayAgain()
    {
        SceneManager.LoadScene(TagManager.PLAY_AGAIN_LEVEL_NAME);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(TagManager.MAINMENU_LEVEL_NAME);
    }


    void CalculateHighScore(int enemiesCurrentDestroyed, int meteorsCurrentDestroyed, int wavesCurrent)
    {
        int enemiesDestroyedHighScore = DataManager.GetData(TagManager.ENEMIES_DESTROYED_VALUE);
        int meteorsDestroyedHighScore = DataManager.GetData(TagManager.METEOR_DESTROYED_INFO);
        int wavesDestroyedHighScore = DataManager.GetData(TagManager.WAVE_COMPLETED_INFO);

        if (enemiesCurrentDestroyed > enemiesDestroyedHighScore)
            DataManager.SaveData(TagManager.ENEMIES_DESTROYED_VALUE,enemiesCurrentDestroyed);

        if (meteorsCurrentDestroyed > meteorsDestroyedHighScore)
            DataManager.SaveData(TagManager.METEOR_DESTROYED_INFO, meteorsCurrentDestroyed);

        if (wavesCurrent > wavesDestroyedHighScore)
            DataManager.SaveData(TagManager.WAVE_COMPLETED_INFO, wavesCurrent);


        shipsDestroyedHighScorelTxt.text = "x" + DataManager.GetData(TagManager.ENEMIES_DESTROYED_VALUE);
        meteorDestroyedHighScoreTxt.text = "x" + DataManager.GetData(TagManager.METEOR_DESTROYED_INFO);
        wavesHighScoreTxt.text = ""+DataManager.GetData(TagManager.WAVE_COMPLETED_INFO);
    }

}//CLASSS






































