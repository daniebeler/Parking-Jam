using UnityEngine;
using UnityEngine.EventSystems;

public class DoneButtonController : MonoBehaviour, IPointerClickHandler
{

    public void OnPointerClick(PointerEventData eventData)
    {
        if (tag == "btnmenu")
        {
            GameObject.FindGameObjectWithTag("donecanvas").GetComponent<DoneSpawner>().DoneFadeOut("Menu");
        }
        else if (tag == "btnnext")
        {
            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level", 0) + 1);
            GameObject.FindGameObjectWithTag("donecanvas").GetComponent<DoneSpawner>().DoneFadeOut("Game");
        }
        else if (tag == "btnreview")
        {
            GameObject.FindGameObjectWithTag("donecanvas").GetComponent<ReviewsManager>().showReview();
        }
    }
}
