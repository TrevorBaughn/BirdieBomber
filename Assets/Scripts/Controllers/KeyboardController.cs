using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : PlayerController
{
    [Header("Control Key Codes")]
    [SerializeField] private KeyCode moveUp;
    [SerializeField] private KeyCode moveLeft;
    [SerializeField] private KeyCode moveDown;
    [SerializeField] private KeyCode moveRight;
    [SerializeField] private KeyCode dropBomb;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

    }

    protected override void OnDestroy()
    {
        base.OnDestroy();

       
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void ProcessInputs()
    {
        if (Input.GetKey(moveUp))
        {
            pawn.MoveForward();
        }
        if (Input.GetKey(moveDown))
        {
            pawn.MoveBackward();
        }
        if (Input.GetKey(moveRight))
        {
            pawn.MoveRight();
        }
        if (Input.GetKey(moveLeft))
        {
            pawn.MoveLeft();
        }
        if (Input.GetKeyDown(dropBomb))
        {
            pawn.bomb.Drop();
        }
    }
}
