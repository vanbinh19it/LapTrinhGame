using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public List<WeaponController> weaponsSlot=new List<WeaponController>(6);
    public int[] weaponLevels= new int[6];
    public List<Image> weaponUISlots= new List<Image>(6);
    public List<PassiveItem> passiveItemsSlot=new List<PassiveItem>(6);
    public int[] passiveLevels = new int[6];
    public List<Image> passiveItemUISlots= new List<Image>(6);

    [System.Serializable]
    public class WeaponUpgrade
    {
        public GameObject initialWeapon;
        public WeaponScriptableObject weaponData;
    }
    [System.Serializable]
    public class PassiveItemUpgrade
    {
        public GameObject initialPassiveItem;
        public WeaponScriptableObject passiveItemData;
    }
    [System.Serializable]
    public class UpgradeUi
    {
        public Text upgradeDisplay;
        public Text upgradeDescriptionDisplay;
        public Image upgradeIcon;
        public Button upgrade;
    }

    public List<WeaponUpgrade> weaponUpgradesOptions=new List<WeaponUpgrade>();
    public List<PassiveItemUpgrade> passiveItemUpgradesOptions=new List<PassiveItemUpgrade>();
    public List<UpgradeUi> upgradeUiOptions=new List<UpgradeUi>();
    public void AddWeapon(int slotIndex, WeaponController weapon)
    {
        weaponsSlot[slotIndex] = weapon;
        weaponLevels[slotIndex] = weapon.weaponData.Level;
        weaponUISlots[slotIndex].enabled = true;
        weaponUISlots[slotIndex].sprite =weapon.weaponData.Icon;
    }
    public void AddPassive(int slotIndex, PassiveItem passiveItem)
    {
        passiveItemsSlot[slotIndex] = passiveItem;
        passiveLevels[slotIndex] = passiveItem.passiveItemData.Level;
        passiveItemUISlots[slotIndex].enabled = true;
        passiveItemUISlots[slotIndex].sprite =passiveItem.passiveItemData.Icon;
    }
    public void LevelUpWeapon(int slotIndex)
    {
        if(weaponsSlot.Count>slotIndex)
        {
            WeaponController weapon = weaponsSlot[slotIndex];
            if(!weapon.weaponData.NextLevelPrefab)
            {
                Debug.LogError("NO NEXT LV for "+ weapon.name);
                return;
            }
            GameObject upgradedWeapon= weapon.weaponData.NextLevelPrefab;
            Instantiate(upgradedWeapon, transform.position, Quaternion.identity);
            upgradedWeapon.transform.SetParent(this.transform);
            AddWeapon(slotIndex, upgradedWeapon.GetComponent<WeaponController>());
            Destroy(weapon.gameObject);
            weaponLevels[slotIndex] = upgradedWeapon.GetComponent<WeaponController>().weaponData.Level;
        }
    }
    public void LevelUpPassive(int slotIndex)
    {
        if(passiveItemsSlot.Count>slotIndex)
        {
            PassiveItem passiveItem = passiveItemsSlot[slotIndex];
            if(!passiveItem.passiveItemData.NextLevelPrefab)
            {
                Debug.LogError("NO NEXT LV for "+ passiveItem.name);
                return;
            }
            GameObject upgradedPassiveItem= passiveItem.passiveItemData.NextLevelPrefab;
            Instantiate(upgradedPassiveItem, transform.position, Quaternion.identity);
            upgradedPassiveItem.transform.SetParent(transform);
            AddPassive(slotIndex, upgradedPassiveItem.GetComponent<PassiveItem>());
            Destroy(passiveItem.gameObject);
            passiveLevels[slotIndex] = upgradedPassiveItem.GetComponent<PassiveItem>().passiveItemData.Level;
        }
    }
}
