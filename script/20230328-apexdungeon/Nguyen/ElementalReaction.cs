using UnityEngine;

namespace Nguyên.TopDownShooter
{
    public class ElementalReaction : MonoBehaviour
    {
//     public Elements[] elements = new Elements[3]; //An array stores all element
//     private bool isReacting = false;
//     public bool isFire;
//     public bool isWood;
//     public bool isWater;
//
//     // Start is called before the first frame update
//     void Start()
//     {
//         //Debug.Log("Decrease " + elements.dame + " hp");
//     }
//
//     // Update is called once per frame
//     void Update()
//     {
//
//     }
//
//     void OnCollisionEnter(Collision coll)
//     {
//         /*if (isReacting)
//         {
//             if (isWood)
//             {
//                 this.gameObject.name = "Wood Element";
//
//                 if (coll.gameObject.name == "Fire Element")
//                 {
//                     StartCoroutine(NegativeReaction(elements[0], 15));
//                 }
//                 else if (coll.gameObject.name == "Water Element")
//                 {
//                     StartCoroutine(PositiveReaction(elements[1], 0));
//                 }
//             }
//
//             if (isFire)
//             {
//                 this.gameObject.name = "Fire Element";
//
//                 if (coll.gameObject.name == "Water Element")
//                 {
//                     StartCoroutine(NegativeReaction(elements[0], 10));
//                 }
//             }
//         }*/
//     }  
//
//     void OnTriggerEnter(Collider coll)
//     {
//         if (!isReacting)
//         {
//             if (isWood)
//             {
//                 this.gameObject.name = "Wood Element";
//
//                 if (coll.gameObject.name == "Fire Element")
//                 {
//                     StartCoroutine(NegativeReaction(elements[0], 15));
//                 }
//                 else if (coll.gameObject.name == "Water Element")
//                 {
//                     StartCoroutine(PositiveReaction(elements[1], 0));
//                 }
//
//                 if (coll.GetComponent<GeneralHealth>() != null)
//                 {
//                     StartCoroutine(coll.GetComponent<GeneralHealth>().DamageOverTime(elements[2]));
//                 }
//             }
//
//             if (isFire)
//             {
//                 this.gameObject.name = "Fire Element";
//
//                 if (coll.gameObject.name == "Water Element")
//                 {
//                     StartCoroutine(NegativeReaction(elements[1], 10));
//                 }
//
//                 if (coll.GetComponent<GeneralHealth>() != null)
//                 {
//                     StartCoroutine(coll.GetComponent<GeneralHealth>().DamageOverTime(elements[0]));
//                 }
//             }
//
//             if(isWater)
//             {
//                 this.gameObject.name = "Water Element";
//
//                 if (coll.GetComponent<GeneralHealth>() != null)
//                 {
//                     StartCoroutine(coll.GetComponent<GeneralHealth>().DamageOverTime(elements[1]));
//                 }
//             }
//         }
//     }
//
//     //Called in OnTriggerEnter()
//     IEnumerator NegativeReaction(Elements element, int healthPoint)
//     {
//         isReacting = true;
//
//         for (int i = 0; i < 100; i++)
//         {
//             healthPoint -= element.dame;
//             yield return new WaitForSeconds(1f);
//             transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
//             //Debug.Log(transform.localScale);
//
//             if (healthPoint <= 0)
//             {
//                 Destroy(this.gameObject);
//             }
//         }
//     }
//
//     //Called in OnTriggerEnter()
//     IEnumerator PositiveReaction(Elements element, int healthPoint)
//     {
//         isReacting = true;
//
//         for (int i = 0; i < 100; i++)
//         {
//             healthPoint += element.dame;
//             //Debug.Log("Increase " + element.dame + " hp");
//             yield return new WaitForSeconds(1f);
//             transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
//
//             if (healthPoint >= 15)
//             {
//                 break;
//             }
//         }
//     }
    }
}
