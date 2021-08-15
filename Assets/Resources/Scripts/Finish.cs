using UnityEngine;

public class Finish : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Now calling leveldone");
        GameObject.FindGameObjectWithTag("scriptholder").GetComponent<Game>().levelDone();
    }
}
