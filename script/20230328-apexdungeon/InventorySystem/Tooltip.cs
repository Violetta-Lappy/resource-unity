using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Text;

public class Tooltip : MonoBehaviour
{
    private RectTransform rect;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI statText;

    private StringBuilder sb = new StringBuilder();

    public bool followMouse = true;
    public GameObject offsetObject;
    public Vector3 offset = new Vector3(15, 25);


    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        HideTooltip();
    }

    private void LateUpdate()
    {

        if (followMouse)
        {
            transform.position = Input.mousePosition + offset;

        }
        else
        {

            float x = offsetObject.transform.position.x + offsetObject.GetComponent<RectTransform>().rect.width / 2;

            transform.position = new Vector3(x, offsetObject.transform.position.y, offsetObject.transform.position.z);

           // float yPos = offsetObject.transform.position.y - offsetObject.GetComponent<RectTransform>().rect.height / 2 - GetComponent<RectTransform>().rect.height / 2;

          //  transform.position = new Vector3(offsetObject.transform.position.x, yPos, offsetObject.transform.position.z) + offset;

        }

    }

    public void ShowToolTip(ItemInventory item)
    {
        nameText.text = item.itemName;

        sb.Length = 0;
        //AddStat(item.itemStat, "Stat: ");

        statText.text = sb.ToString();
        gameObject.SetActive(true);

    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);
    }

    private void AddStat(float value, string statName)
    {
        if (value != 0)
        {
            if (sb.Length > 0)
            {
                sb.AppendLine();
            }


            if (value > 0)
            {
                sb.Append(statName);
                sb.Append(" ");
                sb.Append(value);

            }

        }

    }

}
