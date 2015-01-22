using System;
using Assets.Scripts.GameInput;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerMovement : MonoBehaviour, IPlayer
    {

        public float JumpForce = 10.0f;
        public float RunForce = 30.0f;
        public Vector2 MaxVelocity = new Vector2(5, 5);

        private PlayerInput m_inputHandler;
        // Use this for initialization
        void Start () 
        {
            m_inputHandler = new PlayerKeyboardInput(this);
        }

        // Update is called once per frame
        void Update()
        {
            m_inputHandler.Update();
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Platform"), LayerMask.NameToLayer("Player"), !(IsOnGround() || rigidbody2D.velocity.y < 0));

        }

   
        bool IsOnGround()
        {
            var extents = collider2D.bounds.extents;
            var originGroundRay = new Vector2(transform.position.x, transform.position.y - extents.y);
            Debug.DrawRay(originGroundRay, Vector3.down * 0.1f, Color.red, 0.05f);
            var hitGround = Physics2D.Raycast(originGroundRay, -Vector2.up, 0.1f, 1 << LayerMask.NameToLayer("Platform"));
            return hitGround.collider != null;
        }
    


        public void Run(PlayerDirection direction)
        {
            var absSpeed = Math.Abs(rigidbody2D.velocity.x);
            var force = RunForce*Time.deltaTime;
            if (absSpeed < MaxVelocity.x || CurrentDirection() != direction)
                rigidbody2D.AddForce(new Vector2(direction == PlayerDirection.Right? force : -force, 0), ForceMode2D.Impulse);
        }

        PlayerDirection CurrentDirection()
        {
            return rigidbody2D.velocity.x > 0 ? PlayerDirection.Right : PlayerDirection.Left;
        }

     
        private bool CanJumpFromGound()
        {
            return IsOnGround();
        }
        public void JumpFromGround()
        {
            if (!CanJumpFromGound()) return;
                Jump(JumpForce);
        }

        private void Jump(float force)
        {
            if (!(rigidbody2D.velocity.y < MaxVelocity.y)) return;
            var calculatedJumpForce = force;
            transform.rigidbody2D.AddForce(new Vector2(0, calculatedJumpForce), ForceMode2D.Impulse);
        }
        public void BoostUp()
        {
            if(rigidbody2D.velocity.y < 0)
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0);
            Jump(JumpForce);
        }

    }
}
