using System;
using Camera;
using Unity.Cinemachine;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Manager
{
    public class GameDirector : MonoBehaviour
    {
        public CinemachineCamera heroCamera;
        
        public HeroLoader heroLoader;

        public Transform heroParent;

        private void Awake()
        {
            AutoGameControl.GetIns().heroLoader = heroLoader;
            AutoGameControl.GetIns().heroCamera = heroCamera;
        }

        private void Start()
        {
            LoadHero();
        }

        public void LoadHero()
        {
            Vector3 pos = default(Vector3);
            HeroLoader _heroLoader = Object.Instantiate(this.heroLoader, pos, Quaternion.identity, transform);
            _heroLoader.hero.SetActive(true);
            heroCamera.Follow = _heroLoader.hero.gameObject.transform;
            AutoGameControl.GetIns().currectHero = _heroLoader.hero.GetComponent<Hero.Hero>();
            AutoGameControl.GetIns().currectHero.transform.SetParent(heroParent, true);
            AutoGameControl.GetIns().currectHero.transform.position = pos;
        }
    }
}