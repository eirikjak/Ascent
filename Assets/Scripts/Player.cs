using System;
using Assets.Scripts;
using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public PlayerDirection Direction;
    public float JumpForce = 10.0f;
    public float RunForce = 30.0f;
    public float MaxRunSpeed = 10.0f;

    private PlayerInputListener m_playerInputListener;
    // Use this for initialization
	void Start () 
    {
    
        m_playerInputListener = new PlayerInputListener();
        m_playerInputListener.JumpInput += OnPlayerInput;
	    if (Direction == PlayerDirection.Left)
	        RunForce = -Math.Abs(RunForce);
	    else
	    {
	        RunForce = Math.Abs(RunForce);
	    }
	
    }

    // Update is called once per frame
    void Update()
    {
        m_playerInputListener.Update();
        if (IsOnEdge())
        {
            ToggleDirection();
        }
        if(IsOnGround() && Math.Abs(rigidbody2D.velocity.x) < MaxRunSpeed)
            Run();
        collider2D.enabled = IsOnGround() || rigidbody2D.velocity.y < 0;

     
    }
    void ToggleDirection()
    {
        switch (Direction)
        {
            case PlayerDirection.Left:
                Direction = PlayerDirection.Right;
                break;
            case PlayerDirection.Right:
                Direction = PlayerDirection.Left;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        RunForce *= -1;
        rigidbody2D.velocity = Vector2.zero;
    }
   
    bool IsOnGround()
    {
        var extents = collider2D.bounds.extents;
        var originGroundRay = new Vector2(transform.position.x, transform.position.y - extents.y);
        Debug.DrawRay(originGroundRay, Vector3.down * 0.1f, Color.red, 0.05f);
        var hitGround = Physics2D.Raycast(originGroundRay, -Vector2.up, 0.1f, 1 << LayerMask.NameToLayer("Platform"));
        return hitGround.collider != null;
    }
    
    bool IsOnEdge()
    {
        var extents = collider2D.bounds.extents;
        var originLeftRay = new Vector2(transform.position.x - extents.x, transform.position.y);
        var originRightRay = new Vector2(transform.position.x + extents.x, transform.position.y);

        if (Direction == PlayerDirection.Left)
        {
            Debug.DrawRay(originLeftRay, Vector3.down*extents.y, Color.red, 0.01f);
            var hitLeft = Physics2D.Raycast(originLeftRay, -Vector2.up, extents.y + 0.1f, 1 << LayerMask.NameToLayer("Platform"));
            return hitLeft.collider == null && IsOnGround();
        }
        else
        {
            Debug.DrawRay(originRightRay, Vector3.down * extents.y, Color.red, 0.01f);
            var hitRight = Physics2D.Raycast(originRightRay, -Vector2.up, extents.y + 0.1f, 1 << LayerMask.NameToLayer("Platform"));
            return hitRight.collider == null && IsOnGround();
        }

    }

    void Run()
    {
        
        rigidbody2D.AddForce(new Vector2(RunForce, 0));
    }

    private void OnPlayerInput(object sender, EventArgs args)
    {
            Jump(JumpForce);
    }


    private bool CanJump()
    {
        return IsOnGround();
    }
    public void Jump(float jumpForce)
    {
        if (!CanJump()) return;
        Debug.Log("Jump!");
        transform.rigidbody2D.AddForce(new Vector2(0, jumpForce + 0.5f*jumpForce*Math.Abs(rigidbody2D.velocity.x)), ForceMode2D.Impulse);
    }

}
