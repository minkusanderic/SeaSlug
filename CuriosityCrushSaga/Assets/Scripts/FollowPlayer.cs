using UnityEngine;

/// <summary>Allows backup cats to follow main cat.</summary>
public class FollowPlayer : MonoBehaviour
{
    /// <summary>Cat's place in line; first cat is 1.</summary>
    public int CatRank;

    /// <summary>Next location to visit.</summary>
    private Vector3 destination;

    /// <summary>What movement mode are we in?</summary>
    private bool scamperMode = false;

    /// <summary>Set initial position/destination to start location.</summary>
    void Start()
    {
        float newX = transform.position.x + Random.Range(-1.5f, 1.5f);
        float newY = transform.position.y + Random.Range(0, 0.5f);
        transform.position = new Vector3(newX, newY, transform.position.z);
        Globals.Positions[CatRank] = destination = transform.position;
    }

    /// <summary>Moves the entity toward its destination.</summary>
    void Update()
    {
        /*
        if (scamperMode)
        {
            if (Globals.Positions[CatRank] != Globals.PlayerPosition)
            {
                Debug.Log("*** Hiho!");
                float step = Globals.FollowRate * Time.deltaTime;
                Vector3 scamper = new Vector3(transform.position.x + Random.Range(-1.5f, 1.5f), Globals.PlayerPosition.y, 0);
                transform.position = Vector3.MoveTowards(transform.position, scamper, step);
            }
        }
        else
        {
            if (destination != Globals.Positions[CatRank])
            {
                Globals.Positions[CatRank + 1] = destination;
                destination = Globals.Positions[CatRank];
            }
            else if (transform.position != destination)
            {
                float step = (Globals.PlayerPosition - transform.position).magnitude * Globals.FollowRate * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, destination, step);
            }
            else
            {
                Debug.Log("*** Cat " + CatRank + " is seeking!");
            }
        }
        */
    }
}
