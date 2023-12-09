﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

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

    public float physDamage = 5;
    public float physDmgMulti = 1;
    public float physDmgMultiGrowRate = 0.05f;
    public float mgcDamage = 10;
    public float mgcDmgMulti = 1;
    public float mgcDmgMultiGrowRate = 0.05f;

    public float movespeedMulti = 1;
    public float movespeedMultiGrowRate = 0.1f;

    public int Health;
    public int MaxHealth;
    public int healthRecovery;
    public int healthRecoveryRate = 1;
    public float HealthRecoveryGrowRate = 0.5f;

    public int Mp;
    public int maxMp;
    public int manaRecoveryRate = 1;
    public float manaRecoveryGrowRate = 1;

    public int armour = 0;
    public int block = 0;
    public int blockDecayRate = 4;

    public List<spell> activeSpells;

    //physics stats
    protected Rigidbody rb;
    [SerializeField]
    public float speed;
    public Vector2 facingDir = Vector2.right;

    protected virtual void Start()
    {
        MaxHealth = 2 * Stamina;
        Health = MaxHealth;
        maxMp = Perseverance;
        Mp = maxMp;

        rb = gameObject.GetComponent<Rigidbody>();
    }

    public void updateStats()
    {
        physDmgMulti = 1 + Fitness * physDmgMultiGrowRate;
        mgcDmgMulti = 1 + Willpower * mgcDmgMultiGrowRate;

        MaxHealth = 10 + 1 * Stamina;
        maxMp = 5 + 2 * Perseverance;

        healthRecoveryRate = (int)(1 + HealthRecoveryGrowRate * Willpower);
        manaRecoveryRate = (int)(1 + manaRecoveryGrowRate * Perseverance);

        movespeedMulti = 1 + movespeedMultiGrowRate * Fitness;

        blockDecayRate = (int)Math.Pow(0.5f,(armour/5 - 2));
    }

    public void upFit()
    {
        if (lvlUps >= 0)
        {
            Fitness++;
            lvlUps--;
        }
    }

    public void upSta()
    {
        if (lvlUps >= 0)
        {
            Stamina++;
            Health += 1;
            lvlUps--;
        }
    }

    public void upPer()
    {
        if (lvlUps > 0)
        {
            Perseverance++;
            armour++;
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

    //movement:
    protected virtual void Move(Vector2 move)
    {
        rb.AddForce(new Vector3(move.x, move.y, 0) * speed * movespeedMulti, ForceMode.Force);
    }

    protected virtual void Rotate(float angleInDegrees)
    {
        facingDir = RotateVector(facingDir, angleInDegrees);
    }

    protected virtual void Update()
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

    //quality of life
    public Vector3 RotateVector(Vector3 vector, float angleInDegrees)
    {
        float angleInRadians = angleInDegrees * Mathf.Deg2Rad;
        float x = vector.x * Mathf.Cos(angleInRadians) - vector.y * Mathf.Sin(angleInRadians);
        float y = vector.x * Mathf.Sin(angleInRadians) + vector.y * Mathf.Cos(angleInRadians);
        return new Vector3(x, y, vector.z);
    }
}
