using UnityEngine;

/// <summary>Allows backup cats to follow main cat.</summary>
public class FollowPlayer : MonoBehaviour
{
    /// <summary>Cat's place in line; first cat is 1.</summary>
    public int CatRank;

    /// <summary>Next location to visit.</summary>
    private Vector3 destination;

    /// <summary>Next location to wander to.</summary>
    private Vector3 scamperPoint;

    /// <summary>What movement mode are we in?</summary>
    private bool following = true;

    /// <summary>Random displacement when scampering, left.</summary>
    private float hOffsetNega = -2.333f;
    /// <summary>Random displacement when scampering, right.</summary>
    private float hOffsetPosi = 2.333f;

    /// <summary>Set initial position/destination to start location.</summary>
    void Start()
    {
        float newX = transform.position.x + Random.Range(hOffsetNega, hOffsetPosi);
        transform.position = new Vector3(newX, Globals.PlayerPosition.y, transform.position.z);
        Globals.Positions[CatRank] = destination = transform.position;
    }

    /// <summary>Moves the entity toward its destination.</summary>
    void Update()
    {
        if (following) // Seek Mode
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
                scamperPoint = new Vector3(transform.position.x + Random.Range(hOffsetNega, hOffsetPosi), Globals.PlayerPosition.y, 0);
                destination = Globals.Positions[CatRank] = new Vector3(destination.x, Globals.PlayerPosition.y, 0);
                following = false;
            }
        }
        else // Scamper Mode
        {
            if (transform.position != scamperPoint)
            {
                float step = (Globals.PlayerPosition - transform.position).magnitude * Globals.ScamperRate * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, scamperPoint, step);
            }
            else
            {
                following = true;
            }
        }
    }
}
