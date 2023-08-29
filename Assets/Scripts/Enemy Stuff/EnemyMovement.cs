using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public GameObject enemy;
    public NavMeshAgent enemyAI;
    public PlayerHealth methodCalls;
    public string bodyType;

    public Vector3 warpedPosition;

    public MinigameMode HUD;
    public EnemyHealth enemyMethodCalls;

    public bool hitOnce;
    private Vector3 knockbackDirection;

    public GameObject gorillaTarget;

    public enum enemyStates { Chase, Stop, Stunned, Dead};
    public enemyStates currentState;

    private Dictionary<enemyStates, Action> enterState;
    private Dictionary<enemyStates, Action> exitState;
    private Dictionary<enemyStates, Action> executeStates;

    // Start is called before the first frame update
    void Start()
    {
        hitOnce = false;
        enemyAI = enemy.GetComponent<NavMeshAgent>();
        InstaniatedPosition(warpedPosition);

        enterState = new Dictionary<enemyStates, Action>() {
            { enemyStates.Chase, ChaseEnter },
            { enemyStates.Stunned, StunnedEnter },
            { enemyStates.Dead, DeadEnter},
            { enemyStates.Stop, StopEnter}
        };
        exitState = new Dictionary<enemyStates, Action>() {
            { enemyStates.Chase, ChaseExit },
            { enemyStates.Stunned, StunnedExit },
            { enemyStates.Dead, DeadExit},
            {enemyStates.Stop, StopExit }
        };
        executeStates = new Dictionary<enemyStates, Action>() {
            { enemyStates.Chase, ChaseExecute },
            { enemyStates.Stunned, StunnedExecute },
            { enemyStates.Dead, DeadExecute},
            {enemyStates.Stop, StopExecute }
        };

        ChangeStates(enemyStates.Chase);
    }

    // Update is called once per frame
    void Update()
    {
        executeStates[currentState]();
    }

    private void ChangeStates(enemyStates nextState)
    {
        exitState[currentState]();
        currentState = nextState;
        enterState[currentState]();
    }

    // Chase stuff ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    private void ChaseEnter()
    {

    }

    private void ChaseExit()
    {

    }

    private void ChaseExecute()
    {
        enemy.transform.LookAt(gorillaTarget.transform.position);
        enemyAI.destination = gorillaTarget.transform.position;

        if (Vector3.Distance(enemy.transform.position, gorillaTarget.transform.position) < 2 && !hitOnce)
        {
            methodCalls.TakeDamage();
            knockbackDirection = gorillaTarget.transform.position - enemy.transform.position;
            methodCalls.DamageKnockback(knockbackDirection);
            hitOnce = true;
        }

        if (Vector3.Distance(enemy.transform.position, gorillaTarget.transform.position) > 3)
        {
            hitOnce = false;
        }

        if (!HUD.finishedMinigame && HUD.minigameOnOff)
        {
            ChangeStates(enemyStates.Stop);
        }

        if (enemy.GetComponent<EnemyHealth>().stunnedState)
        {
            ChangeStates(enemyStates.Stunned);
        }
    }

    // Stunned Stuff ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    private void StunnedEnter()
    {
        HUD.BodyType(bodyType);
        HUD.WeakPointListGet(enemyMethodCalls.ReturnWeakPointList());
        HUD.ActivateMinigame();
        enemyAI.enabled = false;
    }

    private void StunnedExit()
    {
        HUD.StopMinigame();
        methodCalls.MinigameReset();
    }

    private void StunnedExecute()
    {
        if (HUD.finishedMinigame)
        {
            ChangeStates(enemyStates.Dead);
        }
    }

    // Dead Stuff ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    private void DeadEnter()
    {
        enemyMethodCalls.Dead();
        enemyMethodCalls.transform.DetachChildren();
    }

    private void DeadExit()
    {

    }

    private void DeadExecute()
    {

    }

    // Stop Stuff ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    private void StopEnter()
    {
        enemyAI.enabled = false;
        enemy.GetComponent<NavMeshAgent>().enabled = false;
    }

    private void StopExit()
    {

    }

    private void StopExecute()
    {
        if (HUD.finishedMinigame && !HUD.minigameOnOff)
        {
            enemyAI.enabled = true;
            enemy.GetComponent<NavMeshAgent>().enabled = true;
            ChangeStates(enemyStates.Chase);
        }
    }

    public void InstaniatedPosition(Vector3 newPosition)
    {
        enemyAI.Warp(newPosition);
    }

}
