using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombReturner : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach(Bomb bomb in GameManager.instance.bombs)
        {

            if (collision.gameObject == bomb.gameObject)
            {
                bomb.AttachToPlayer();
            }

        }
    }
}
