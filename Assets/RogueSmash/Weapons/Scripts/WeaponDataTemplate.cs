using UnityEngine;

namespace MyCompany.RogueSmash.Weapons
{
    [CreateAssetMenu(fileName = "New WeaponDataTemplate", menuName = "MyCompany/Data/Create Weapon Data Template")]
    public class WeaponDataTemplate : ScriptableObject
    {
        [SerializeField] private WeaponData weaponData;

        public WeaponData WeaponData
        {
            get { return weaponData; }
        }
    }
}
