using Camera;
using Unity.Cinemachine;
using UnityEngine;

namespace Manager
{
    public class AutoGameControl
    {
        private static AutoGameControl g_autoGame;

        public Hero.Hero currectHero;

        public CinemachineCamera heroCamera;
        
        public FixedJoystick joystick;

        // public UIGamePlay uigame;

        public GameObject autoInput;

        public GameObject autoaiming;

        public HeroLoader heroLoader;

        // public AutoMapCreater mapcreater;

        public GameObject actDirector;

        // public Headquarter headquarter;

        public Transform lootTrans;

        public bool isTutorial;

        // public NpcType tutorialNpc = NpcType.End;

        public static AutoGameControl GetIns()
        {
            if (g_autoGame == null)
            {
                g_autoGame = new AutoGameControl();
            }
            return g_autoGame;
        }
    }
}