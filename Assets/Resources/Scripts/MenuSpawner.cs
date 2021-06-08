using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuSpawner : MonoBehaviour
{
    private GameObject ButtonToSpawn;
    private GameObject LockedButtonToSpawn;
    private GameObject LoadedButton;
    private RectTransform txtDifficulty;
    private RectTransform scrollView;
    private RectTransform Content;
    private Vector2 spawnPos;
    private RectTransform txtFollowMe;
    private RectTransform btnInstagram;

    private GameObject goOverlay;
    private Image imgOverlay;

    void Start()
    {
        //PlayerPrefs.SetInt("unlockedlevels", 45);     //Cheat

        ButtonToSpawn = Resources.Load("Prefabs/Button", typeof(GameObject)) as GameObject;
        LockedButtonToSpawn = Resources.Load("Prefabs/LockedButton", typeof(GameObject)) as GameObject;
        Content = GameObject.FindGameObjectWithTag("ScrollViewContent").GetComponent<RectTransform>();
        txtDifficulty = GameObject.FindGameObjectWithTag("difficulty").GetComponent<RectTransform>();
        txtFollowMe = GameObject.FindGameObjectWithTag("txtfollowme").GetComponent<RectTransform>();
        btnInstagram = GameObject.FindGameObjectWithTag("btninstagram").GetComponent<RectTransform>();
        scrollView = GameObject.FindGameObjectWithTag("scrollview").GetComponent<RectTransform>();
        goOverlay = GameObject.FindGameObjectWithTag("overlay");
        imgOverlay = goOverlay.GetComponent<Image>();

        scrollView.offsetMax = new Vector2(0, Screen.height / -6);
        txtDifficulty.anchoredPosition = new Vector2(0, Screen.height / -12);

        for (int i = 0; i < 50; i++)
        {
            if (i % 2 == 0)
            {
                spawnPos.x = Screen.width / 4;
                spawnPos.y = -1 * (Screen.width / 4 * Mathf.Ceil(i / 2) + Screen.width / 4);
            }
            else
            {
                spawnPos.x = Screen.width / 4 * 3;
                spawnPos.y = -1 * (Screen.width / 4 * Mathf.Ceil(i / 2) + Screen.width / 4);
            }
            if (i <= PlayerPrefs.GetInt("unlockedlevels", 0))
            {
                LoadedButton = Instantiate(ButtonToSpawn, spawnPos, Quaternion.identity);
                LoadedButton.transform.SetParent(GameObject.FindGameObjectWithTag("ScrollViewContent").transform, false);
                LoadedButton.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 2.5f, Screen.width / 5);
                LoadedButton.tag = "btn" + i.ToString();
                LoadedButton.GetComponent<Button>().GetComponentInChildren<Text>().text = (i + 1).ToString();
                LoadedButton.GetComponent<Button>().GetComponentInChildren<Text>().font = Resources.Load("Fonts/Aqum", typeof(Font)) as Font;
                if (i > 39)
                {
                    LoadedButton.GetComponent<Button>().GetComponentInChildren<Text>().color = new Color32(124, 0, 232, 255);
                }
                else if (i > 29)
                {
                    LoadedButton.GetComponent<Button>().GetComponentInChildren<Text>().color = new Color32(235, 39, 39, 255);
                }
                else if (i > 19)
                {
                    LoadedButton.GetComponent<Button>().GetComponentInChildren<Text>().color = new Color32(24, 156, 216, 255);
                }
                else if (i > 9)
                {
                    LoadedButton.GetComponent<Button>().GetComponentInChildren<Text>().color = new Color32(247, 147, 35, 255);
                }
                else
                {
                    LoadedButton.GetComponent<Button>().GetComponentInChildren<Text>().color = new Color32(21, 161, 86, 255);
                }
            }
            else
            {
                LoadedButton = Instantiate(LockedButtonToSpawn, spawnPos, Quaternion.identity);
                LoadedButton.transform.SetParent(GameObject.FindGameObjectWithTag("ScrollViewContent").transform, false);
                LoadedButton.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 2.5f, Screen.width / 5);
                LoadedButton.tag = "btn" + i.ToString();
                if (i > 39)
                {
                    LoadedButton.GetComponent<Button>().GetComponent<Image>().sprite = Resources.Load("Sprites/Buttons/LockedViolet", typeof(Sprite)) as Sprite;
                }
                else if (i > 29)
                {
                    LoadedButton.GetComponent<Button>().GetComponent<Image>().sprite = Resources.Load("Sprites/Buttons/LockedRed", typeof(Sprite)) as Sprite;
                }
                else if (i > 19)
                {
                    LoadedButton.GetComponent<Button>().GetComponent<Image>().sprite = Resources.Load("Sprites/Buttons/LockedBlue", typeof(Sprite)) as Sprite;
                }
                else if (i > 9)
                {
                    LoadedButton.GetComponent<Button>().GetComponent<Image>().sprite = Resources.Load("Sprites/Buttons/LockedOrange", typeof(Sprite)) as Sprite;
                }
                else
                {
                    LoadedButton.GetComponent<Button>().GetComponent<Image>().sprite = Resources.Load("Sprites/Buttons/LockedGreen", typeof(Sprite)) as Sprite;
                }
            }
        }

        txtFollowMe.position = new Vector2(0, GameObject.FindGameObjectWithTag("btn49").transform.position.y - Screen.width / 3);
        btnInstagram.position = new Vector2(0, txtFollowMe.transform.position.y - Screen.width / 6);
        Content.sizeDelta = new Vector2(Content.sizeDelta.x, btnInstagram.transform.position.y * -1 + Screen.width / 3);
        GetComponent<MenuController>().ImplementationFinished();

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

    IEnumerator FadeOut()
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

        SceneManager.LoadScene("Game");
    }

    public void MenuFadeOut()
    {
        StartCoroutine(FadeOut());
    }
}
