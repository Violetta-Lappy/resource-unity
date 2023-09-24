using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUpDamage : MonoBehaviour
{
    public GameObject floatingText;
    public float yOffset;
    public float spread;

    private void Start()
    {
        
    }

    public void FloatingDamage(float damage)
    {
        float dirSpread = Random.Range(-spread, spread);

        if (floatingText)
        {
            floatingText.GetComponent<TextMeshPro>().text = damage.ToString();
            Instantiate(floatingText, transform.position + new Vector3(dirSpread, yOffset, dirSpread), Quaternion.identity);
        }
    }
}
