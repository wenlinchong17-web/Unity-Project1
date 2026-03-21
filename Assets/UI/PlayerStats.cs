using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int maxMana = 100;
    public int currentMana;

    public Slider healthSlider;
    public Slider manaSlider;
    public Text healthText;   // 可选
    public Text manaText;     // 可选

    public GameObject damageTextPrefab; // 伤害数字预制体
    public Transform canvasTransform;

    void Start()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;
        UpdateUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateUI();

        // 显示伤害数字（假设角色位置为transform.position）
        ShowDamage(damage, transform.position);
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateUI();
    }

    public void UseMana(int amount)
    {
        currentMana -= amount;
        currentMana = Mathf.Clamp(currentMana, 0, maxMana);
        UpdateUI();
    }

    private void UpdateUI()
    {
        healthSlider.value = currentHealth;
        manaSlider.value = currentMana;
        if (healthText != null) healthText.text = currentHealth + " / " + maxHealth;
        if (manaText != null) manaText.text = currentMana + " / " + maxMana;
    }

    private void ShowDamage(int damage, Vector3 worldPosition)
    {
        if (damageTextPrefab == null) { Debug.LogError("damageTextPrefab 为空"); return; }
        if (canvasTransform == null) { Debug.LogError("canvasTransform 为空"); return; }
        if (Camera.main == null) { Debug.LogError("Camera.main 为空"); return; }
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPosition);
        GameObject damageObj = Instantiate(damageTextPrefab, screenPos, Quaternion.identity, canvasTransform);
        damageObj.GetComponent<DamageText>().SetDamage(damage);
    }
    void Update()
    {
        // 按数字键 1 造成 10 点伤害
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TakeDamage(10);
        }
        // 按数字键 2 造成 20 点伤害
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TakeDamage(20);
        }
        // 按数字键 3 回血 10 点（可选，用于测试恢复）
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Heal(10);
        }
    }
}