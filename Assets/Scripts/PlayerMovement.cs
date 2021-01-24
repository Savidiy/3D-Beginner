using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class PlayerMovement : MonoBehaviour
{
    Vector3 _movement;
    Animator _animator;
    Quaternion _rotation;
    Rigidbody _rigidbody;
    AudioSource _audioSource;

    [SerializeField] float turnSpeed = 20f;
    [SerializeField] float moveSpeed = 1f;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _movement.Set(horizontal, 0f, vertical);
        _movement.Normalize();
        _movement *= moveSpeed;

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        _animator.SetBool("isWalking", isWalking);

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, _movement, turnSpeed * Time.deltaTime, 0f);
        _rotation = Quaternion.LookRotation(desiredForward);

        if (isWalking)
        {
            if(_audioSource.isPlaying == false)
            {
                _audioSource.Play();
            }
        }
        else
        {
            if (_audioSource.isPlaying == true)
            {
                _audioSource.Stop();
            }
        }
    }

    private void OnAnimatorMove()
    {
        _rigidbody.MovePosition(_rigidbody.position + _movement * _animator.deltaPosition.magnitude);
        _rigidbody.MoveRotation(_rotation);
    }

    public void SetSpeed(float speed)
    {
        moveSpeed = speed;
    }
}
