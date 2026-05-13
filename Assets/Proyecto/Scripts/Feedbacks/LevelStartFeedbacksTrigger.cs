using UnityEngine;
using MoreMountains.Tools;
using MoreMountains.Feedbacks;
using MoreMountains.CorgiEngine;

namespace Proyecto.Feedbacks
{
    /// <summary>
    /// Listens for the CorgiEngine LevelStart event and plays the assigned MMFeedbacks.
    /// Attach this to a GameObject and assign an `MMFeedbacks` asset or component. Use this
    /// if you want to trigger camera/UI feedbacks exactly when the level starts.
    /// </summary>
    public class LevelStartFeedbacksTrigger : MonoBehaviour, MMEventListener<CorgiEngineEvent>
    {
        [Tooltip("MMFeedbacks to play when the level starts")]
        public MMFeedbacks Feedbacks;

        protected virtual void OnEnable()
        {
            this.MMEventStartListening<CorgiEngineEvent>();
        }

        protected virtual void OnDisable()
        {
            this.MMEventStopListening<CorgiEngineEvent>();
        }

        public virtual void OnMMEvent(CorgiEngineEvent corgiEvent)
        {
            if (corgiEvent.EventType == CorgiEngineEventTypes.LevelStart)
            {
                Feedbacks?.PlayFeedbacks();
            }
        }
    }
}
