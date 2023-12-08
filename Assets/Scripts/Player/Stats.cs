using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    public int lvl = 1;
    public int score = 0;
    public int lvlUpPrice = 10;
    public int lvlUps = 0;

    public int Fitness = 5;
    public int Stamina = 5;
    public int Perseverance = 5;
    public int Willpower = 5;

    public float physDmgMulti = 1;
    public float physDmgMultiGrowRate = 0.05f;
    public float mgcDmgMulti = 1;
    public float mgcDmgMultiGrowRate = 0.05f;

    public float movespeedMulti = 1;
    public float movespeedMultiGrowRate = 0.1f;

    public int Health;
    public int MaxHealth;
    public int healthRecovery;
    public int healthRecoveryRate = 1;
    public int HealthRecoveryGrowRate = 1;

    public int Mp;
    public int maxMp;
    public int manaRecoveryRate = 1;
    public int manaRecoveryGrowRate = 1;

    public int armour = 0;
    public int block = 0;
    public int blockDecayRate = 5;

    public List<spell> activeSpells;

    private void Start()
    {
        MaxHealth = 2 * Stamina;
        Health = MaxHealth;
        maxMp = Perseverance;
        Mp = maxMp;
    }

    public void upFit()
    {
        if (lvlUps >= 0)
        {
            Fitness++;
            lvlUps--;
        }
    }

    public void upWit()
    {
        if (lvlUps >= 0)
        {
            Stamina++;
            MaxHealth = MaxHealth + 1;
            Health += 2;
            lvlUps--;
        }
    }

    public void upMgc()
    {
        if (lvlUps > 0)
        {
            Perseverance++;
            maxMp += 2;
            Mp = maxMp;
            lvlUps--;
        }
    }

    public void upSpd()
    {
        if (lvlUps > 0)
        {
            Willpower++;
            lvlUps--;
        }
    }

    private void Update()
    {
        if(score >= lvlUpPrice)
        {
            lvl++;
            lvlUps++;
            score -= lvlUpPrice;
            lvlUpPrice += (int)(lvlUpPrice * 0.2f);
        }

        if(healthRecovery < Health)
        {
            Health += healthRecoveryRate;
        }

        if(Health > MaxHealth)
        {
            Health = MaxHealth;
        }

        if(block > 0)
        {
            block -= blockDecayRate;
        }

        if(Health <= 0)
        {
            umrzyj();
        }
    }

    public virtual void umrzyj()
    {
        //if(!isPlayer)
        //{
        //    Instantiate(deathObject, transform.position, Quaternion.identity);
        //    playerStats.score += (Atk + Mgc + Wit + Spd) / 2;
        //}
        //if(Random.Range(0,100) <= drapchance*100 && !isPlayer)
        //{
        //    Instantiate(drops[Random.Range(0, drops.Count)], transform.position, Quaternion.identity);
        //}
        Destroy(gameObject);
    }

}
