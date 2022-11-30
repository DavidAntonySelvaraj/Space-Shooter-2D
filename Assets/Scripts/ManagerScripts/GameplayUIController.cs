using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUIController : MonoBehaviour
{


    public static GameplayUIController Instance;

    [SerializeField]
    private Text waveInfoText, meteorDestroyedInfoText,enemyDestroyedInfoText;

    private int waveCount, meteorDestroyedCount, enemyDestroyedCount;


    private void Awake()
    {
        if(Instance==null)
            Instance = this;    
    }

    public void SetWave()
    {
        waveCount++;
        waveInfoText.text = "Wave: " + waveCount;
    }

    public void SetEnemyDestroyed()
    {
        enemyDestroyedCount++;
        enemyDestroyedInfoText.text = enemyDestroyedCount + "x";
    }

    public void SetMeteorDestroyed()
    {
        meteorDestroyedCount++;
        meteorDestroyedInfoText.text = meteorDestroyedCount + "x";
    }

    public int GetMeteorDestroyedCount()
    {
        return meteorDestroyedCount;
    }

    public int GetEnemyDestroyedCount()
    {
        return enemyDestroyedCount;
    }

    public int GetWaveCount()
    {
        return waveCount;
    }

    public void SetInfo(int infoType)
    {
        switch(infoType)
        {
            case 1:
                waveCount++;
                waveInfoText.text = "Wave: " + waveCount;
                break;

            case 2:
                enemyDestroyedCount++;
                enemyDestroyedInfoText.text = enemyDestroyedCount + "x";
                break;

            case 3:
                meteorDestroyedCount++;
                meteorDestroyedInfoText.text = meteorDestroyedCount + "x";
                break;
        }
    }



}//class
























