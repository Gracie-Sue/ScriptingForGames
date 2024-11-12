using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SimpleImageBehaviour : MonoBehaviour
{
    private Image imageObj;

    [SerializeField]  // This ensures the field shows in the Inspector even if it is private
    public SimpleFloatData dataObj; 

    private void Start()
    {
        imageObj = GetComponent<Image>();
    }

    private void Update()
    {
        UpdateWithFloatData();
    }

    public void UpdateWithFloatData()
    {
        imageObj.fillAmount = dataObj.value;
    }
}