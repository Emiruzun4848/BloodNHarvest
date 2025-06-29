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
        Debug.Log($"Formatting value: {value}");
        double newValue = Mathf.Max(0,value);
        string[] suffixes = { "", "K", "M", "B", "T", "Qa", "Qi", "Sx", "Sp", "Oc", "No", "Dc" };
        int suffixIndex = 0;

        while (newValue >= 1000 && suffixIndex < suffixes.Length - 1)
        {
            newValue /= 1000;
            suffixIndex++;
        }

        string formatted;

        if (newValue < 10)
            formatted = newValue.ToString("0.###");    // ör. 1.23M
        else if (newValue < 100)
            formatted = newValue.ToString("0.##");     // ör. 12.3M
        else
            formatted = newValue.ToString("0.#");       // ör. 123M

        return $"{formatted}{suffixes[suffixIndex]}";
    }
}