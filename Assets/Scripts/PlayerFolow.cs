using System.Runtime.InteropServices;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerFolow : MonoBehaviour
    {
        public GameObject Player;
        //When the camera starts chasing the player
        public float ChaseHeight;
        //The initial chase speed
        public float MinChaseSpeed;
        //The highest chase speed
        public float MaxChaseSpeed;
        public float ChaseAcceleration;
        //Current chase speed;
        private float m_chaseSpeed;
        // Use this for initialization
        void Start () {
	
        }
	
        // Update is called once per frame
        void Update () {
            if (Player.transform.position.y > transform.position.y)
            {
               SetTransformY(Player.transform.position.y);
            }
            if (Player.transform.position.y > ChaseHeight)
            {
                if (m_chaseSpeed > 0f)
                {
                    if(m_chaseSpeed < MaxChaseSpeed)
                        m_chaseSpeed += ChaseAcceleration*Time.deltaTime;
                }
                else
                {
                    m_chaseSpeed = MinChaseSpeed;
                }
              SetTransformY(transform.position.y + m_chaseSpeed*Time.deltaTime);
            }
        }

        void SetTransformY(float y)
        {
            var pos = transform.position;
            pos.y = y;
            transform.position = pos;
        }
    }
}
