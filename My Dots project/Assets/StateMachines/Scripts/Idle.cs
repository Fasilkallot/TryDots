using UnityEngine;

public class Idle : IState
{
    public void OnEnter()
    {
        Debug.Log("Start idle");
    }

    public void OnExit()
    {
        Debug.Log("Stop idle");
    }

    public void OnHurt()
    {
        Debug.Log("IIIIHH");
    }

    public void OnUpdate()
    {
        Debug.Log("Hrrr Hrrr");
    }
}