using UnityEngine;

public class Finish : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col)
    {
        if (PlayerPrefs.GetInt("level", 0) >= PlayerPrefs.GetInt("unlockedlevels", 0))
        {
            PlayerPrefs.SetInt("unlockedlevels", PlayerPrefs.GetInt("level", 0) + 1);
        }

        GameObject.FindGameObjectWithTag("gamecanvas").GetComponent<GameCanvasController>().GameFadeOut("Done");
    }
}
