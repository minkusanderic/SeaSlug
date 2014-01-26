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

    /// <summary>Set initial positions.</summary>
    void Start()
    {
        lastPosition = transform.position;
    }

    /// <summary>Turn around after certain number of frames.</summary>
	void Update()
    {
        /*
        frameCount += Time.deltaTime;
        if (frameCount >= FrameThreshold)
        {

        }
        */

        if (transform.position.x - lastPosition.x >= 0)
        {
            Debug.Log("*>*>*> Setting scale to: " + new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, 0f) );
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, 0f);
        }
        else
        {
            Debug.Log("------ Setting scale to: " + new Vector3(Mathf.Abs(transform.localScale.x) * -1f, transform.localScale.y, 0f) );
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1f, transform.localScale.y, 0f);
        }
	}
}
