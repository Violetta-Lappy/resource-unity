using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public WaveSystem spawner;
    
    [Header("Health feedback")]
    public float flashDuration = 0.15f; //time to flash
    public int timeToFlash = 3; //times player plashes when take a damage
    public Material flashingMat;
    public Renderer meshRenderer;
    private bool isFlashing = false;
    private int flashTime; //times player have flash
    public List<Material> _defaultMats = new List<Material>();

    [Header("Health information")]
    [SerializeField] private float currentHealth; //player current health
    public float maxHealth = 100; //player max health

    // public float maxHealth = 100; //player maximum health value


    private int maxHeart;
    private int startHeart = 10;
    public int healthPerHeart = 5;

    [SerializeField] private Image[] heartImg;
    [SerializeField] private Sprite[] heartSprite;

    public GameObject losePanel;

    public bool canReceiveDamage;
    // Start is called before the first frame update
    void Start()
    {
        //set full health at start
        currentHealth = maxHealth;
        maxHeart = (int) maxHealth/healthPerHeart;
        startHeart = maxHeart;
        //  maxHeart = heartImg.Length;
        // currentHealth = startHeart * healthPerHeart;
        //  maxHealth = maxHeart * healthPerHeart;
        HealthUIUpdate();

        foreach (Material mat in meshRenderer.materials)
        {
            _defaultMats.Add(mat);
        }
    }

    public void Damage(int damage)
    {
        if (isFlashing || !canReceiveDamage) return;

        TakeDamage(damage);
    }

    void TakeDamage(int damage)
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySFX_Game(ENUM_AUDIO_SFX_TYPE.HIT_IMPACT);
        }

        //decrease health
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            //Die();
            SaveDataMNG.Save_GameCurrency(0);
            MasterGameSystem.Instance.Annouce_GameEnd(ENUM_GAME_END_TYPE.LOSE);
            return;
        }

        StartCoroutine(FlashRoutine(flashDuration));


        // currentHealth = Mathf.Clamp(currentHealth, 0, startHeart * healthPerHeart);
        UpdateHeart();
    }

    public void Die()
    {
        losePanel.SetActive(true);
        Time.timeScale = 0;
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Y))
        //{
        //    Damage(20);
        //}
    }


    void HealthUIUpdate()
    {

        UpdateHeart();


        for (int i = 0; i < heartImg.Length; i++)
        {
            if (startHeart <= i)
            {
                heartImg[i].enabled = false;
            }
            if (startHeart > i)
            {
                heartImg[i].enabled = true;
            }
        }

    }

    void UpdateHeart()
    {
        bool empty = false;
        int i = 0;

        foreach (Image img in heartImg)
        {
            if (empty)
            {
                img.sprite = heartSprite[0];
            }
            else
            {
                i++;

                if (currentHealth >= i * healthPerHeart)
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
        currentHealth = Mathf.Clamp(currentHealth, 0, startHeart * healthPerHeart);
        UpdateHeart();

    }

    IEnumerator FlashRoutine(float flashDuration)
    {
        for (int i = 0; i < timeToFlash; i++)
        {
            Material[] tempMats = meshRenderer.materials;
            isFlashing = true;

            // foreach (Material currentMat in meshRenderer.materials)
            // {
            //     currentMat = flashingMat;
            // }

            for (int x = 0; x < tempMats.Length; x++)
            {
                tempMats[x] = flashingMat;
            }

            meshRenderer.materials = tempMats;
            //meshRenderer.material = flashMat;
            yield return new WaitForSeconds(flashDuration);

            flashTime++;

            for (int x = 0; x < tempMats.Length; x++)
            {
                tempMats[x] = _defaultMats[x];
            }
            meshRenderer.materials = tempMats;

            //meshRenderer.material = originalMat;

            yield return new WaitForSeconds(flashDuration);
        }

        if (flashTime >= timeToFlash)
        {
            isFlashing = false;
            flashTime = 0;
        }
    }
}
