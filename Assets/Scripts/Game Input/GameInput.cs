using System.Collections.Generic;

namespace Game_Input
{
    public class GameInput
    {
        private Dictionary<string, float> inputDic;

        public GameInput()
        {
            inputDic = new Dictionary<string, float>();
            inputDic.Clear();
        }

        private bool HasName(string name)
        {
            if (inputDic.ContainsKey(name))
            {
                return true;
            }
            return false;
        }

        public void AddValue(string name, float value)
        {
            if (!HasName(name))
            {
                inputDic.Add(name, value);
            }
            else
            {
                SetValue(name, value);
            }
        }

        public void SetValue(string name, float value)
        {
            if (HasName(name))
            {
                inputDic[name] = value;
            }
            else
            {
                AddValue(name, value);
            }
        }

        public float GetValue(string name)
        {
            if (HasName(name))
            {
                return inputDic[name];
            }

            return 0f;
        }

        public void RemoveValue(string name)
        {
            inputDic.Remove(name);
        }

        public void Reset()
        {
            inputDic.Clear();
        }
    }
}