using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public interface IHealthDisplay
{
    public TextMeshProUGUI healthText { get; set; }

    public void UpdateHealthDisplay();
}
