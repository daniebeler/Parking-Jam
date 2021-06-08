using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    private Camera cam;
    private GameObject Difficulty;
    bool ReadyToCheck = false;

    private RectTransform Checkpoint1;
    private RectTransform Checkpoint2;
    private RectTransform Checkpoint3;
    private RectTransform Checkpoint4;

    public void ImplementationFinished()
    {
        Difficulty = GameObject.FindGameObjectWithTag("difficulty");
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        Checkpoint1 = GameObject.FindGameObjectWithTag("btn9").GetComponent<RectTransform>();
        Checkpoint2 = GameObject.FindGameObjectWithTag("btn19").GetComponent<RectTransform>();
        Checkpoint3 = GameObject.FindGameObjectWithTag("btn29").GetComponent<RectTransform>();
        Checkpoint4 = GameObject.FindGameObjectWithTag("btn39").GetComponent<RectTransform>();
        ReadyToCheck = true;
    }

    void Update()
    {
        if (ReadyToCheck)
        {
            if (Checkpoint4.position.y > Screen.height / 3 * 2)
            {
                if (cam.backgroundColor != new Color32(124, 0, 232, 255))
                {
                    cam.backgroundColor = Color.Lerp(cam.backgroundColor, new Color32(124, 0, 232, 255), 2f * Time.deltaTime);
                    Difficulty.GetComponent<Text>().text = "GRAND MASTER";
                }
            }
            else if (Checkpoint3.position.y > Screen.height / 3 * 2)
            {
                if (cam.backgroundColor != new Color32(235, 39, 39, 255))
                {
                    cam.backgroundColor = Color.Lerp(cam.backgroundColor, new Color32(235, 39, 39, 255), 2f * Time.deltaTime);
                    Difficulty.GetComponent<Text>().text = "EXPERT";
                }
            }
            else if (Checkpoint2.position.y > Screen.height / 3 * 2)
            {
                if (cam.backgroundColor != new Color32(24, 156, 216, 255))
                {
                    cam.backgroundColor = Color.Lerp(cam.backgroundColor, new Color32(24, 156, 216, 255), 2f * Time.deltaTime);
                    Difficulty.GetComponent<Text>().text = "ADVANCED";
                }
            }
            else if (Checkpoint1.position.y > Screen.height / 3 * 2)
            {
                if (cam.backgroundColor != new Color32(247, 147, 35, 255))
                {
                    cam.backgroundColor = Color.Lerp(cam.backgroundColor, new Color32(247, 147, 35, 255), 2f * Time.deltaTime);
                    Difficulty.GetComponent<Text>().text = "INTERMEDIATE";
                }
            }
            else if (cam.backgroundColor != new Color32(21, 161, 86, 255))
            {
                cam.backgroundColor = Color.Lerp(cam.backgroundColor, new Color32(21, 161, 86, 255), 2f * Time.deltaTime);
                Difficulty.GetComponent<Text>().text = "BEGINNER";
            }
        }
    }
}
