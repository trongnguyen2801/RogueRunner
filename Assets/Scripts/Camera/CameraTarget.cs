using UnityEngine;

namespace Camera
{
    public class CameraTarget
    {
        public GameObject target;

        public float weight;

        public CameraTarget(GameObject t, float w)
        {
            target = t;
            weight = w;
        }
    }
}