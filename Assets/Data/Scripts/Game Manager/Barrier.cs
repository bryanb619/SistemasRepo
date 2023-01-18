using UnityEngine;

public class Barrier : MonoBehaviour
{

    private Collider coll;


    private void Start()
    {
        coll= GetComponent<Collider>();
    }

    /*
    public void DeactivateColl()
    {
        //coll.enabled = false;
    }
    public void ActivateColl()
    {
        //coll.enabled = true;
    }

    /*
    private GameHandler GameDoors;

    // Start is called before the first frame update

    private void Start()
    {
        GameDoors = FindObjectOfType<GameHandler>();    
    }

    private void OnTriggerEnter(Collider hit)
    {
        if(hit.gameObject.tag == "Player")
        {
            // change bool in close and open input
            GameDoors.CanInteract = true;
        }
    }
    */
}
