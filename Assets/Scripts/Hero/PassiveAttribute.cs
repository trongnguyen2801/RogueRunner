// using System.Collections.Generic;
// using Ultils;
// using UnityEngine;
//
// namespace Hero
// {
//  public class PassiveAttribute
// 	{
// 		private Dictionary<EnumManager.PassiveAttType, float> m_passivelist;
//
// 		private Dictionary<EnumManager.PassiveAttType, EffectBuff> m_effectlist;
//
// 		private ActorBase m_actor;
//
// 		public PassiveAttribute(ActorBase actor)
// 		{
// 			m_actor = actor;
// 			m_passivelist = new Dictionary<EnumManager.PassiveAttType, float>();
// 			m_passivelist.Clear();
// 			m_effectlist = new Dictionary<EnumManager.PassiveAttType, EffectBuff>();
// 			m_effectlist.Clear();
// 		}
//
// 		public void ClearAll()
// 		{
// 			m_passivelist.Clear();
// 			foreach (KeyValuePair<EnumManager.PassiveAttType, EffectBuff> item in m_effectlist)
// 			{
// 				item.Value.DestroyEffect(m_actor);
// 			}
// 			m_effectlist.Clear();
// 		}
//
// 		public void AddPassive(EnumManager.PassiveAttType pat, float value)
// 		{
// 			if (m_passivelist.ContainsKey(pat))
// 			{
// 				m_passivelist[pat] += value;
// 			}
// 			else
// 			{
// 				m_passivelist.Add(pat, value);
// 			}
// 			AddHoldPassiveEffect(pat);
// 		}
//
// 		public void AddHoldPassiveEffect(EnumManager.PassiveAttType pat)
// 		{
// 			if (!m_effectlist.ContainsKey(pat))
// 			{
// 				if (pat == EnumManager.PassiveAttType.RecoveryHp5)
// 				{
// 					m_effectlist.Add(EnumManager.PassiveAttType.RecoveryHp5, new RecoverHP5(m_actor));
// 				}
// 				if (pat == EnumManager.PassiveAttType.AttackerLowHPCritAdd)
// 				{
// 					m_effectlist.Add(EnumManager.PassiveAttType.AttackerLowHPCritAdd, new AttackerLowHPCritAdd());
// 				}
// 				if (pat == EnumManager.PassiveAttType.AttactHPRate)
// 				{
// 					m_effectlist.Add(EnumManager.PassiveAttType.AttactHPRate, new AttactHPRate());
// 				}
// 				if (pat == EnumManager.PassiveAttType.AttackRatePer10sec)
// 				{
// 					m_effectlist.Add(EnumManager.PassiveAttType.AttackRatePer10sec, new AttackRatePer10sec());
// 				}
// 				if (pat == EnumManager.PassiveAttType.StandAddAttackRate)
// 				{
// 					m_effectlist.Add(EnumManager.PassiveAttType.StandAddAttackRate, new StandAddAttackRate());
// 				}
// 				if (pat >= EnumManager.PassiveAttType.ImmuneTrap_flame && pat <= EnumManager.PassiveAttType.ImmuneTrap)
// 				{
// 					m_effectlist.Add(pat, new ImmuneTrap(pat));
// 				}
// 				if (pat == EnumManager.PassiveAttType.AttackReduceBlood2)
// 				{
// 					m_effectlist.Add(EnumManager.PassiveAttType.AttackReduceBlood2, new AttackReduceBlood2());
// 				}
// 				if (pat == EnumManager.PassiveAttType.VipPassive)
// 				{
// 					m_effectlist.Add(EnumManager.PassiveAttType.VipPassive, new VipPassive(m_actor));
// 				}
// 			}
// 		}
//
// 		public void AddCritPassiveEffect(ActorBase beattackbase)
// 		{
// 			if (!GontainPassive(EnumManager.PassiveAttType.CritReduceDeffence))
// 			{
// 				return;
// 			}
// 			int buffsid = 160 + BuffDef.PASSIVE;
// 			ActorBuff actorBuff = beattackbase.GetActorBuff(buffsid);
// 			if (actorBuff != null)
// 			{
// 				actorBuff.buffTime = 3f;
// 				actorBuff.value -= 1f;
// 				if (actorBuff.value < 0f - GetPassiveValue(EnumManager.PassiveAttType.CritReduceDeffence))
// 				{
// 					actorBuff.value = 0f - GetPassiveValue(EnumManager.PassiveAttType.CritReduceDeffence);
// 				}
// 			}
// 			else
// 			{
// 				PassiveDes passiveDes = DataConfig.GetIns().GetPassiveDes(EnumManager.PassiveAttType.CritReduceDeffence, 1f);
// 				actorBuff = new ActorBuff();
// 				actorBuff.buffsid = buffsid;
// 				actorBuff.addtype = EnumManager.AddType.Add;
// 				actorBuff.buffTime = 3f;
// 				actorBuff.atttype = EnumManager.AttType.Defence;
// 				actorBuff.value = -1f;
// 				actorBuff.sourseff = Resources.Load<GameObject>("PassiveEff/" + passiveDes.effectlist[1]);
// 				beattackbase.AddActorBuff(actorBuff);
// 			}
// 		}
//
// 		public void AddAttackPassiveEffect()
// 		{
// 			if (GontainPassive(EnumManager.PassiveAttType.AttackReduceBlood) && !m_effectlist.ContainsKey(EnumManager.PassiveAttType.AttackReduceBlood))
// 			{
// 				m_effectlist.Add(EnumManager.PassiveAttType.AttackReduceBlood, new AttackReduceBlood());
// 			}
// 			if (GontainPassive(EnumManager.PassiveAttType.AttackReduceBlood2) && !m_effectlist.ContainsKey(EnumManager.PassiveAttType.AttackReduceBlood2))
// 			{
// 				m_effectlist.Add(EnumManager.PassiveAttType.AttackReduceBlood2, new AttackReduceBlood2());
// 			}
// 			if (GontainPassive(EnumManager.PassiveAttType.AttackLifeLoot) && !m_effectlist.ContainsKey(EnumManager.PassiveAttType.AttackLifeLoot))
// 			{
// 				m_effectlist.Add(EnumManager.PassiveAttType.AttackLifeLoot, new AttackLifeLoot());
// 			}
// 			if (GontainPassive(EnumManager.PassiveAttType.AttackDamageRateLight) && !m_effectlist.ContainsKey(EnumManager.PassiveAttType.AttackDamageRateLight))
// 			{
// 				m_effectlist.Add(EnumManager.PassiveAttType.AttackDamageRateLight, new AttackDamageRateLight());
// 			}
// 		}
//
// 		public float GetPassiveValue(EnumManager.PassiveAttType pat)
// 		{
// 			if (m_passivelist.ContainsKey(pat))
// 			{
// 				return m_passivelist[pat];
// 			}
// 			return 0f;
// 		}
//
// 		public bool GontainPassive(EnumManager.PassiveAttType pat)
// 		{
// 			if (m_passivelist.ContainsKey(pat))
// 			{
// 				return true;
// 			}
// 			return false;
// 		}
//
// 		public Dictionary<EnumManager.PassiveAttType, float> GetPassiveList()
// 		{
// 			return m_passivelist;
// 		}
//
// 		public void UpdatePassive()
// 		{
// 			foreach (KeyValuePair<EnumManager.PassiveAttType, EffectBuff> item in m_effectlist)
// 			{
// 				item.Value.UpdateEffect(m_actor, Time.deltaTime, GetPassiveValue(item.Key));
// 			}
// 		}
//
// 		public void ResetPassive()
// 		{
// 			foreach (KeyValuePair<EnumManager.PassiveAttType, EffectBuff> item in m_effectlist)
// 			{
// 				item.Value.ResetEffect(m_actor);
// 			}
// 		}
//
		// public void KillActor()
		// {
		// 	if ((GetPassiveValue(EnumManager.PassiveAttType.KillRecoveryHpRate) > 0f || GetPassiveValue(EnumManager.PassiveAttType.KillRecoveryHp) > 0.99f) && m_actor.m_lifePercent < 1f)
		// 	{
		// 		float passiveValue = GetPassiveValue(EnumManager.PassiveAttType.KillRecoveryHp);
		// 		passiveValue += m_actor.GetTotalLife() * GetPassiveValue(EnumManager.PassiveAttType.KillRecoveryHpRate);
		// 		AttackData attackData = new AttackData();
		// 		attackData.attData = new Dictionary<EnumManager.AttType, float>();
		// 		attackData.attData.Add(EnumManager.AttType.Attack, 0f - passiveValue);
		// 		m_actor.BeAttack(attackData, 1f);
		// 	}
		// }
//
// 		public float GetBeAttackerBeAtRate(ActorBase beattacker)
// 		{
// 			float num = 0f;
// 			if (GontainPassive(EnumManager.PassiveAttType.BeAttackLowHPAttackRateAdd) && beattacker.m_lifePercent < 0.25f)
// 			{
// 				num += GetPassiveValue(EnumManager.PassiveAttType.BeAttackLowHPAttackRateAdd);
// 			}
// 			if (GontainPassive(EnumManager.PassiveAttType.BeAttackBossRate) && beattacker.IsBoss)
// 			{
// 				num += GetPassiveValue(EnumManager.PassiveAttType.BeAttackBossRate);
// 			}
// 			return num;
// 		}
//
// 		public void DoAttackEffect(ActorBase beattackbase)
// 		{
// 			AddAttackPassiveEffect();
// 			foreach (KeyValuePair<EnumManager.PassiveAttType, EffectBuff> item in m_effectlist)
// 			{
// 				item.Value.DoEffect(m_actor, beattackbase, GetPassiveValue(item.Key));
// 			}
// 		}
// 	}
// }