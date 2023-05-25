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

    public static float pistolDamage = 20f;
    public static float pmDamage = 30f;
    public static float m4Damage = 60f; 


    public GameObject pistolImage;
    public GameObject pmImage;
    public GameObject m4Image;

    //weapons selection table
    public GameObject pistolMiniImage;
    public GameObject pmMiniImage;
    public GameObject m4MiniImage;

    void Start()
    {
        pmImage.SetActive(false);
        m4Image.SetActive(false);
        pmMiniImage.SetActive(false);
        m4MiniImage.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (currentGun == Guns.Pistol) { return; }

            pistolImage.SetActive(true);
            pmImage.SetActive(false);
            m4Image.SetActive(false);

            pistolMiniImage.SetActive(true);
            pmMiniImage.SetActive(false);
            m4MiniImage.SetActive(false);

            currentGun = Guns.Pistol;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (currentGun == Guns.PM) { return; }

            pistolImage.SetActive(false);
            pmImage.SetActive(true);
            m4Image.SetActive(false);

            pistolMiniImage.SetActive(false);
            pmMiniImage.SetActive(true);
            m4MiniImage.SetActive(false);

            currentGun = Guns.PM;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (currentGun == Guns.M4) { return; }

            pistolImage.SetActive(false);
            pmImage.SetActive(false);
            m4Image.SetActive(true);

            pistolMiniImage.SetActive(false);
            pmMiniImage.SetActive(false);
            m4MiniImage.SetActive(true);

            currentGun = Guns.M4;
        }

    }

}
