using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    private GameCanvasController gameCanvasController;
    public AdManger adManger;

    void Start()
    {
        gameCanvasController = GameObject.FindGameObjectWithTag("gamecanvas").GetComponent<GameCanvasController>();
        setBackgroundColor();
        adManger.loadInterstitial();
    }

    private void setBackgroundColor()
    {
        Camera cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        if (PlayerPrefs.GetInt("level", 0) < 10)
        {
            cam.backgroundColor = new Color32(21, 161, 86, 255);
        }
        else if (PlayerPrefs.GetInt("level", 0) < 20)
        {
            cam.backgroundColor = new Color32(247, 147, 35, 255);
        }
        else if (PlayerPrefs.GetInt("level", 0) < 30)
        {
            cam.backgroundColor = new Color32(24, 156, 216, 255);
        }
        else if (PlayerPrefs.GetInt("level", 0) < 40)
        {
            cam.backgroundColor = new Color32(235, 39, 39, 255);
        }
        else if (PlayerPrefs.GetInt("level", 0) < 50)
        {
            cam.backgroundColor = new Color32(124, 0, 232, 255);
        }
    }

    public void levelDone()
    {
        if (PlayerPrefs.GetInt("level", 0) >= PlayerPrefs.GetInt("unlockedlevels", 0))
        {
            PlayerPrefs.SetInt("unlockedlevels", PlayerPrefs.GetInt("level", 0) + 1);
        }

        adManger.showInterstitial();
        gameCanvasController.GameFadeOut("Done");
    }
}
