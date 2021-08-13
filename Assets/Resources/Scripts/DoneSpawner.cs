using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoneSpawner : MonoBehaviour
{
    private Button btnMenu;
    private Button btnNext;

    private Text txtWellDone;

    private Camera cam;

    private GameObject goOverlay;
    private Image imgOverlay;

    void Start()
    {

        btnMenu = GameObject.FindGameObjectWithTag("btnmenu").GetComponent<Button>();
        btnNext = GameObject.FindGameObjectWithTag("btnnext").GetComponent<Button>();

        txtWellDone = GameObject.FindGameObjectWithTag("txtwelldone").GetComponent<Text>();

        goOverlay = GameObject.FindGameObjectWithTag("overlay");
        imgOverlay = goOverlay.GetComponent<Image>();

        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
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


        if (PlayerPrefs.GetInt("level", 0) >= 49)
        {
            GameObject.FindGameObjectWithTag("btnnext").SetActive(false);
            btnMenu.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 3.5f, Screen.width / 7);
            btnMenu.transform.position = new Vector2(Screen.width / 2, Screen.height / 16 * 7);
        }
        else
        {
            btnMenu.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 3.5f, Screen.width / 7);
            btnMenu.transform.position = new Vector2(Screen.width / 4, Screen.height / 16 * 7);
            btnNext.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 3.5f, Screen.width / 7);
            btnNext.transform.position = new Vector2(Screen.width / 4 * 3, Screen.height / 16 * 7);
        }

        txtWellDone.transform.position = new Vector2(Screen.width / 2, Screen.height / 16 * 9);

        StartCoroutine(FadeIn());
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

    IEnumerator FadeOut(string strSceneName)
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

        SceneManager.LoadScene(strSceneName);
    }

    public void DoneFadeOut(string strSceneName)
    {
        StartCoroutine(FadeOut(strSceneName));
    }
}
