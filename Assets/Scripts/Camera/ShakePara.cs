using UnityEngine;

namespace Camera
{
    public class ShakePara
    {
        public float shaketime;

        public AnimationCurve curve;

        public float weight;

        public Vector3 shakevp;

        private float m_delay;

        public bool ShakeEnd()
        {
            if (m_delay >= shaketime)
            {
                return true;
            }
            return false;
        }

        public void AddTime()
        {
            m_delay += Time.deltaTime;
        }

        public Vector3 GetPos()
        {
            return shakevp * curve.Evaluate(m_delay / shaketime) * weight;
        }
    }
}