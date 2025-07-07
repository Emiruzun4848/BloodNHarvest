using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NightUIManager : MonoBehaviour
{
    public static NightUIManager Instance; // Singleton instance
    public Player player; // Reference to the Player component
    public Slider healthSlider; // Reference to the health slider
    public TMP_Text healthText; // Reference to the health slider
    public TMP_Text shieldText; // Reference to the health slider
                                //Bakılacak

    void DoInstance()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep this instance across scenes
        }
        else
        {
            Destroy(gameObject); // Ensure only one instance exists
        }
    }


    private void Awake()
    {
        DoInstance();
    }
    public void ChangePlayerHealthUI(float health, float maxHealth)
    {
        healthSlider.value = health;
        healthSlider.maxValue = maxHealth;                        
        healthText.text = FormatNumber(health);
    }
    public void ChangePlayerShieldUI(float shieldAmount)
    {
        int roundedShield = (int)Mathf.Ceil(shieldAmount);
        shieldText.text = "+" + roundedShield.ToString();
    }

    string FormatNumber(float value)
    {
        int newValue = (int)Mathf.Max(0, value);
        int extendex = 0;
        string[] suffixes = { "", "K", "M", "B", "T", "Qa", "Qi", "Sx", "Sp", "Oc", "No", "Dc" };
        int suffixIndex = 0;

        while (newValue >= 1000 && suffixIndex < suffixes.Length - 1)
        {
            extendex = newValue % 1000;
            newValue /= 1000;
            suffixIndex++;
        }

        float shortValue = newValue + (extendex / 1000f);
        string formatted;

        if (shortValue < 10)
            formatted = shortValue.ToString("0.00");
        else if (shortValue < 100)
            formatted = shortValue.ToString("0.0");
        else
            formatted = shortValue.ToString("0");

        return $"{formatted}{suffixes[suffixIndex]}";
    }

}