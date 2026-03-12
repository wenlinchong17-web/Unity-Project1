using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Weapon,
    Consumable
}

public class Item : MonoBehaviour
{
    public string ItemName;
    public Sprite ItemSprite;
    public ItemType ItemKind;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
