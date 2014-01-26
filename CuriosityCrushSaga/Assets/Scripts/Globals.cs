using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Globals : MonoBehaviour
{
    /// <summary>Cat's quickness when following.</summary>
    public static float FollowRate = 2.666f;
    /// <summary>Player's position.</summary>
    public static Vector3 PlayerPosition = Vector3.zero;
    /// <summary>How far player's followers will let the player get.</summary>
    public static float FollowDeadZone = 1.125f;
    /// <summary>A bunch of Cat positions.</summary>
    public static Vector3[] Positions = {
        Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero,
        Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero };
}
