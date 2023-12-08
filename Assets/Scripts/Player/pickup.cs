using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    [SerializeField] private spell scroll;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerStats statystyki = collision.gameObject.GetComponent<PlayerStats>();
            if(!statystyki.spellbook.Contains(scroll))
            {
                statystyki.spellbook.Add(scroll);
            }
            
            Destroy(gameObject);
        }
    }
}
