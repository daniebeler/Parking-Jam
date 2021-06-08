using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameButtonController : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (gameObject.tag == "btnhome")
        {
            GameObject.FindGameObjectWithTag("gamecanvas").GetComponent<GameCanvasController>().GameFadeOut("Menu");
        }
        else if (gameObject.tag == "btnretry")
        {
            PlayerPrefs.SetInt("justreset", 1);
            SceneManager.LoadScene("Game");
        }
    }
}
