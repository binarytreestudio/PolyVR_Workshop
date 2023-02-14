using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalAIController : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] AIState state = AIState.None;
    [Range(0, 360f)] [SerializeField] float rotateAngle = 30;
    [Range(0, 2f)] [SerializeField] float walkSpeed = 0.5f;
    /*[Range(0, 2f)] [SerializeField]*/ float runSpeed = 1f;
    private Vector3 rotatingVcetor = default;

    void Start()
    {
        anim = GetComponent<Animator>();
        InvokeRepeating("RandomStateChange", 0, 4);
    }

    void RandomStateChange()
    {
        ChangeState((AIState)Random.Range(1, 3));
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeState(AIState.Rotating);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            ChangeState(AIState.Idle);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            ChangeState(AIState.WalkingAround);
        }
        switch (state)
        {
            case AIState.Idle:
                break;
            case AIState.Rotating:
                transform.Rotate(rotatingVcetor * Time.deltaTime);
                transform.position += transform.forward * walkSpeed * Time.deltaTime; // adjust to visble speed
                break;
            case AIState.WalkingAround:
                transform.position += transform.forward * walkSpeed * Time.deltaTime; // adjust to visble speed
                break;
            case AIState.FollowFood:
                transform.position += transform.forward * runSpeed * Time.deltaTime; // adjust to visble speed
                break;
            case AIState.Eating:
                break;
        }
    }

    public void ChangeState(AIState state)
    {
        this.state = state;
        switch (state)
        {
            case AIState.Idle:
                anim.SetFloat("Speed_f", 0);
                break;
            case AIState.Rotating:
                anim.SetFloat("Speed_f", 0.5f);
                rotatingVcetor = (Random.value > 0.5f ? Vector3.up : Vector3.down) * rotateAngle;
                break;
            case AIState.WalkingAround:
                anim.SetFloat("Speed_f", 0.5f);
                break;
            case AIState.FollowFood:
                anim.SetFloat("Speed_f", 1f);
                break;
            case AIState.Eating:
                break;
        }
    }

}

public enum AIState
{
    None,
    Idle,
    Rotating,
    WalkingAround,
    FollowFood,
    Eating,

}