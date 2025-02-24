using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    //InputSystem controls;
    public ParticleSystem dust;
    [Header("Movement")]
    private Rigidbody2D rbody;
    private BoxCollider2D coll;
    private Animator anim;
    //Transform selftranform;
    //private SpriteRenderer sprite;
    private float moveX;
    private float moveSpeed = 5f;

    [Header("Double Jump")]
    public float hangTime = .2f;
    private float hangCounter;
    public float JumpBufferLength =.5f;
    private float JumpBufferCount;
    private bool isFacingRight = true;
    [SerializeField]private float jumpForce = 7f;

    [Header("WallJump")]
    private bool isWallSliding;
    private float wallSlidingSpeed=2f;
    private bool isWallJumping;
    private float wallJumpingDirection;
    private float wallJumpingTime = 0.2f;
    private float wallJumpingCounter;
    private float wallJumpingDuration = 0.4f;
    private Vector2 wallJumpingPower = new Vector2(8f, 16f);
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;
    //[SerializeField] private Transform spawnPoint;
    [SerializeField] private LayerMask jumpableGround;

    public float KBForce=2f;
    public float KBCounter=0f;
    public float KBTotalTime=0.2f;
    public bool KnockBackFormRight;

    private bool wasOnGround;


    private enum MovementState { idel, jump, runing, falling}
/*
    private void Awake() {
        controls= new InputSystem();
        controls.Enable();
        controls.Land.Movement.performed+=ctx=>
        {
            moveX=ctx.ReadValue<float>();
        };
        controls.Land.Jump.performed+=ctx=>Jump();
    }
*/
    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        //sprite = GetComponent<SpriteRenderer>();
        rbody = GetComponent<Rigidbody2D>();
        //selftranform = transform;
    }

    // Update is called once per frame
    private void Update()
    {

        if(KBCounter<=0){
            // It's work on unity input Manager 
        moveX = Input.GetAxisRaw("Horizontal"); //if we don't want to slide so then we use raw
        rbody.velocity = new Vector2(moveX * moveSpeed, rbody.velocity.y);
        }
        else{
            if(KnockBackFormRight==true){
                rbody.velocity = new Vector2(-KBForce,KBForce);
            }
            if(KnockBackFormRight==false){
                rbody.velocity = new Vector2(KBForce,KBForce);
            }
                KBCounter-=Time.deltaTime;
        }
        
        //manage HangTime
        if (IsGrounded())
        {
            hangCounter = hangTime;
        }
        else
        {
            hangCounter -= Time.deltaTime;
        }
        //manage JumpBuffer
        if (Input.GetButtonDown("Jump"))
        {
            JumpBufferCount = JumpBufferLength;
            CreatDust();
        }
        else
        {
            JumpBufferCount -= Time.deltaTime;
        }
        //Jump In the air
        if (JumpBufferCount >= 0 && hangCounter > 0f)
        {
            //jumpSoundEffect.Play();
            AudioManager.Instance.PlaySFX("Jump");
            rbody.velocity = new Vector2(rbody.velocity.x, jumpForce);
            JumpBufferCount = 0;
        }
        //Small Jump
        //if (Input.GetButtonUp("Jump") && rbody.velocity.y > 0)
        if (Input.GetButtonUp("Jump") && rbody.velocity.y > 0)
        {
            rbody.velocity = new Vector2(rbody.velocity.x, rbody.velocity.y * .5f);
            AudioManager.Instance.PlaySFX("Jump");
        }
        wasOnGround = IsGrounded();
        UpdateAnimation();
        wallSlide();
        WallJump();
        if (!isWallJumping)
        {
            Flip();
        }
    }

    private void UpdateAnimation()
    {
        MovementState state;
        if (moveX > 0f)
        {
            //move Right
            state = MovementState.runing;
            // sprite.flipX = false;
            //selftranform.rotation = new Quaternion(0, 0, 0, 0);
        }
        else if (moveX < 0f)
        {
            //move Left
            state = MovementState.runing;
            //sprite.flipX = true;
            //selftranform.rotation = new Quaternion(0, -180, 0, 0);
        }
        else
        {
            state = MovementState.idel;
        }
        if (rbody.velocity.y > .1f)
        {
            state = MovementState.jump;
        }
        else if (rbody.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int)state);
    }

    private bool IsWalled(){
        return Physics2D.OverlapCircle(wallCheck.position,0.2f,wallLayer);
    }

    private void wallSlide(){
        if(IsWalled() && !IsGrounded() && moveX !=0f)
        {
            isWallSliding=true;
            //CreatDust();
            rbody.velocity = new Vector2(rbody.velocity.x ,Mathf.Clamp(rbody.velocity.y,-wallSlidingSpeed,float.MaxValue));
            
        }
        else
        {
            isWallSliding=false;
        }

    }
    private bool IsGrounded()
    {
        
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void WallJump()
    {
        if (isWallSliding)
        {
            isWallJumping = false;
            wallJumpingDirection = transform.localScale.x;
            wallJumpingCounter = wallJumpingTime;
            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {
            wallJumpingCounter -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Jump") && wallJumpingCounter > 0f)
        {
            isWallJumping = true;
            dust.Play();
            rbody.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpingCounter = 0f;
            if (transform.localScale.x != wallJumpingDirection)
            {
                dust.Play();
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x = -1f;
                transform.localScale = localScale;
            }
            Invoke(nameof(StopWallJumping), wallJumpingDuration);
        }
    }
    private void StopWallJumping()
    {
        isWallJumping = false;
    }
private void Flip()
    {
        if (isFacingRight && moveX < 0f || !isFacingRight && moveX > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
            //if player is in ground than create dust effect
            if(IsGrounded()){
                CreatDust();
            }
        }
    }

    void CreatDust(){
        dust.Play();
    }
}
