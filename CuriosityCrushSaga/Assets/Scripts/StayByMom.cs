using UnityEngine;
using System.Collections;

/// <summary>Locks this gameobject's position to given gameobject's position.</summary>
public class StayByMom : MonoBehaviour
{
    /// <summary>Game object to stick by.</summary>
    public GameObject mom;

    /// <summary>Move me where I need to be.</summary>
	void Update ()
    {
        if (mom != null)
        {
            transform.position = mom.transform.position;
            transform.rotation = Quaternion.identity;
        }
	}
}
