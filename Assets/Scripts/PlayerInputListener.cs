using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    internal delegate void JumpInputEventHandler(object sender, EventArgs args);

    class PlayerInputListener
    {
        public event JumpInputEventHandler JumpInput;
        private bool m_isJumpButtonDown;

        public void Update()
        {
            if (!m_isJumpButtonDown && Input.GetMouseButtonDown(0))
            {
                m_isJumpButtonDown = true;
                OnJumpInput();
            }
            else if (m_isJumpButtonDown && !Input.GetMouseButtonDown(0))
            {
                m_isJumpButtonDown = false;
            }
        }
        protected virtual void OnJumpInput()
        {
            JumpInputEventHandler handler = JumpInput;
            if (handler != null) handler(this, EventArgs.Empty);
        }

    }
}
