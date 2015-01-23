using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Assets.Scripts.LevelGenerator
{
    class PlatformGenerator
    {
        private readonly float m_levelWidth;
        private readonly float[] m_platformWidths;
        private readonly Vector2 m_maxPlatformDistance;
        private readonly Vector2 m_minPlatformDistance;

        private Vector2 m_lastPlatform;
        public PlatformGenerator(float levelWidth, float [] platformWidths, Vector2 minPlatformDistance, Vector2 maxPlatformDistance)
        {
            m_levelWidth = levelWidth;
            m_platformWidths = platformWidths;
            m_maxPlatformDistance = maxPlatformDistance;
            m_minPlatformDistance = minPlatformDistance;
            m_lastPlatform = new Vector2(levelWidth/2 - m_platformWidths[0]/2, 0f);
        }

        public Vector2 GetNextPlatformPosition()
        {
            
      
            //Only one type of platform for now
            var platformWidth = m_platformWidths[0];
            var nextPlatform = new Vector2(Random.Range(0, m_levelWidth), m_lastPlatform.y + Random.Range(m_minPlatformDistance.y, m_maxPlatformDistance.y));
            m_lastPlatform = nextPlatform;
            return nextPlatform;
        }
    }

    
}
