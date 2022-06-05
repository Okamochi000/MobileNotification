using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// テスト
/// </summary>
public class TestRun : MonoBehaviour
{
    [SerializeField] private InputField titleText = null;
    [SerializeField] private InputField bodyText = null;
    [SerializeField] private InputField badgeText = null;
    [SerializeField] private InputField dataText = null;
    [SerializeField] private InputField timeText = null;
    [SerializeField] private Text logText = null;

    private void OnEnable()
    {
        Application.logMessageReceived += OnLogMessageReceived;
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= OnLogMessageReceived;
    }

    // Start is called before the first frame update
    private void Start()
    {
        if (titleText != null) { titleText.text = "テスト通知"; }
        if (bodyText != null) { bodyText.text = "テストメッセージ"; }
        if (badgeText != null) { badgeText.text = "0"; }
        if (dataText != null) { dataText.text = "test data"; }
        if (timeText != null) { timeText.text = "5"; }
    }

    /// <summary>
    /// 通知送信
    /// </summary>
    public void SendNotification()
    {
        if (!LocalNotificationManager.IsActivePlatform())
        {
            Debug.Log("invaild platform.");
            return;
        }

        string title = titleText.text;
        string body = bodyText.text;
        int badge = int.Parse(badgeText.text);
        string data = dataText.text;
        int time = int.Parse(timeText.text);
        LocalNotificationManager.SendNotification(title, body, badge, time, data);
        Debug.Log("send notification.");
    }

    /// <summary>
    /// ログ取得
    /// </summary>
    /// <param name="condition"></param>
    /// <param name="stackTrace"></param>
    /// <param name="type"></param>
    private void OnLogMessageReceived(string condition, string stackTrace, LogType type)
    {
        if (logText == null) { return; }

        string msg = logText.text;
        if (msg == "") { msg += "-----\n"; }
        msg += (condition + System.Environment.NewLine);
        msg += "-----\n";
        logText.text = msg;
    }
}
