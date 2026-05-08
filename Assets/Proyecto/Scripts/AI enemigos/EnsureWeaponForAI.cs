using UnityEngine;
using MoreMountains.CorgiEngine;

namespace Proyecto.AIEnemigos
{
    [AddComponentMenu("Proyecto/AI Enemigos/Ensure Weapon For AI")]
    public class EnsureWeaponForAI : MonoBehaviour
    {
        [Tooltip("Optional weapon prefab to assign to the AI's CharacterHandleWeapon on Start")]
        public Weapon WeaponPrefab;

        void Start()
        {
            CharacterHandleWeapon handle = GetComponent<CharacterHandleWeapon>();
            if (handle == null)
            {
                handle = gameObject.AddComponent<CharacterHandleWeapon>();
                Debug.Log("EnsureWeaponForAI: Added CharacterHandleWeapon to " + gameObject.name);
            }

            if (WeaponPrefab != null)
            {
                handle.ChangeWeapon(WeaponPrefab, null);
                Debug.Log("EnsureWeaponForAI: Assigned WeaponPrefab to " + gameObject.name);
            }
        }
    }
}
