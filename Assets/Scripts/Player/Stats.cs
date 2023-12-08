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

    public int Atk = 5;
    public int Wit = 5;
    public int Mgc = 5;
    public int Spd = 5;

    public int Health;
    public int MaxHealth;
    public int healthRecovery;
    public int healthRecoveryRate = 1;

    public int Mp;
    public int maxMp;
    public int manaRecoveryRate = 1;

    public int armour = 0;
    public int block = 0;
    public int blockDecayRate = 5;

    private void Start()
    {
        MaxHealth = 2 * Wit;
        Health = MaxHealth;
        maxMp = Mgc;
        Mp = maxMp;
    }

    public void upAtk()
    {
        if (score >= lvlUpPrice)
        {
            Atk++;
        }
    }

    public void upWit()
    {
        if (score >= lvlUpPrice)
        {
            Wit++;
            MaxHealth = MaxHealth + 1;
            Health += 2;
        }
    }

    public void upMgc()
    {
        if (score >= lvlUpPrice)
        {
            Mgc++;
            maxMp += 2;
            Mp = maxMp;
        }
    }

    public void upSpd()
    {
        if (score >= lvlUpPrice)
        {
            Spd++;
        }
    }

    private void Update()
    {
        if(score >= lvlUpPrice)
        {
            lvl++;
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

        if(Health <= 0)
        {
            umrzyj();
        }
    }

    public void umrzyj()
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
