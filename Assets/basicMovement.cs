using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicMovement : MonoBehaviour
{
    public Animator anim { get; private set; }
    public Rigidbody rbody { get; private set; }

    playerController player;

    protected virtual void Awake()
    {
        anim = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody>();
        player = GetComponent<playerController>();
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {

    }

    public void ZeroVelocity()
    {
        rbody.velocity = Vector3.zero;
        player.xInput = 0;
        player.zInput = 0;
    }

    public void SetVelocity(float _xVelocity, float _zVelocity, float _rotateSpeed)
    {
        Vector3 inputDir = new Vector3(_xVelocity, 0, _zVelocity);
        rbody.MovePosition(transform.position + inputDir * Time.fixedDeltaTime);
        transform.forward = Vector3.Lerp(transform.forward, inputDir, _rotateSpeed * Time.fixedDeltaTime);
    }
}
