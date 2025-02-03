using System.Collections.Generic;
using Ultils;
using UnityEngine;

namespace Camera
{
    public class VirtualCamera : MonoBehaviour
    {
        public UnityEngine.Camera mycamera;

        public Rect screenRect;

        public Vector3 addPos;

        public float yDegree;

        [Range(1f, 100f)]
        public float addspeed;

        public float rectMoveSpeed;

        public AnimationCurve rectMoveCurve;

        public float outMoveSpeed;

        public float screenMoveSpeed;

        public float stopDis;

        public EnumManager.CameraType cameraType;

        public AnimationCurve shakeAttenuation;

        private CameraTarget m_mainTarget;

        private List<CameraTarget> m_targetlist;

        private float m_moveSpeed;

        private Rect m_currectRect;

        private List<ShakePara> m_shakelist;
        
        private void Awake()
        {
            m_shakelist = new List<ShakePara>();
            m_shakelist.Clear();
            m_currectRect = screenRect;
            m_moveSpeed = 0f;
            base.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            m_targetlist = new List<CameraTarget>();
            m_targetlist.Clear();
            // GameSound.GetIns().SetCamera(mycamera.transform, addPos.magnitude);
            float num = Mathf.Atan2(addPos.y, addPos.z) * 57.29578f;
            Debug.Log("camera degreen" + num);
        }
        
        private void LateUpdate()
        {
            Vector3 targetPosition = GetTargetPosition();
            EnumManager.TargetPosType targetPosType = GetTargetPosType();
            if (targetPosType != 0)
            {
                m_moveSpeed = GetCameraSpeed(targetPosition, targetPosType);
                base.transform.position = Vector3.MoveTowards(base.transform.position, targetPosition, Time.deltaTime * m_moveSpeed);
            }
            SetCameraPos();
        }
        
        private void SetCameraPos()
        {
            base.transform.eulerAngles = new Vector3(0f, 0f - yDegree, 0f);
            mycamera.transform.localPosition = addPos;
            mycamera.transform.LookAt(base.transform);
            mycamera.transform.position = mycamera.transform.position + GetShakePos();
        }
        
        private Vector3 GetShakePos()
        {
            Vector3 result = default(Vector3);
            int num = 0;
            while (num < m_shakelist.Count)
            {
                if (m_shakelist[num].ShakeEnd())
                {
                    m_shakelist.RemoveAt(num);
                    continue;
                }
                // if (GameManager.GetGameManager().GetSettingFlag(SettingType.Shake) == 0)
                // {
                //     result += m_shakelist[num].GetPos();
                // }
                m_shakelist[num].AddTime();
                num++;
            }
            return result;
        }
        
        private Vector3 GetTargetPosition()
        {
            TargetCheck();
            Vector3 vector = default(Vector3);
            if (m_mainTarget == null)
            {
                return default(Vector3);
            }
            Vector3 vector2 = default(Vector3);
            float num = 0f;
            if (m_mainTarget != null)
            {
                vector2 = m_mainTarget.target.transform.position;
                num = m_mainTarget.weight;
            }
            Vector3 vector3 = default(Vector3);
            for (int i = 0; i < m_targetlist.Count; i++)
            {
                vector3 = m_targetlist[i].target.transform.position - vector2;
                num += m_targetlist[i].weight;
                vector2 += vector3 * (m_targetlist[i].weight / num);
            }
            return vector2;
        }
        
        private float GetCameraSpeed(Vector3 targetpos, EnumManager.TargetPosType tt)
        {
            float result = 0f;
            if (cameraType == EnumManager.CameraType.LookActor)
            {
                Vector3 vector = targetpos - base.transform.position;
                result = rectMoveSpeed;
                switch (tt)
                {
                    case EnumManager.TargetPosType.InScreenRect:
                    {
                        float magnitude = (base.transform.position - targetpos).magnitude;
                        result = rectMoveSpeed * rectMoveCurve.Evaluate(magnitude);
                        break;
                    }
                    case EnumManager.TargetPosType.OutScreenRect:
                        result = outMoveSpeed;
                        break;
                }
                result = Mathf.MoveTowards(m_moveSpeed, result, Time.deltaTime * addspeed);
            }
            else if (cameraType == EnumManager.CameraType.ScreenMove)
            {
                result = screenMoveSpeed;
            }
            return result;
        }
        
        private void TargetCheck()
        {
            int num = 0;
            while (num < m_targetlist.Count)
            {
                if (m_targetlist[num].target == null)
                {
                    m_targetlist.RemoveAt(num);
                }
                else
                {
                    num++;
                }
            }
        }
        
        private EnumManager.TargetPosType GetTargetPosType()
        {
            TargetCheck();
            if (m_mainTarget == null)
            {
                return EnumManager.TargetPosType.NullTarget;
            }
            Vector3 point = mycamera.WorldToViewportPoint(m_mainTarget.target.transform.position);
            if (m_currectRect.Contains(point))
            {
                return EnumManager.TargetPosType.InScreenRect;
            }
            return EnumManager.TargetPosType.OutScreenRect;
        }
    }
}