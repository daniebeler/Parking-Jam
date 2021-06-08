using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour, IPointerClickHandler
{
    private string FullName = "";
    private int level = 0;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (gameObject.tag == "btninstagram")
        {
            Application.OpenURL("https://www.instagram.com/daniebeler/");
        }
        else
        {
            FullName = gameObject.tag;
            if (FullName.Length == 4)
            {
                level = int.Parse(FullName[3].ToString());
            }
            else if (FullName.Length == 5)
            {
                level = int.Parse(FullName[3].ToString() + FullName[4].ToString());
            }

            PlayerPrefs.SetInt("level", level);
            GameObject.FindGameObjectWithTag("menucanvas").GetComponent<MenuSpawner>().MenuFadeOut();
        }
    }
}
