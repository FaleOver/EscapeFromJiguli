using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MelonsCount : MonoBehaviour
{
    private TextMeshProUGUI melons_text;

    void Start()
    {
        melons_text = GetComponent<TextMeshProUGUI>();
        melons_text.text = "Melons: " + ItemCollector.count_melon;
    }
}
