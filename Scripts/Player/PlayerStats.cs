using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] PlayerScriptableObject playerData;

    //currentStats
    float currentspeed;
    float currentHealth;
    float currentMight;
    float currentMagnet;
    public float CurrentHealth {
        get=>currentHealth; 
        set{if(currentHealth != value)
        {
            currentHealth = value;
            if(GameManager.instance != null)
            {
                GameManager.instance.currentHealthDisplay.text = "Heath: "+currentHealth;
            }
        }}
        }
    [SerializeField] int maxExp;
    [SerializeField] private Image _hpBar;
    
    public float CurrentMight {
        get=>currentMight; 
        set{if(currentMight != value)
        {
            currentMight = value;
            if(GameManager.instance != null)
            {
                GameManager.instance.currentMightDisplay.text = "Heath: "+currentMight;
            }
        }}
    }
    public float CurrentSpeed {
        get=>currentspeed; 
        set{if(currentspeed != value)
        {
            currentspeed = value;
            if(GameManager.instance != null)
            {
                GameManager.instance.currentSpeedDisplay.text = "Might: "+currentspeed;
            }
        }}
    }
    float currentRecovery;
    float currentProjectileSpeed;
    
    public float CurrentMagnet {
        get=>currentMagnet; 
        set{if(currentMagnet != value)
        {
            currentMagnet = value;
            if(GameManager.instance != null)
            {
                GameManager.instance.currentMagnetDisplay.text = "Magnet: "+currentMagnet;
            }
        }}
        }
    

    //level
    [SerializeField] int currentExp;
    [SerializeField] int level=1;
    [SerializeField] int maxExpIncrease;

    InventoryManager inventory;
    public int weaponIndex;
    public int passiveItemIndex;
    public GameObject passiveItemtest, passiveItemtest2;
    
    private void Awake() {
        playerData = CharacterSelector.GetData();
        playerData.StartWeapon = CharacterSelector.GetData().StartWeapon;
        CharacterSelector.instance.DestroySingleton();
        inventory=GetComponent<InventoryManager>();

        CurrentHealth = playerData.MaxHealth;
        CurrentSpeed = playerData.Speed;
        maxExp=playerData.MaxExp;
        currentExp=0;
        CurrentMight = playerData.Might;
        currentRecovery = playerData.Recovery;
        currentProjectileSpeed = playerData.ProjectileSpeed;
        CurrentMagnet= playerData.Magnet;
        
        Debug.Log(playerData.StartWeapon);
        
        //Spawn the starting weapon
        spawnWeapon(playerData.StartWeapon);
        spawnPassiveItem(passiveItemtest);
        spawnPassiveItem(passiveItemtest2);
        if(playerData.StartWeapon== null)
        {
            Debug.Log("NULL");
        }
    }

    

    public void GetExp(int exp)
    {
        currentExp += exp;
        CheckLvUp();
    }
    private void CheckLvUp()
    {
        if (currentExp >= maxExp)
        {
            currentExp -= maxExp;
            level++; 
            maxExp +=maxExpIncrease;
            GameManager.instance.StartLvUp();
        }
        
    }

    public void TakeDamage(float dmg)
    {
        CurrentHealth -= dmg;
        UpdateHpBar();
        if(CurrentHealth <= 0)
        {
            Dead();
        }
    }

    private void UpdateHpBar()
    {
        float hp = CurrentHealth/playerData.MaxHealth;
        if(hp > 0)
        {
            _hpBar.fillAmount = hp;
        }
        else {
            _hpBar.fillAmount=0;
        }
    }

    void Dead()
    {
        if(!GameManager.instance.isGameOver)
        {
            GameManager.instance.GameOver();
        }

    }

    public void Recovery(int recovery)
    {
        if(CurrentHealth < playerData.MaxHealth)
        {
            CurrentHealth+= recovery;
            if(CurrentHealth >= playerData.MaxHealth)
            {
                CurrentHealth=playerData.MaxHealth;
                UpdateHpBar();
            }
        }
    }

    public void spawnWeapon(GameObject weapon)
    {
        if(weaponIndex>=inventory.weaponsSlot.Count-1)
        {
            Debug.Log("slot weapon is full");
            return;
        }
        GameObject spawnedWeapon= Instantiate(weapon, transform.position, Quaternion.identity);
        spawnedWeapon.transform.SetParent(this.transform);
        inventory.AddWeapon(weaponIndex, spawnedWeapon.GetComponent<WeaponController>());
        weaponIndex++;
    }
    public void spawnPassiveItem(GameObject passiveItem)
    {
        if(passiveItemIndex>=inventory.passiveItemsSlot.Count-1)
        {
            Debug.Log("slot weapon is full");
            return;
        }
        GameObject spawnedPassiveItem= Instantiate(passiveItem, transform.position, Quaternion.identity);
        spawnedPassiveItem.transform.SetParent(this.transform);
        inventory.AddPassive(passiveItemIndex, spawnedPassiveItem.GetComponent<PassiveItem>());
        passiveItemIndex++;
    }
}
