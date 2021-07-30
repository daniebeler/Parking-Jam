using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Launcher : MonoBehaviour
{
    public Text txtName;
    public AdManger adManger;

    void Start()
    {

        PlayerPrefs.SetInt("level", 0);
        StartCoroutine(FadeIn());
        StartCoroutine(StartFadeOut());

        adManger.init();
        //adManger.RequestBanner();   
    }

    IEnumerator StartFadeOut()
    {
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeIn()
    {
        txtName.GetComponent<Text>().color = new Color32(21, 161, 86, 0);
        float fZwischenergebnis = 1;
        while (txtName.GetComponent<Text>().color.a < 1)
        {
            fZwischenergebnis -= Time.deltaTime * 2;
            txtName.GetComponent<Text>().color = new Color(1, 1, 1, 1 - fZwischenergebnis);
            yield return null;
        }
    }

    IEnumerator FadeOut()
    {
        while (txtName.GetComponent<Text>().color.a > 0)
        {
            txtName.GetComponent<Text>().color = new Color(1, 1, 1, txtName.GetComponent<Text>().color.a - Time.deltaTime * 2);
            yield return null;
        }

        SceneManager.LoadScene("Menu");
    }
}
