using UnityEngine;
using System.Collections;


public class FollowPlayer : MonoBehaviour
{
    public int catRank;

    void Update()
    {
        if (transform.position != Globals.positions[catRank])
        {
            Globals.positions[catRank + 1] = transform.position;
            transform.position = Globals.positions[catRank];
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