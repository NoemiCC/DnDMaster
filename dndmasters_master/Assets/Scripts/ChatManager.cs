using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Photon.Chat;
using ExitGames.Client.Photon;
using UnityEngine.SceneManagement;

public class ChatManager : MonoBehaviour, IChatClientListener
{
    public GameObject messagesContainer;
    ChatClient chatClient;
    public Text messagesText;
    public InputField textInput;
    string username;
    // Start is called before the first frame update
    void Start()
    {
        username = PlayerPrefs.GetString("username", "Anon");
        chatClient = new ChatClient(this);
        chatClient.Connect(PhotonNetwork.PhotonServerSettings.ChatAppID, "1.0", new Photon.Chat.AuthenticationValues(username));
    }

    // Update is called once per frame
    void Update()
    {
        if (chatClient != null) {
            chatClient.Service();
        }

        HandleMessageSubmit();
    }

    public void HandleMessageSubmit() {
        if(chatClient == null) return;

        if (textInput.text != "" && Input.GetKey(KeyCode.Return)) {
            chatClient.PublishMessage( "global", textInput.text );
            textInput.text = "";

            StartCoroutine(CoFocusAgain());
        }
    }

    public void SendOnClick() {
        if(chatClient == null) return;

        if (textInput.text != "") {
            chatClient.PublishMessage( "global", textInput.text );
            textInput.text = "";

            StartCoroutine(CoFocusAgain());
        }
    }

    IEnumerator CoFocusAgain() {
        yield return new WaitForSeconds(.1f);

        textInput.Select();
        textInput.ActivateInputField();
    }

    void OnDestroy() {
        if (chatClient != null) {
            chatClient.Disconnect();
        }
    }

    public void DebugReturn(DebugLevel level, string message)
    {
        // throw new System.NotImplementedException();
    }

    public void OnChatStateChange(ChatState state)
    {
        // throw new System.NotImplementedException();
    }

    public void OnConnected()
    {
        textInput.text = "";
        chatClient.Subscribe(new string[] {"global"});
        chatClient.SetOnlineStatus(ChatUserStatus.Online);
    }

    public void OnDisconnected()
    {
        // throw new System.NotImplementedException();
    }

    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {
        for (int i = 0; i < senders.Length; i++) {
            messagesText.text = messagesText.text + "\n" + senders[i] + ":" + messages[i];
        }

        StartCoroutine(CoScrollToBottom());
    }

    IEnumerator CoScrollToBottom() {
        yield return new WaitForSeconds(.1f);
        messagesContainer.GetComponent<ScrollRect>().normalizedPosition = new Vector2(0, 0);
    }

    public void OnPrivateMessage(string sender, object message, string channelName)
    {
        // throw new System.NotImplementedException();
    }

    public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {
        // throw new System.NotImplementedException();
    }

    public void OnSubscribed(string[] channels, bool[] results)
    {
        messagesText.text += "Chat Online";
        chatClient.PublishMessage("global", "Joined");
    }

    public void OnUnsubscribed(string[] channels)
    {
        // throw new System.NotImplementedException();
    }

    public void OnUserSubscribed(string channel, string user)
    {
        // throw new System.NotImplementedException();
    }

    public void OnUserUnsubscribed(string channel, string user)
    {
        // throw new System.NotImplementedException();
    }

    void OnApplicationQuit() {
        if (chatClient != null) {
            chatClient.Disconnect();
        }
    }

    public void BackToInn() {
        SceneManager.LoadScene( "InnScene" );
    }

}
