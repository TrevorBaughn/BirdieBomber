using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BuildingMover))]
public class BuildingPawn : Pawn
{
    public BuildingMover mover;
    public float fallSpeed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach(PlayerController player in GameManager.instance.players)
        {
            if(collision.gameObject == player.gameObject)
            {
                AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.death);
                GameManager.instance.ActivateGameOverState();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //load mover
        mover = GetComponent<BuildingMover>();
    }

    public void MoveLeft()
    {
        //use the mover to move forward if not null
        if (mover != null)
        {
            mover.MoveLeft(moveSpeed);
        }
    }

    public void MoveDown()
    {
        //use the mover to move forward if not null
        if (mover != null)
        {
            mover.MoveDown(fallSpeed);
        }
    }

    public override void Die()
    {
        Destroy(this.gameObject);
    }
}
