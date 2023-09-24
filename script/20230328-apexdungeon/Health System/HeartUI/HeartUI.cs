using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HeartUI : MonoBehaviour
{
    private int maxHeart;
    [SerializeField] private int startHeart = 4;
    private int healthPerHeart=4;
    private int currentHealth ;
    private int maxHealth;

    [SerializeField] private Image[] heartImg;
    [SerializeField] private Sprite[] heartSprite;

    // Start is called before the first frame update
    void Start()
    {
        maxHeart = heartImg.Length;
        currentHealth = startHeart * healthPerHeart;
        maxHealth = maxHeart* healthPerHeart;
        HealthUIUpdate();
    }

    void HealthUIUpdate()
    {
        for(int i = 0; i < maxHeart; i++)
        {

            if (startHeart > i)
            {
                heartImg[i].enabled = true;

            }
            else
            {
                heartImg[i].enabled = false;
            }
        }

        UpdateHeart();
    }

    void UpdateHeart()
    {
        bool empty = false;
        int i = 0;

        foreach(Image img in heartImg)
        {
            if (empty)
            {
                img.sprite = heartSprite[0];
            }
            else
            {
                i++;

                if(currentHealth >= i * healthPerHeart)
                {
                    img.sprite = heartSprite[heartSprite.Length - 1];
                }
                else
                {
                    int currentHeart = (int)(healthPerHeart - (healthPerHeart * i - currentHealth));
                    int healthPerImage = healthPerHeart / (heartSprite.Length - 1);
                    int imgIndex = currentHeart / healthPerImage;
                    img.sprite = heartSprite[imgIndex];

                    empty = true;
                }
            }
        }
    }

    public void ChangeHeathValue(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth,0, startHeart*healthPerHeart);
        UpdateHeart();

    }

    void AddHeartContainer()
    {
        startHeart++;
        startHeart = Mathf.Clamp(startHeart, 0, maxHeart);
       //  currentHealth = startHeart * healthPerHeart;
      //   maxHealth = maxHeart * healthPerHeart;
        HealthUIUpdate();
    }

    private void Update()
    {
        //Test take damage
        if (Input.GetKeyDown(KeyCode.T))
        {
            ChangeHeathValue(-1);
            Debug.Log("take damage");
        }

        //Test take heal
        if (Input.GetKeyDown(KeyCode.R))
        {
            ChangeHeathValue(1);
            Debug.Log("heal");
        }

        //Test add containers
        if (Input.GetKeyDown(KeyCode.E))
        {
            AddHeartContainer();
        }
    }

}
