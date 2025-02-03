using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Manager
{
    public class HeroLoader : MonoBehaviour
    {
        public GameObject aimingobj;

        public GameObject inputobj;
        
        [HideInInspector]
        public GameObject hero;
        private void Awake()
        {
            string curHeroID = PlayerPrefs.GetString("CurrectHero", "Actor_boy");
            Transform parentHero = GetComponentInParent<GameDirector>().heroParent;
            GameObject original = Resources.Load(GameManager.GetGameManager().GetHeroPrefebString(curHeroID)) as GameObject;
            hero = Object.Instantiate(original, base.transform.position, Quaternion.Euler(0f, 180f, 0f),parentHero);
        }
    }
}