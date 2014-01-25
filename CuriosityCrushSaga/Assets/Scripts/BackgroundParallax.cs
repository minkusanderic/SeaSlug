using UnityEngine;
using System.Collections;

public class BackgroundParallax : MonoBehaviour
{
    /// <summary>Array of all the backgrounds to be parallaxed.</summary>
    public Transform[] backgrounds;

    /// <summary>The proportion of the camera's movement to move the backgrounds by.</summary>
    public float parallaxScale;

    /// <summary>How much less each successive layer should move.</summary>
    public float parallaxReductionFactor;

    /// <summary>How smooth the parallax effect should be.</summary>
    public float smoothing;

    /// <summary>Shorter reference to the main camera's transform.</summary>
    private Transform cam;

    /// <summary>The postion of the camera in the previous frame.</summary>
    private Vector3 previousCamPos;


    /// <summary>Set up the reference shortcut.</summary>
	void Awake ()
	{
		cam = Camera.main.transform;
	}

    /// <summary>When there is no previous frame, use the current frame's camera position.</summary>
	void Start ()
	{
		previousCamPos = cam.position;
	}

    /// <summary>Advance each paralax layer.</summary>
	void Update ()
	{
        // Compute parallax offset.
		float parallax = (previousCamPos.x - cam.position.x) * parallaxScale;

		// For each successive background...
		for(int i = 0; i < backgrounds.Length; i++)
		{
            // ... set a target x position: frame's current position plus the offset multiplied by reduction.
			float backgroundTargetPosX = backgrounds[i].position.x + parallax * (i * parallaxReductionFactor + 1);

            // Create a target position from the current position and target x.
			Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            // Lerp the background's position between current and target.
			backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
		}

		// Set the previousCamPos to the camera's position at the end of this frame.
		previousCamPos = cam.position;
	}
}
