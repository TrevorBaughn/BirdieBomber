using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingMover : Mover
{
    protected override void Start()
    {
        base.Start();
    }

    public void MoveLeft(float speed)
    {
        //move position of rigidbody rank forward at speed
        rigidbodyComponent.MovePosition(transform.position -= (transform.right * (speed * Time.deltaTime)));
    }

    public void MoveDown(float speed)
    {
        rigidbodyComponent.MovePosition(transform.position -= (transform.up * (speed * Time.deltaTime)));
    }
}
