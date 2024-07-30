
using UnityEngine;

public class Attack : IState
{
    public void OnEnter()
    {
        Debug.Log("Start attack");
    }

    public void OnExit()
    {
        Debug.Log("Stop Attack"); 
    }

    public void OnHurt()
    {
        Debug.Log("AAAAHH");
    }

    public void OnUpdate()
    {
        Debug.Log("Dishum Dishum");
    }
}
