using UnityEngine;

public class Patrol : IState
{
    public void OnEnter()
    {
        Debug.Log("Start Patrol");
    }

    public void OnExit()
    {
        Debug.Log("Stop Patrol");
    }

    public void OnHurt()
    {
        Debug.Log("PPPPHHH");
    }

    public void OnUpdate()
    {
        Debug.Log("Aaravide");
    }
}