using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private Canvas highScoreCanvas, mainMenuCanvas;

    [SerializeField]
    private Text enemiesDesetroyedHS, meteorsDestroyedHS, waveCompletedHS;


    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenCloseHighScore(bool open)
    {
        mainMenuCanvas.enabled = !open;
        highScoreCanvas.enabled = open;

        if(open)
        {
            DisplayHighScore();
        }
    }




    public void DisplayHighScore()
    {
        enemiesDesetroyedHS.text = "x" + DataManager.GetData(TagManager.ENEMIES_DESTROYED_VALUE);
        meteorsDestroyedHS.text = "x" + DataManager.GetData(TagManager.METEOR_DESTROYED_INFO);
        waveCompletedHS.text = "" + DataManager.GetData(TagManager.WAVE_COMPLETED_INFO);
    }


}//class



















