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

        if (difference > 1f)
        {
            Debug.Log("*** Turning right.  Difference: " + difference);
        }
        else if (difference < -1f)
        {
            Debug.Log("*** Turning left.  Difference: " + difference);
        }

        lastPosition = transform.position;
	}
}
