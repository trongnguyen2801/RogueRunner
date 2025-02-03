using UnityEngine;
using UnityEngine.UI;

namespace Hero
{
    public class HeroCanvas : MonoBehaviour
    {
        public GameObject shootDirEff;

        // public ClipsBar clipsbar;

        public Image skillRange;

        public Image skillArrow;
        
        private void Awake()
        {
            skillRange.gameObject.SetActive(false);
            skillArrow.gameObject.SetActive(false);
        }
        
        private Hero GetHero()
        {
            return base.transform.parent.GetComponent<Hero>();
        }
        
        public void SetShootDir(Transform hero, Vector3 lookdir)
        {
            Vector3 localEulerAngles = default(Vector3);
            float num = Vector3.Angle(hero.transform.forward, lookdir);
            if (Vector3.Angle(hero.transform.right, lookdir) > 90f)
            {
                localEulerAngles.z = num + 180f;
            }
            else
            {
                localEulerAngles.z = 0f - num - 180f;
            }
            shootDirEff.transform.localEulerAngles = localEulerAngles;
        }
        
        public void ShowSkillRange(float radio)
        {
            skillRange.GetComponent<RectTransform>().sizeDelta = new Vector2(radio * 2f, radio * 2f);
        }

        public void ShowSkillArrow(float radio, Vector3 dir)
        {
            Vector2 sizeDelta = skillArrow.GetComponent<RectTransform>().sizeDelta;
            sizeDelta.y = radio * 2f;
            skillArrow.GetComponent<RectTransform>().sizeDelta = sizeDelta;
            Vector3 localEulerAngles = default(Vector3);
            float num = Vector3.Angle(GetHero().transform.forward, dir);
            if (Vector3.Angle(GetHero().transform.right, dir) > 90f)
            {
                localEulerAngles.z = num;
            }
            else
            {
                localEulerAngles.z = 0f - num;
            }
            skillArrow.transform.localEulerAngles = localEulerAngles;
        }
    }
}