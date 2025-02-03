using Ultils;
using UnityEngine;

namespace Hero
{
    public class ActorBuff
    {
        public int buffsid;

        public EnumManager.AddType addtype;

        public EnumManager.AttType atttype;

        public float value;

        public float buffTime;

        public GameObject showeffect;

        public GameObject sourseff;

        public GameObject uibuff;

        public ActorBuff()
        {
            showeffect = null;
            sourseff = null;
        }
    }
}