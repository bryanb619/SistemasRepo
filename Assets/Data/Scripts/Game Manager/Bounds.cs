using System.Collections;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    /*
    private GameHandler GameDoors;

    // Start is called before the first frame update

    private void Start()
    {
        GameDoors = FindObjectOfType<GameHandler>();
    }

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            // change bool in close and open input
            GameDoors.CanInteract = true;
        }
    }

    private void OnTriggerExit(Collider hit)
    {
        //GameDoors.CanInteract = true;

        StartCoroutine(TimeClearence());

    }

    private IEnumerator TimeClearence()
    {

        
        yield return new WaitForSeconds(1f);
        GameDoors.CanInteract = false;
    }
    */
}
