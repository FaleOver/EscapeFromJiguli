using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndingMelons : MonoBehaviour
{
    private TextMeshProUGUI melons_text;

    void Start()
    {
        melons_text = GetComponent<TextMeshProUGUI>();
        melons_text.text = ItemCollector.count_melon + "/52";
    }
}
