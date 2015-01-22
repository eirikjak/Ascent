using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Pickups
{
    abstract class Pickup : MonoBehaviour
    {
        public void Start()
        {
            collider2D.isTrigger = true;
        }
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                OnPlayerCollision(other.GetComponent<PlayerMovement>());
            }
        }

        protected abstract void OnPlayerCollision(PlayerMovement player);
    }
}
