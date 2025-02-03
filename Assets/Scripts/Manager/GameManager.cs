using Ultils;
using UnityEngine;

namespace Manager
{
    public class GameManager
    {
        public static GameManager g_gameManager;
        public static GameManager GetGameManager()
        {

            if (g_gameManager != null)
            {
                return g_gameManager;
            }
            g_gameManager = new GameManager();
            // g_gameManager.DataInit();
            return g_gameManager;
        }
        
        public string GetHeroPrefebString(string heroid)
        {
            return "prefab/actor/" + heroid;
        }

        public void SetCurrectHero(string heroid)
        {
            PlayerPrefs.SetString("CurrectHero", heroid);
            PlayerPrefs.Save();
        }
        
        public int GetSettingFlag(EnumManager.SettingType type)
        {
            string key = "GameSettingFlag" + type;
            int defaultValue = 0;
            if (type == EnumManager.SettingType.Quelity)
            {
                defaultValue = 2;
            }
            // if (type == EnumManager.SettingType.ShootJoy && FibManager.GetIns().GetValue("input_joy_shoot") == "free")
            // {
            //     defaultValue = 1;
            // }
            return PlayerPrefs.GetInt(key, defaultValue);
        }
    }
}