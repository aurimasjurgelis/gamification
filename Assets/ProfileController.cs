using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProfileController : MonoBehaviour
{
    public static ProfileController Instance { get; private set; }

    //Singleton
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        FetchData();
    }


    [Header("Avatar Equipment")]
    public GameObject head;
    public GameObject body;
    public GameObject weapon;
    public GameObject pants;
    public GameObject shield;

    [Header("Avatar Equipment Scriptable Objects")]
    public Equipment helmetItem;
    public Equipment bodyArmorItem;
    public Equipment weaponItem;
    public Equipment legArmorItem;
    public Equipment shieldItem;



    [Header("Avatar Meshes")]
    public Mesh shirt;
    public Mesh helmet;
    public Mesh hair;
    public Mesh platearmor;
    public Material shirtMaterial;
    public Material pantsMaterial;
    public Material armoredMaterial;
    public Material hairMaterial;

    public Material metal;
    public Material trim;
    public Material trim_white;

    [Header("Equip Toggles")]
    public bool helmetToggle = true;
    public bool bodyToggle = true;
    public bool weaponToggle = true;
    public bool legsToggle = true;
    public bool shieldToggle = true;


    [Header("Profile Information")]
    public TextMeshProUGUI fullname;
    public TextMeshProUGUI position;
    public TextMeshProUGUI level;
    public TextMeshProUGUI xp;


    public void FetchData()
    {
        fullname.text = PlayerPrefs.GetString("fullname") == "" ? "Aurimas Jurgelis" : PlayerPrefs.GetString("fullname");
        position.text = PlayerPrefs.GetString("position") == "" ? "Software Engineer" : PlayerPrefs.GetString("position");
        level.text = PlayerPrefs.GetString("level") == "" ? "1" : PlayerPrefs.GetString("level");
        
    }

    public void ToggleHelmet()
    {
        xp.text = ProgressionController.Instance.GetStats()["xp"].ToString();
        Debug.Log("ToggleHelmet()");
        Material[] hairMaterials = { hairMaterial, hairMaterial, hairMaterial };
        Material[] helmetMaterials = { metal, trim, trim_white };
        if (helmetToggle)
        {
            head.GetComponent<SkinnedMeshRenderer>().sharedMesh = hair;
            head.GetComponent<SkinnedMeshRenderer>().materials = hairMaterials;
            Inventory.instance.Add(helmetItem);
        }
        else
        {
            head.GetComponent<SkinnedMeshRenderer>().sharedMesh = helmet;
            head.GetComponent<SkinnedMeshRenderer>().materials = helmetMaterials;
            Inventory.instance.Remove(helmetItem);
        }
        helmetToggle = !helmetToggle;

    }

    public void ToggleBody()
    {
        Debug.Log("ToggleBody()");
        if (bodyToggle)
        {
            body.GetComponent<SkinnedMeshRenderer>().sharedMesh = shirt;
            body.GetComponent<SkinnedMeshRenderer>().material = shirtMaterial;
            Inventory.instance.Add(bodyArmorItem);

        }
        else
        {
            body.GetComponent<SkinnedMeshRenderer>().sharedMesh = platearmor;
            body.GetComponent<SkinnedMeshRenderer>().material = armoredMaterial;
            Inventory.instance.Remove(bodyArmorItem);
        }
        bodyToggle = !bodyToggle;
    }

    public void ToggleWeapon()
    {
        Debug.Log("ToggleWeapon()");
        if (weaponToggle) Inventory.instance.Add(weaponItem);
        else Inventory.instance.Remove(weaponItem);
        weaponToggle = !weaponToggle;
        weapon.SetActive(weaponToggle);
    }

    public void ToggleLegs()
    {
        Debug.Log("ToggleLegs()");
        legsToggle = !legsToggle;
        if (legsToggle)
        {
            pants.GetComponent<SkinnedMeshRenderer>().material = armoredMaterial;
            Inventory.instance.Remove(legArmorItem);
        }
        else
        {
            pants.GetComponent<SkinnedMeshRenderer>().material = pantsMaterial;
            Inventory.instance.Add(legArmorItem);
        }
    }

    public void ToggleShield()
    {
        Debug.Log("ToggleShield()");
        if (shieldToggle) Inventory.instance.Add(shieldItem);
        else Inventory.instance.Remove(shieldItem);
        shieldToggle = !shieldToggle;
        shield.SetActive(shieldToggle);
    }


}
