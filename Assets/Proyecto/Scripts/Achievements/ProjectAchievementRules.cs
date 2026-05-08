using UnityEngine;
using MoreMountains.Tools;

namespace Proyecto.Achievements
{
   
    public class ProjectAchievementRules : MMAchievementRules
    {
        private static ProjectAchievementRules _instance;

        protected override void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
            DontDestroyOnLoad(gameObject);

            base.Awake();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
        }

        protected override void OnDisable()
        {
            base.OnDisable();
        }
    }
}
