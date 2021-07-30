using UnityEngine;

public class Finish : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject.FindGameObjectWithTag("scriptholder").GetComponent<Game>().levelDone();
    }
}
