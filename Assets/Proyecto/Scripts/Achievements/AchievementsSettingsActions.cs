using UnityEngine;
using MoreMountains.Tools;

namespace Proyecto.Achievements
{
    /// <summary>
    /// UI actions for Achievements from settings screens.
    /// Attach this to a GameObject in your Settings scene and bind methods to UI buttons.
    /// </summary>
    public class AchievementsSettingsActions : MonoBehaviour
    {
        [Tooltip("Optional: if assigned, refreshes the achievements screen after reset")]
        public AchievementsScreenController AchievementsScreenController;

        /// <summary>
        /// Resets all achievements progress/status and refreshes UI if available.
        /// </summary>
        public void ResetAchievementsProgress()
        {
            MMAchievementManager.ResetAllAchievements();
            MMAchievementManager.SaveAchievements();

            if (AchievementsScreenController != null)
            {
                AchievementsScreenController.Refresh();
            }
        }
    }
}
