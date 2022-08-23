using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightAndDay : MonoBehaviour
{
    static bool day = true;
    public static bool Day { get => day; }


    [SerializeField] GameObject dayLight;
    [SerializeField] GameObject nightLight;
    bool invoked = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (day && invoked == false)
        {
            Invoke("ChangeToNight",20f);
            invoked = true;
        }
        else if (!day && invoked == false)
        {
            Invoke("ChangeToDay", 20f);
            invoked = true;
        }
    }
    void ChangeToNight()
    {
        day = false;
        nightLight.SetActive(true);
        dayLight.SetActive(false);
        invoked = false;
    }
    void ChangeToDay()
    {
        day = true;
        nightLight.SetActive(false);
        dayLight.SetActive(true);
        invoked = false;
    }
}
