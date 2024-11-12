using UnityEngine;
using TMPro;
using System.Globalization;

[RequireComponent(typeof(TextMeshProUGUI))]
public class SimpleTextMeshProBehaviour : MonoBehaviour
{
    private TextMeshProUGUI textObj;
    public SimpleIntData dataObj;

    private void Start()
    {
        textObj = GetComponent<TextMeshProUGUI>();
        UpdateWithIntData(); 
    }

    private void Update()
    {
        UpdateWithIntData(); // Continuously update the score each frame
    }

    public void UpdateWithIntData()
    {
        textObj.text = "Score: " + dataObj.value.ToString(CultureInfo.InvariantCulture); 
    }
}
