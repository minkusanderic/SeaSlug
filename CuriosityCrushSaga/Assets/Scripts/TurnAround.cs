using UnityEngine;
using System.Collections;

public class TurnAround : MonoBehaviour
{
    /// <summary>How many frames to count before turning.</summary>
    public float FrameThreshold;

    /// <summary>Frames counted this turn.</summary>
    private float frameCount;

    /// <summary>Where we were, last we checked.</summary>
    private Vector3 lastPosition;

    /// <summary>Turn around after certain number of frames.</summary>
	void Update()
    {
        /*
        frameCount += Time.deltaTime;
        if (frameCount >= FrameThreshold)
        {

        }
        */

        float difference = (transform.position.x - lastPosition.x);

        Debug.Log(">>> Difference: " + difference);

        if (difference > 1)
        {
            Debug.Log("*** Turning right." );
            transform.RotateAround(Vector3.zero, Vector3.up, 0);
        }
        else if (difference < 1)
        {
            Debug.Log("*** Turning left." );
            transform.RotateAround(Vector3.zero, Vector3.up, 180);
        }

        lastPosition = transform.position;
	}
}
