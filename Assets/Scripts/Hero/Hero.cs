using System;
using System.Collections.Generic;
using Game_Input;
using Ultils;
using UnityEngine;
using UnityEngine.AI;
using Weapon;
using Random = UnityEngine.Random;

namespace Hero
{
    public class Hero : ActionBase
    {
        public float hpRateAdd;

        public int heronameid;

        public Sprite icon;

        public Sprite slashIcon;

        public Sprite slashPic;

        public Sprite uicharactericon;

        public Sprite uigamefinishicon;

        // public SkillBase skill;

        // public AfterImageEffects aftereff;

        public HeroCanvas heroCanvas;
        
        public float moveAddSpeed;

        public float lookdes = 10f;

        public int[] passiveSkills;

        public Transform[] leftGunIK;
        
        public Transform[] rightGunIK;

        public Transform m_leftHand;

        public Transform m_rightHand;

        public Transform m_shold;

        public bool canDoubleGun = true;

        public int lootGunNumber = 2;

        // public AudioClip[] footsteps;

        public bool footsteprandom = true;
        
        // [HideInInspector]
        // private UIGamePlay uigameplay;

        // [HideInInspector]
        // public ShootState shootState;

        [HideInInspector]
        public Vector3 m_lookdir;

        [HideInInspector]
        public Vector3 m_targetDir;

        [HideInInspector]
        public Vector3 m_moveDir;

        [HideInInspector]
        public Vector3 MoveInput;

        [HideInInspector]
        public Vector3 ShootInput;

        [HideInInspector]
        public bool ShootEnter;

        [HideInInspector]
        public Vector3 SkillInput;

        [HideInInspector]
        public bool SkillEnter;

        [HideInInspector]
        // public SkillBase UseSkill;

        private int m_shootIndex;

        private int m_gunType;

        private int m_weaponShowFlag;

        private float m_waittime;

        private float m_waitdelay;

        private float m_shaketime;

        private ActorBuff m_shootMoveBuff;

        private List<PlayerWeapon> m_weaponList = new List<PlayerWeapon>();

        private int m_gunIndex;

        private GameObject m_reloardbar;

        private int m_footsteps;
        public AudioClip[] footsteps;

        public int gunType
        {
            get
            {
                return m_gunType;
            }
            set
            {
                m_gunType = value;
                _animator.SetFloat("gunType", m_gunType);
            }
        }
        
        private void Awake()
        {
            m_shootIndex = 0;
            // shootState = ShootState.Hold;
            isDead = false;
            ActorInitData();
            GetComponent<NavMeshAgent>().speed = GetActorAttribute(EnumManager.AttType.MoveSpeed);
            // ReLoadWeapon();
            // ResetAttribute(0, GameManager.GetGameManager().GetPlayerLevel(), 0);
            m_targetDir = base.transform.forward;
            m_lookdir = m_targetDir;
            ShootEnter = false;
        }

        public void FootStep(AnimationEvent p1)
        {
            if (!GetComponent<AudioSource>())
            {
                return;
            }
            if (footsteprandom)
            {
                int num = Random.Range(0, footsteps.Length);
                if (num == m_footsteps)
                {
                    num++;
                    if (num >= footsteps.Length)
                    {
                        num = 0;
                    }
                }
                m_footsteps = num;
            }
            else
            {
                m_footsteps++;
                if (m_footsteps >= footsteps.Length)
                {
                    m_footsteps = 0;
                }
            }
            if (m_footsteps < footsteps.Length)
            {
                GetComponent<AudioSource>().PlayOneShot(footsteps[m_footsteps]);
            }
        }

        private void FixedUpdate()
        {
            Move(GameInputManager.joystick, Time.deltaTime);
        }
    }
}