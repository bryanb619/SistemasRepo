using System.Collections;
using UnityEngine;

public class ElevatorZone : MonoBehaviour
{
    private GameHandler GameDoors;
    /*
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
        if (hit.gameObject.tag == "Player")
        {
            // change bool in close and open input
            GameDoors.CanInteract = false;
            StartCoroutine(TimeClearence());
        }

    }
    private IEnumerator TimeClearence()
    {


        yield return new WaitForSeconds(2f);
        GameDoors.CanInteract = false;
    }
    */
}
