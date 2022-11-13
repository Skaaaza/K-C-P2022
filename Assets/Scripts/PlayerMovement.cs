using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static Action<Vector2> OnDirectionChange;
    public float speed;
    private Vector2 direction;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        OnDirectionChange.Invoke(Vector2.up);
    }

    void Update()
    {
        TakeInput();
        Move();
    }

    private void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        SetAnimatorMovement(direction);
    }

    private void TakeInput()
    {

        direction = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
            OnDirectionChange.Invoke(direction);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
            OnDirectionChange.Invoke(direction);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
            OnDirectionChange.Invoke(direction);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
            OnDirectionChange.Invoke(direction);
        }
    }

    private void SetAnimatorMovement(Vector2 direction)
    {
        animator.SetFloat("xDir", direction.x);
        animator.SetFloat("xDir", direction.y);
        print(animator.GetFloat("xDir"));
    }
}
                
        