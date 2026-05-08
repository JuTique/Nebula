using MoreMountains.Tools;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Proyecto.Achievements
{
public class AchievementItemView : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image icon;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private GameObject lockedOverlay;

    public void Bind(MMAchievement achievement)
    {
        if (achievement == null)
        {
            return;
        }

        bool unlocked = achievement.UnlockedStatus;

       
        if (icon != null)
        {
            icon.sprite = unlocked ? achievement.UnlockedImage : achievement.LockedImage;
        }

  
        if (titleText != null)
        {
            titleText.text = achievement.Title;
        }

       
        if (descriptionText != null)
        {
            descriptionText.text = achievement.Description;
        }

    
        if (lockedOverlay != null)
        {
            lockedOverlay.SetActive(!unlocked);
        }
    }
}
}