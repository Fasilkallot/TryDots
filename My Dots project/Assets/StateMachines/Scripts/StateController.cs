
using Unity.VisualScripting;
using UnityEngine;

public class StateController : MonoBehaviour
{
    IState currentState;

    Idle idle;
    Attack attack;
    Patrol patrol;

    private void Start()
    {
        idle = new Idle();
        attack = new Attack();
        patrol = new Patrol();

        currentState = idle;
    }
    private void Update()
    {
       // currentState?.OnUpdate();

        if(Input.GetKeyUp(KeyCode.Space))
        {
            ChangeState(attack);
        }
        if (Input.GetKeyUp(KeyCode.P))
        {
            ChangeState(patrol);
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            ChangeState(idle);
        }

        if (Input.GetMouseButtonDown(0))
        {
            currentState.OnHurt();
        }

    }
    public void ChangeState(IState state)
    {
        currentState?.OnExit();
        currentState = state;
        currentState?.OnEnter();
    }
}


public interface IState
{
    public void OnEnter();
    public void OnExit();
    public void OnUpdate();
    public void OnHurt();
}
