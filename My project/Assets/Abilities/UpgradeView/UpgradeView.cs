using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class UpgradeView : MonoBehaviour
{
    [SerializeField] float increaseView = 9f;
    [SerializeField] float abilityDuration = 10f;
    [SerializeField] float cooldown = 15f;
    [SerializeField] Sprite upgradeViewIcon;

    float currentView;
    bool abilityActive = false;
    bool decreasingView = false;
    float cooldownCount = 15f;
    bool inCooldown = false;

    Image abilitiesImage;
    Slider abilitiesSlider;
    AbilitySlider setCooldown;
    IsProtaActive isProtaActive;

    private void Start()
    {
        if (transform.GetSiblingIndex() == 0)
        {
            abilitiesImage = FindObjectOfType<Canvas>().transform.Find("AbilityPanel").GetChild(0).GetComponent<Image>();
            abilitiesSlider = FindObjectOfType<Canvas>().transform.Find("AbilityPanel").GetChild(0).GetComponent<Slider>();
            setCooldown = FindObjectOfType<Canvas>().transform.Find("AbilityPanel").GetChild(0).GetComponent<AbilitySlider>();
        }
        else if (transform.GetSiblingIndex() == 1) 
        {
            abilitiesImage = FindObjectOfType<Canvas>().transform.Find("AbilityPanel").GetChild(1).GetComponent<Image>();
            abilitiesSlider = FindObjectOfType<Canvas>().transform.Find("AbilityPanel").GetChild(1).GetComponent<Slider>();
            setCooldown = FindObjectOfType<Canvas>().transform.Find("AbilityPanel").GetChild(1).GetComponent<AbilitySlider>();
        }

        abilitiesImage.sprite = upgradeViewIcon;
        abilitiesImage.color = new Color(abilitiesImage.color.r, abilitiesImage.color.g, abilitiesImage.color.b, 1);
        abilitiesSlider.maxValue = cooldown;
        isProtaActive = transform.parent.GetComponent<IsProtaActive>();
    }
    private void Update()
    {
        if (cooldownCount < cooldown)
        {
            cooldownCount += Time.deltaTime;
            inCooldown = true;
        }
        else inCooldown = false;


        if (Input.GetKeyDown(KeyCode.Alpha1) && !inCooldown && isProtaActive.protaActive) 
        { 
            currentView = Camera.main.fieldOfView;
            abilityActive = true;
            Invoke("DecreasingView", abilityDuration);
            Invoke("DisableAbility", abilityDuration + 1f);
            cooldownCount = 0;
            setCooldown.StartCooldownCount();
        }
        if (abilityActive) IncreasingView();
        else if (decreasingView) DecreaseView();
    }
    private void DisableAbility()
    {
        abilityActive = false;
        decreasingView = false;
        Camera.main.fieldOfView = currentView;
    }
    void IncreasingView()
    {
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, currentView + increaseView, 0.01f);
    }
    void DecreasingView()
    {
        decreasingView = true;
        abilityActive = false;
    }
    void DecreaseView()
    {
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, currentView, 0.01f);
    }
}
