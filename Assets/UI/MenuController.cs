using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject menuPanel;          // 菜单面板
    public GameObject settingsPanel;      // 可选，设置面板

    void Start()
    {
        // 确保菜单面板初始关闭
        if (menuPanel != null)
            menuPanel.SetActive(false);
        if (settingsPanel != null)
            settingsPanel.SetActive(false);
    }

    // 由菜单按钮调用，切换菜单面板显示
    public void ToggleMenu()
    {
        if (menuPanel != null)
            menuPanel.SetActive(!menuPanel.activeSelf);
    }

    // 继续游戏：关闭菜单面板
    public void ContinueGame()
    {
        if (menuPanel != null)
            menuPanel.SetActive(false);
        // 如果有暂停逻辑，可以在这里恢复时间缩放等
        Time.timeScale = 1f;
    }

    // 返回开始界面：加载开始场景
    public void ReturnToStart()
    {
        Time.timeScale = 1f; // 确保时间恢复正常
        SceneManager.LoadScene("StartScene"); // 替换为你的开始场景名称
    }

    // 功能设置：显示设置面板（如果实现）
    public void OpenSettings()
    {
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(true);
            // 可选：关闭菜单面板
            if (menuPanel != null) menuPanel.SetActive(false);
        }
        else
        {
            Debug.Log("设置面板未指定");
        }
    }

    // 关闭设置面板（通常由设置面板内的关闭按钮调用）
    public void CloseSettings()
    {
        if (settingsPanel != null)
            settingsPanel.SetActive(false);
        // 重新打开菜单面板（如果需要）
        if (menuPanel != null) menuPanel.SetActive(true);
    }
}