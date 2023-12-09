using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class Equipment : MonoBehaviour
{
    //Player Stats Ref
    [SerializeField] private PlayerStats playerStats;

    //Currently equipped
    public Weapon mainHand;
    public Offhand offhand;
    public Armor armor;

    //Rest
    public List<Item> items;
    public int backpackSize;
    public int itemCnt = 0;

    //UI
    [SerializeField] private GameObject itemSlotPrefab;
    [SerializeField] private GameObject invPanel;
    [SerializeField] private List<GameObject> prefabs;

    private void Awake()
    {
        playerStats = GetComponent<PlayerStats>();

        items = new List<Item>();
        mainHand = null;
        offhand = null;
        armor = null;

        for(int i = 0; i < backpackSize; i++ )
        {
            items.Add(null);
            GameObject a = Instantiate(itemSlotPrefab, invPanel.transform);
            prefabs.Add( a );
        }
    }


    public void updateInventory()
    {
        for(int i = 0; i < backpackSize; i++)
        {
            if (items[i] != null)
            {
                prefabs[i].GetComponent<Image>().sprite = items[i].sprite;
                int j = i;
                prefabs[i].GetComponent<Button>().onClick.RemoveAllListeners();
                prefabs[i].GetComponent<Button>().onClick.AddListener(() => onClick(j));
            }
            else
            {
                prefabs[i].GetComponent<Button>().onClick.RemoveAllListeners();
                prefabs[i].GetComponent<Image>().sprite = null;
            }
        }
    }

    public void onClick(int id)
    {
        if (items[id] is Weapon)
        {
            if(mainHand != null)
            {
                mainHand.onUnEquip(playerStats);
                mainHand = null;
            }
            ((Weapon)items[id]).onEquip(playerStats);
            Weapon tmp = (Weapon)items[id];
            items[id] = mainHand;
            mainHand = tmp;
        }
        else if (items[id] is Offhand)
        {
            if (offhand != null)
            {
                offhand.onUnEquip(playerStats);
                offhand = null;
            }
            ((Offhand)items[id]).onEquip(playerStats);
            Offhand tmp = (Offhand)items[id];
            items[id] = offhand;
            offhand = tmp;
        }
        else if (items[id] is Armor)
        {
            if (armor != null)
            {
                armor.onUnEquip(playerStats);
                armor = null;
            }
            ((Armor)items[id]).onEquip(playerStats);
            Armor tmp = (Armor)items[id];
            items[id] = armor;
            armor = tmp;
        }
        else if(items[id] is Usable)
        {
            ((Usable)items[id]).use(playerStats);
            for(int i = id; i < itemCnt; i++)
            {
                items[i] = items[i + 1];
            }
            itemCnt--;
        }
        else
        {
            return;
        }

        updateInventory();
    }

    private void Update()
    {
        //updateInventory();
    }
}
