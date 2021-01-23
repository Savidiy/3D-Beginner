using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SpeedAnimatorController : MonoBehaviour
{
    [SerializeField] string speedParametrName = "speed";
    Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetSpeed(float speed)
    {
        _animator.SetFloat(speedParametrName, speed);
    }
}
