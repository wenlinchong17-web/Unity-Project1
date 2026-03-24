using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [Header("UI 组件")]
    public Slider healthSlider;
    public Slider manaSlider;
    public Text healthText;   // 可选
    public Text manaText;     // 可选

    [Header("伤害数字")]
    public GameObject damageTextPrefab; // 伤害数字预制体
    public Transform canvasTransform;

    private Character character;

    void Awake()
    {
        character = GetComponent<Character>();
        if (character == null)
        {
            Debug.LogError("PlayerStats: 未找到 Character 组件！");
            enabled = false;
            return;
        }
    }

    void Start()
    {
        // 初始更新一次 UI
        UpdateUI();
    }

    /// <summary>
    /// 当角色受到伤害时，由 Character.TakeDamage 调用
    /// </summary>
    public void OnTakeDamage(int damage)
    {
        // 更新 UI
        UpdateUI();

        // 显示伤害数字
        ShowDamage(damage, transform.position);

        // 如果死亡，这里也可以做一些额外处理（例如播放死亡动画）
        if (character.CurrentHP <= 0)
        {
            // 可选：死亡时的 UI 特效
            Debug.Log("PlayerStats: 角色死亡");
        }
    }

    /// <summary>
    /// 更新所有 UI 组件（从 Character 读取数值）
    /// </summary>
    private void UpdateUI()
    {
        if (healthSlider != null)
            healthSlider.value = (float)character.CurrentHP / character.MaxHP;
        if (manaSlider != null)
            manaSlider.value = (float)character.CurrentMP / character.MaxMP;

        if (healthText != null)
            healthText.text = character.CurrentHP + " / " + character.MaxHP;
        if (manaText != null)
            manaText.text = character.CurrentMP + " / " + character.MaxMP;
    }

    /// <summary>
    /// 显示伤害数字（世界坐标转屏幕坐标）
    /// </summary>
    private void ShowDamage(int damage, Vector3 worldPosition)
    {
        if (damageTextPrefab == null || canvasTransform == null || Camera.main == null)
            return;

        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPosition);
        GameObject damageObj = Instantiate(damageTextPrefab, screenPos, Quaternion.identity, canvasTransform);
        DamageText damageText = damageObj.GetComponent<DamageText>();
        if (damageText != null)
            damageText.SetDamage(damage);
    }

    // 可选：治疗、法力消耗等也需要同步 UI
    // 如果 Character 中也有治疗/法力方法，同样可以在那些方法中调用 PlayerStats 的对应更新方法
    public void OnHeal()
    {
        UpdateUI();
    }

    public void OnManaChange()
    {
        UpdateUI();
    }
}