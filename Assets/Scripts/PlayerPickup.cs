using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerPickup : MonoBehaviour {

        // Use this for initialization
        private PlayerMovement m_playerControl;
        void Start ()
        {
            m_playerControl = GetComponent<PlayerMovement>();
        }
	
        // Update is called once per frame
        void Update () {
	
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            
        }
    }
}
