using TMPro;
using UnityEngine;

public class HealthDisplay : MonoBehaviour, IHealthDisplay
{
    [SerializeField] private TextMeshProUGUI _healthText; // Текстовый компонент для отображения HP

    void Start()
    {
        healthText = _healthText;
        UpdateHealthDisplay(); // Обновление отображения HP
    }

    public TextMeshProUGUI healthText { get; set; }

    public void UpdateHealthDisplay()
    {
        healthText.text = GetComponentInParent<IHealth>().Health.ToString(); // Обновление текста HP
    }
}
