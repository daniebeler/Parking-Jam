using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameCanvasController : MonoBehaviour
{
    private GameObject currentLevel, btnReset, btnHome;

    private GameObject goOverlay;
    private Image imgOverlay;

    void Start()
    {
        goOverlay = GameObject.FindGameObjectWithTag("overlay");
        imgOverlay = goOverlay.GetComponent<Image>();

        currentLevel = GameObject.FindGameObjectWithTag("currentleveltext");
        btnReset = GameObject.FindGameObjectWithTag("btnretry");
        btnHome = GameObject.FindGameObjectWithTag("btnhome");
        currentLevel.transform.position = new Vector2(Screen.width / 2, (Screen.height - Screen.width) / 3.5f);
        currentLevel.GetComponent<Text>().text = "Level " + (PlayerPrefs.GetInt("level", 0) + 1).ToString();

        btnReset.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 4f, Screen.width / 8f);
        btnHome.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 4f, Screen.width / 8f);

        btnReset.GetComponent<RectTransform>().anchoredPosition = new Vector2(Screen.width / -4, Screen.width / -4);
        btnHome.GetComponent<RectTransform>().anchoredPosition = new Vector2(Screen.width / 4, Screen.width / -4);

        

        if (PlayerPrefs.GetInt("justreset", 0) == 0)
        {
            StartCoroutine(FadeIn());
        }
        else
        {
            goOverlay.SetActive(false);
            PlayerPrefs.SetInt("justreset", 0);
        }
    }

    IEnumerator FadeIn()
    {
        goOverlay.SetActive(true);
        if (PlayerPrefs.GetInt("level", 0) < 10)
        {
            imgOverlay.color = new Color32(21, 161, 86, 255);
        }
        else if (PlayerPrefs.GetInt("level", 0) < 20)
        {
            imgOverlay.color = new Color32(247, 147, 35, 255);
        }
        else if (PlayerPrefs.GetInt("level", 0) < 30)
        {
            imgOverlay.color = new Color32(24, 156, 216, 255);
        }
        else if (PlayerPrefs.GetInt("level", 0) < 40)
        {
            imgOverlay.color = new Color32(235, 39, 39, 255);
        }
        else
        {
            imgOverlay.color = new Color32(124, 0, 232, 255);
        }

        while (imgOverlay.color.a > 0)
        {
            imgOverlay.color = new Color(imgOverlay.color.r, imgOverlay.color.g, imgOverlay.color.b, imgOverlay.color.a - Time.deltaTime * 2);
            yield return null;
        }
        goOverlay.SetActive(false);
    }

    IEnumerator FadeOut(string newScene)
    {
        goOverlay.SetActive(true);
        if (PlayerPrefs.GetInt("level", 0) < 10)
        {
            imgOverlay.color = new Color32(21, 161, 86, 0);
        }
        else if (PlayerPrefs.GetInt("level", 0) < 20)
        {
            imgOverlay.color = new Color32(247, 147, 35, 0);
        }
        else if (PlayerPrefs.GetInt("level", 0) < 30)
        {
            imgOverlay.color = new Color32(24, 156, 216, 0);
        }
        else if (PlayerPrefs.GetInt("level", 0) < 40)
        {
            imgOverlay.color = new Color32(235, 39, 39, 0);
        }
        else
        {
            imgOverlay.color = new Color32(124, 0, 232, 0);
        }
        float fZwischenergebnis = 1;
        while (imgOverlay.color.a < 1)
        {
            fZwischenergebnis -= Time.deltaTime * 2;
            imgOverlay.color = new Color(imgOverlay.color.r, imgOverlay.color.g, imgOverlay.color.b, 1 - fZwischenergebnis);
            yield return null;
        }

        SceneManager.LoadScene(newScene);
    }

    public void GameFadeOut(string newScene)
    {
        StartCoroutine(FadeOut(newScene));
    }
}
