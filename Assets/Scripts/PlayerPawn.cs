using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerPawn : Pawn
{
    private PlayerMover mover;
    public Bomb bomb;

    // Start is called before the first frame update
    private void Start()
    {
        //load mover
        mover = GetComponent<PlayerMover>();
    }

    public override void Die()
    {
        Destroy(this.gameObject);
    }

    public void MoveForward()
    {
        //use the mover to move forward if not null
        if (mover != null)
        {
            mover.MoveForward(moveSpeed);
        }
    }
    public void MoveBackward()
    {
        //use the mover to move backward if not null
        if (mover != null)
        {
            mover.MoveForward(-moveSpeed);
        }
    }
    public void MoveRight()
    {
        //use the mover to move backward if not null
        if (mover != null)
        {
            mover.MoveRight(moveSpeed);
        }
    }
    public void MoveLeft()
    {
        //use the mover to move backward if not null
        if (mover != null)
        {
            mover.MoveRight(-moveSpeed);
        }
    }
}
