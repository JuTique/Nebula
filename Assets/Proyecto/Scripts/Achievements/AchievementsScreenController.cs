using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;

namespace Proyecto.Achievements
{
    /// <summary>
    /// Instantiate and bind achievement item prefabs from MMAchievementManager.AchievementsList.
    /// Attach this to your Achievements Canvas (or a child) and assign the Content root and item prefab.
    /// </summary>
    public class AchievementsScreenController : MonoBehaviour
    {
        [Tooltip("Content transform where items will be parented (ScrollView Content)")]
        public Transform ContentRoot;
        [Tooltip("Achievement item prefab with AchievementItemView component")]
        public AchievementItemView ItemPrefab;
        [Tooltip("If true, the controller will look for existing AchievementItemView children under ContentRoot and bind them in order instead of instantiating the prefab.")]
        public bool UseExistingChildren = false;
        [Tooltip("Optional delay (seconds) before the first Refresh to let AchievementRules initialize the manager")]
        public float DelayBeforeRefresh = 0.05f;

        protected List<AchievementItemView> _spawnedItems = new List<AchievementItemView>();

        protected virtual void OnEnable()
        {
            // trigger a delayed refresh to ensure MMAchievementManager has loaded the list
            if (DelayBeforeRefresh <= 0f)
            {
                Refresh();
            }
            else
            {
                Invoke(nameof(Refresh), DelayBeforeRefresh);
            }
        }

        protected virtual void OnDisable()
        {
            CancelInvoke(nameof(Refresh));
        }

        /// <summary>
        /// Clears and (re)populates the UI from the manager list
        /// </summary>
        public virtual void Refresh()
        {
            Clear();
            if (MMAchievementManager.AchievementsList == null)
            {
                return;
            }

            var list = MMAchievementManager.AchievementsList;

            if (UseExistingChildren && (ContentRoot != null))
            {
                // find all AchievementItemView under ContentRoot (in hierarchy order)
                AchievementItemView[] children = ContentRoot.GetComponentsInChildren<AchievementItemView>(true);
                for (int i = 0; i < children.Length && i < list.Count; i++)
                {
                    children[i].Bind(list[i]);
                }
                return;
            }

            // fallback: if prefab reference is missing, try binding existing children
            if (ItemPrefab == null && ContentRoot != null)
            {
                AchievementItemView[] children = ContentRoot.GetComponentsInChildren<AchievementItemView>(true);
                for (int i = 0; i < children.Length && i < list.Count; i++)
                {
                    children[i].Bind(list[i]);
                }
                return;
            }

            // default: instantiate prefabs
            if (ItemPrefab == null || ContentRoot == null)
            {
                return;
            }

            foreach (MMAchievement achievement in list)
            {
                AchievementItemView item = Instantiate(ItemPrefab, ContentRoot);
                item.Bind(achievement);
                _spawnedItems.Add(item);
            }
        }

        /// <summary>
        /// Clears all spawned items
        /// </summary>
        public virtual void Clear()
        {
            for (int i = 0; i < _spawnedItems.Count; i++)
            {
                if (_spawnedItems[i] != null)
                {
                    Destroy(_spawnedItems[i].gameObject);
                }
            }
            _spawnedItems.Clear();
        }

        /// <summary>
        /// Resets the achievements (editor/game reset) and refreshes UI
        /// </summary>
        public virtual void ResetAchievements()
        {
            MMAchievementManager.ResetAllAchievements();
            MMAchievementManager.SaveAchievements();
            Refresh();
        }
    }
}
