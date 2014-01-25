using UnityEngine;

/// <summary>Allows backup cats to follow main cat.</summary>
public class FollowPlayer : MonoBehaviour
{
    /// <summary>Cat's place in line; first cat is 1.</summary>
    public int CatRank;
    /// <summary>Cat's quickness when following.</summary>
    public float FollowRate;

    /// <summary>Next location to visit.</summary>
    private Vector3 destination;

    /// <summary>Set initial position/destination to start location.</summary>
    void Start()
    {
        Globals.Positions[CatRank] = destination = transform.position;
    }

    /// <summary>Moves the entity toward its destination.</summary>
    void Update()
    {
        if (destination != Globals.Positions[CatRank])
        {
            Globals.Positions[CatRank + 1] = destination;
            destination = Globals.Positions[CatRank];
        }
        else if (transform.position != destination)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, FollowRate * Time.deltaTime);
        }
    }
}


/* OLD UPDATE:
        float currentDistance = Vector3.Distance(transform.position, player.transform.position);
        if (currentDistance > deadZone)
        {
            float hOffset = transform.position.x - player.transform.position.x;  //Input.GetAxis("Horizontal");
            if (hOffset < 0.0f) { hOffset *= -1f; }
            float vOffset = transform.position.x - player.transform.position.x;  //Input.GetAxis("Vertical");
            if (vOffset < 0.0f) { vOffset *= -1f; }

            transform.LookAt(player.transform.transform);
            Vector2 dir = new Vector2(hOffset, vOffset);
            Debug.Log("***** Dir: " + dir);
            if (dir != Vector2.zero)
            {
                transform.forward = dir;
                transform.forward.Normalize();
                Rigidbody2D body = gameObject.GetComponent<Rigidbody2D>();
                body.velocity = new Vector2(dir * currentDistance, body.velocity.y);
            }
        }

 */