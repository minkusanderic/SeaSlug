﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Globals : MonoBehaviour
{
    /// <summary>Cat's quickness when messing about.</summary>
    public static float ScamperRate = 0.25f;
    /// <summary>Cat's quickness when following.</summary>
    public static float FollowRate = 2.666f;
    /// <summary>Player's position.</summary>
    public static Vector3 PlayerPosition = new Vector3(105f, 125f, 0f);
    /// <summary>How far player's followers will let the player get.</summary>
    public static float FollowDeadZone = 1.125f;
    /// <summary>A bunch of Cat positions.</summary>
    public static Vector3[] Positions = {
        Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero,
        Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero };
}
