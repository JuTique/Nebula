using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using MoreMountains.CorgiEngine;

public class ControlMonedas : MonoBehaviour, MMEventListener<PickableItemEvent>
{
    void OnEnable()
    {
        this.MMEventStartListening<PickableItemEvent>();
    }
    
    void OnDisable()
    {
        this.MMEventStopListening<PickableItemEvent>();
    }


    public virtual void OnMMEvent(PickableItemEvent e)
    {
       Coin coin = e.PickedItem.GetComponent<Coin>();

        if (coin != null)
         {
            Debug.Log(coin.PointsToAdd);
        }
    }


}
