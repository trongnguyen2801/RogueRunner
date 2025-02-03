namespace Ultils
{
    public class EnumManager
    {
        public enum AxesType
        {
            Both = 0,
            Horizontal = 1,
            Vertical = 2,
        }
        
        public enum ControlType
        {
            Absolute = 0,
            Relative = 1,
            Swipe = 2,
        }
        
        public enum PressType
        {
            PointDown = 0,
            AllTime = 1,
        }

        public enum GameInputType
        {
            Touch = 0,
            KeyMouse = 1,
        }
        
        public enum AttType
        {
            Attack = 1,
            AttackRate = 2,
            DamageRate = 3,
            Hp = 4,
            HpRate = 5,
            Defence = 6,
            Crit = 7,
            CritDmg = 8,
            ExpAdd = 9,
            ExpRate = 10,
            GoldAdd = 11,
            GoldRate = 12,
            LootLuck = 13,
            Dodge = 14,
            EquipCountAdd = 15,
            SkillDamageRate = 16,
            SkillLastTimeAdd = 17,
            SkillLastTimeRate = 18,
            SkillCoolDownDec = 19,
            SkillCoolDownRate = 20,
            SprintCountAdd = 21,
            AttackSpeed = 22,
            BeAttackRate = 23,
            AnimSpeed = 24,
            MoveSpeed = 25,
            DamageReduction = 26,
            DamageRange = 27,
            DamageImmune = 28,
            DamageVirtua = 29,
            AttackDamageType = 30,
            ImmuneTrapType = 31,
            ChargePower = 32,
            Block = 33,
            FinalDamage = 34,
            NormalAttack = 35,
            FireAttack = 36,
            ElectricAttack = 37,
            PoisonAttack = 38,
            IceAttack = 39,
            NormalRes = 40,
            FireRes = 41,
            ElectricRes = 42,
            PoisonRes = 43,
            IceRes = 44,
            NormalNeg = 45,
            FireNeg = 46,
            ElectricNeg = 47,
            PoisonNeg = 48,
            IceNeg = 49,
            End = 50
        }
        
        public enum AddType
        {
            Add = 0,
            Mul = 1,
            And = 2
        }
        
        public enum PassiveAttType
        {
            ImmuneTrap_flame = 1,
            ImmuneTrap_laser = 2,
            ImmuneTrap_Spike = 3,
            ImmuneTrap_shoot = 4,
            ImmuneTrap_venom = 5,
            ImmuneTrap = 6,
            AttackerLowHPCritAdd = 7,
            RecoveryHp5 = 8,
            KillRecoveryHpRate = 9,
            KillRecoveryHp = 10,
            BeAttackLowHPAttackRateAdd = 11,
            BeAttackBossRate = 12,
            AttactHPRate = 13,
            AttackReduceBlood = 14,
            AttackRatePer10sec = 15,
            CritReduceDeffence = 16,
            AttackReduceBlood2 = 17,
            AttackLifeLoot = 18,
            AttackDamageRateLight = 19,
            StandAddAttackRate = 20,
            DropGem = 21,
            ChargeBloodPower = 22,
            ChargePowerType = 23,
            ChargeDamageReduction = 24,
            VipPassive = 25,
            GunSpraySizeDecRate = 26
        }
        
        public enum TargetPosType
        {
            NullTarget = 0,
            InScreenRect = 1,
            OutScreenRect = 2
        }
        
        public enum CameraType
        {
            LookActor = 0,
            ScreenMove = 1
        }
        
        public enum SettingType
        {
            Music = 1,
            Sound = 2,
            Quelity = 3,
            MoveJoy = 4,
            ShootJoy = 5,
            Shake = 6,
            Flicker = 7
        }
    }
}