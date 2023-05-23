using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunsController : MonoBehaviour
{
    public enum Guns
    {
        Pistol,
        PM,
        M4
    }

    public static Guns currentGun = Guns.Pistol;

    public GameObject pistolImage;
    public GameObject pmImage;
    public GameObject m4Image;

    // Start is called before the first frame update
    void Start()
    {
        pmImage.SetActive(false);
        m4Image.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (currentGun == Guns.Pistol) { return; }
            Debug.Log("change");
            pistolImage.SetActive(true);
            pmImage.SetActive(false);
            m4Image.SetActive(false);

            currentGun = Guns.Pistol;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (currentGun == Guns.PM) { return; }

            pistolImage.SetActive(false);
            pmImage.SetActive(true);
            m4Image.SetActive(false);

            currentGun = Guns.PM;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (currentGun == Guns.M4) { return; }

            pistolImage.SetActive(false);
            pmImage.SetActive(false);
            m4Image.SetActive(true);

            currentGun = Guns.M4;
        }

    }

    public void WeaponChange()
    {

    }
}
