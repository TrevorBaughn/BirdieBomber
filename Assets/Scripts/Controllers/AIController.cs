using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIController : Controller
{
    public enum AIStates {Idle, Bombed, Alive};
    [SerializeField] protected AIStates currentState;
    protected float timeEnteredCurrentState;

    public BuildingPawn pawn;

    // Start is called before the first frame update
    protected override void Start()
    {
        //add itself to list of ais
        GameManager.instance.ais.Add(this);
        pawn = this.gameObject.GetComponent<BuildingPawn>();

    }
    protected override void OnDestroy()
    {
        //remove itself from list of players
        GameManager.instance.ais.Remove(this);
    }

    public virtual void ChangeState(AIStates newState)
    {
        //remember change state time
        timeEnteredCurrentState = Time.time;
        //change state
        currentState = newState;
    }

    public virtual bool IsTimePassed(float amountOfTime)
    {
        if (Time.time - timeEnteredCurrentState >= amountOfTime)
        {
            return true;
        }
        return false;
    }

    protected abstract void MakeDecisions();

    protected void DoIdleState()
    {
        //do nothing
    }

    protected void DoAliveState()
    {
        pawn.MoveLeft();
    }

    protected void DoBombedState()
    {
        pawn.MoveDown();

        pawn.MoveLeft();
    }
}
