using UnityEngine;
using System.Collections;

public class PlayASound : MonoBehaviour
{
    /// <summary>Sound is played for a reward.</summary>
    public AudioSource RewardSound;

    void OnTriggerEnter2D(Collider2D collision)
    {
        RewardSound.Play();
    }
}
