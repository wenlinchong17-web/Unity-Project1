using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPoint : MonoBehaviour
{
    public Transform WeaponTransform;
    private GameObject CurrentWeapon;
    public GameObject StartingWeaponFab;
    
    // Start is called before the first frame update
    void Start()
    {
        if(StartingWeaponFab!=null)
            EquipWeapon(StartingWeaponFab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EquipWeapon(GameObject WeaponPointFab)
    {
        if (CurrentWeapon != null)
        {
            Destroy(CurrentWeapon);
        }

        CurrentWeapon = Instantiate(WeaponPointFab, WeaponTransform);
        CurrentWeapon.transform.localPosition = Vector3.zero;
        CurrentWeapon.transform.localRotation = Quaternion.identity;
        CurrentWeapon.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        
        SpriteRenderer sr = CurrentWeapon.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.sortingLayerName = "Character";
            sr.sortingOrder = 1;
        }
    }
}
