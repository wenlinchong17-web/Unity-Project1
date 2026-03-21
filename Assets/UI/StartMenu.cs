using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        // 加载游戏场景，假设你的游戏场景名为"GameScene"
        SceneManager.LoadScene("GameScene");
    }

    public void OpenSettings()
    {
        // 打开设置面板（此处示例为简单显示/隐藏，你可以单独实现一个设置界面）
        Debug.Log("打开设置面板");
        // 例如：settingsPanel.SetActive(true);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // 编辑器下停止运行
#else
        Application.Quit(); // 退出应用
#endif
    }
}