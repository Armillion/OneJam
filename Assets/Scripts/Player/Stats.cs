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
    public int healthRecoery;
    public int healthRecoeryRate = 1;

    public int Mp;
    public int maxMp;
    public int manaRecoveryRate = 1;

    public int armour = 0;
    public int block = 0;
    public int blockDecayRate = 5;

    public bool isPlayer = true;

    public List<GameObject> drops;
    public float drapchance = 0.25f;

    public GameObject deathScreen;
    
    public Text hp_text;
    public Text mp_text;
    public Text scr_text;
    public Text lvl_text;
    public Text lvlUp_text;
    public Text atk_text;
    public Text wit_text;
    public Text mgc_text;
    public Text spd_text;

    public GameObject deathObject;

    private GameObject player;
    private Stats playerStats;

    private void Start()
    {
        MaxHealth = 2 * Wit;
        Health = MaxHealth;
        maxMp = Mgc;
        Mp = maxMp;

        player = GameObject.FindWithTag("Player");
        playerStats = player.GetComponent<Stats>();
    }

    public void takeDamage(int damage)
    {
        Health -= damage;
        healthRecoery = Health + damage;

        //TODO: play anims
    }

    public void upAtk()
    {
        if (score >= lvlUpPrice)
        {
            Atk++;
            lvl++;
            score -= lvlUpPrice;
            lvlUpPrice += (int)(lvlUpPrice * 0.2f);
        }
    }

    public void upWit()
    {
        if (score >= lvlUpPrice)
        {
            Wit++;
            MaxHealth = MaxHealth + 1;
            Health += 2;
            lvl++;
            score -= lvlUpPrice;
            lvlUpPrice += (int)(lvlUpPrice * 0.2f);
        }
    }

    public void upMgc()
    {
        if (score >= lvlUpPrice)
        {
            Mgc++;
            maxMp += 2;
            Mp = maxMp;
            lvl++;
            score -= lvlUpPrice;
            lvlUpPrice += (int)(lvlUpPrice * 0.2f);
        }
    }

    public void upSpd()
    {
        if (score >= lvlUpPrice)
        {
            Spd++;
            lvl++;
            score -= lvlUpPrice;
            lvlUpPrice += (int)(lvlUpPrice * 0.2f);
        }
    }

    public void updateUI()
    {
        hp_text.text = Health.ToString();
        mp_text.text = Mp.ToString();
        scr_text.text = score.ToString();
        lvl_text.text = lvl.ToString();
        lvlUp_text.text = lvlUpPrice.ToString();
        atk_text.text = Atk.ToString();
        wit_text.text = Wit.ToString();
        mgc_text.text = Mgc.ToString();
        spd_text.text = Spd.ToString();
    }

    private void Update()
    {
        if(score >= lvlUpPrice)
        {

        }

        if(Health <= 0)
        {
            umrzyj();
        }
    }

    public void umrzyj()
    {
        if(!isPlayer)
        {
            Instantiate(deathObject, transform.position, Quaternion.identity);
            playerStats.score += (Atk + Mgc + Wit + Spd) / 2;
        }
        if(Random.Range(0,100) <= drapchance*100 && !isPlayer)
        {
            Instantiate(drops[Random.Range(0, drops.Count)], transform.position, Quaternion.identity);
        }
        
        if(isPlayer)
        {
            deathScreen.SetActive(true);
            this.enabled = false;
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
