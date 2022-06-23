using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private bool isTarget = true;

    public void Hit()
    {
        if (isTarget)
        {
            transform.position = TargetBounds.Instance.GetRandomPosition();
            if (GameHandler.Singleton.isPlaying)
            {
                GameHandler.Singleton.Score++;
            }
            
        }
        else if (!GameHandler.Singleton.isPlaying)
        {
            GameHandler.Singleton.Play();

        }
    }

}
