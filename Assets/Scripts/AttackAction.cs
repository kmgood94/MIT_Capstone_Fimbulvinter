
using UnityEngine;
using UnityEngine.Events;

public class AttackAction : MonoBehaviour
{
    public UnityEvent action;

    public void Action()
    {
        action?.Invoke();

    }
}