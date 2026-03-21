using UnityEngine;
using UnityEngine.UI;

public class DamageText : MonoBehaviour
{
    public float moveSpeed = 50f;
    public float fadeSpeed = 2f;
    public float lifetime = 1f;

    private Text text;

    void Awake()
    {
        text = GetComponent<Text>();
        if (text == null)
        {
            Debug.LogError("DamageText 预制体缺少 Text 组件！", gameObject);
            Destroy(gameObject);
        }
        else
        {
            // 可选：记录原始颜色，用于淡出
            originalColor = text.color;
        }
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        if (text == null) return;
        // 向上移动
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        // 淡出效果
        Color newColor = text.color;
        newColor.a -= fadeSpeed * Time.deltaTime;
        text.color = newColor;
    }

    public void SetDamage(int damage)
    {
        if (text == null)
        {
            // 如果还未获取，尝试立即获取
            text = GetComponent<Text>();
            if (text == null)
            {
                Debug.LogError("SetDamage 时无法获取 Text 组件！", gameObject);
                return;
            }
        }
        text.text = damage.ToString();
    }

    private Color originalColor;
}