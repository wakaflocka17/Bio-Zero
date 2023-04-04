using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviour : MonoBehaviour
{
    public Slider slider;

    public CharacterHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GetComponent<CharacterHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        FillHealthBar();
    }

    private void FillHealthBar()
    {
        slider.value = playerHealth.getHealth();
    }
}
