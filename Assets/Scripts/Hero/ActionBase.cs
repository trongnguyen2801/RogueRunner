using System.Collections.Generic;
using Ultils;
using UnityEngine;
using UnityEngine.AI;

namespace Hero
{
    public class ActionBase: MonoBehaviour
    {
        public string actorId;
        
        public GameObject deadAnim;
        
        [SerializeField]
        protected float lifeBase = 10f;

        [SerializeField]
        protected float defense = 1f;

        [SerializeField]
        protected float moveSpeed = 1f;

        [SerializeField]
        protected float attackSpeed = 1f;

        [SerializeField]
        protected float damage = 1f;

        [SerializeField]
        protected float damageRate = 1f;

        [SerializeField]
        protected float crit = 5f;

        [SerializeField]
        protected float critdmg = 150f;
        
        public float loadSize = 1f;

        public Animator _animator;

        [HideInInspector]
        public float _lifePercent = 1f;

        [HideInInspector]
        public bool isSummon;

        [HideInInspector]
        public bool isDead;
        
        protected Dictionary<EnumManager.AttType, float> m_attribute;

        protected Dictionary<EnumManager.AttType, float> m_baseattribute;

        protected List<ActorBuff> _buffList;

        // protected Dictionary<EnumManager.AttType, EffectBuff> m_effectBuffList;

        protected int _baseLayer;

        protected int _level;

        protected int _typeindex;

        // protected PassiveAttribute m_passiveAttribute;

        private Transform _bufftrans;

        private Rigidbody _rb;
        
        private NavMeshAgent _agent;
        
        public bool IsBoss
        {
            get
            {
                if (_typeindex == 4)
                {
                    return true;
                }
                return false;
            }
        }

        public int BaseLayer
        {
            get
            {
                return _baseLayer;
            }
            set
            {
                _baseLayer = value;
            }
        }
        
        private void Awake()
        {
            ActorInitData();
            ResetAttribute(0, 199, 0);
        }
        
        public virtual void ActorInitData()
        {
            _rb = GetComponent<Rigidbody>();
            _agent = GetComponent<NavMeshAgent>();
            _bufftrans = null;
            _buffList = new List<ActorBuff>();
            _buffList.Clear();
            m_baseattribute = new Dictionary<EnumManager.AttType, float>();
            m_baseattribute.Clear();
            m_baseattribute.Add(EnumManager.AttType.Hp, lifeBase);
            m_baseattribute.Add(EnumManager.AttType.Attack, damage);
            m_baseattribute.Add(EnumManager.AttType.AttackRate, damageRate);
            m_baseattribute.Add(EnumManager.AttType.AttackSpeed, attackSpeed);
            m_baseattribute.Add(EnumManager.AttType.Crit, crit);
            m_baseattribute.Add(EnumManager.AttType.CritDmg, critdmg);
            m_baseattribute.Add(EnumManager.AttType.MoveSpeed, moveSpeed);
            m_baseattribute.Add(EnumManager.AttType.AnimSpeed, 1f);
            m_baseattribute.Add(EnumManager.AttType.Defence, defense);
            m_attribute = new Dictionary<EnumManager.AttType, float>();
            m_attribute.Clear();
            // m_passiveAttribute = new PassiveAttribute(this);
            // m_passiveAttribute.ClearAll();
            _baseLayer = base.gameObject.layer;
        }
        
        public virtual void ResetAttribute(int index, int level, int defficult)
        {
            _typeindex = index;
            _level = level;
            m_attribute.Clear();
            foreach (KeyValuePair<EnumManager.AttType, float> item in m_baseattribute)
            {
                m_attribute.Add(item.Key, item.Value);
            }
        }
        
        public virtual void Move(Vector3 move, float delta)
        {
            Debug.Log("Hero move vector: " + move.x + ", " + move.y + ", " + move.z);
            // _rb.linearVelocity = new Vector3(move.x * moveSpeed, _rb.linearVelocity.y, move.z * moveSpeed);
            // Vector3 vector = move * GetActorAttribute(EnumManager.AttType.MoveSpeed);
            // base.transform.position = base.transform.position + vector * delta;
            
            _agent.Move(move * (moveSpeed * delta));
            _animator.SetFloat("moveSpeed", move.magnitude);

            if (move.x != 0 || move.y != 0)
            {
                transform.rotation = Quaternion.LookRotation(move);
                // transform.rotation = Quaternion.LookRotation(_rb.linearVelocity);
            }
        }

        public void SetMoveAnim(float movespeed)
        {
            _animator.SetFloat("moveSpeed", movespeed);
        }
        
        public float GetActorAttribute(EnumManager.AttType type, bool nobuff = false)
        {
            float num = 0f;
            num = ((!m_attribute.ContainsKey(type)) ? 0f : m_attribute[type]);
            if (nobuff)
            {
                return num;
            }
            foreach (ActorBuff buff in _buffList)
            {
                if (buff.atttype == type && buff.addtype == EnumManager.AddType.Add)
                {
                    num += buff.value;
                }
            }
            foreach (ActorBuff buff2 in _buffList)
            {
                if (buff2.atttype == type && buff2.addtype == EnumManager.AddType.Mul)
                {
                    num *= buff2.value;
                }
            }
            foreach (ActorBuff buff3 in _buffList)
            {
                if (buff3.atttype == type && buff3.addtype == EnumManager.AddType.And)
                {
                    num = Mathf.RoundToInt(num) | Mathf.RoundToInt(buff3.value);
                }
            }
            return num;
        }

        public virtual void Turn(Vector3 actordir)
        {
            if ((double)actordir.magnitude > 0.001)
            {
                Quaternion rotation = Quaternion.LookRotation(actordir);
                base.transform.rotation = rotation;
            }
        }
    }
}