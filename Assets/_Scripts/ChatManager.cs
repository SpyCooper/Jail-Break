using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChatManager : MonoBehaviour
{
    public static ChatManager Instance {  get; private set; }

    private string playerName;
    public static int maxMessages = 25;

    [SerializeField] GameObject chatPanel;
    [SerializeField] GameObject textObject;
    [SerializeField] GameObject playerTextPrefab;
    [SerializeField] GameObject enemyTextPrefab;
    [SerializeField] GameObject infoTextPrefab;
    [SerializeField] TMP_InputField chatBox;

    [SerializeField] Color playerMessageColor;
    [SerializeField] Color infoMessageColor;
    [SerializeField] Color enemyMessageColor;

    [SerializeField] List<Message> messageList = new List<Message>();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        chatBox.text = "";
        playerName = GameManager.Instance.GetPlayerName();
    }

    private void Update()
    {
        if (chatBox.text != "")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SendMessageToChat(playerName + ": " + chatBox.text, MessageType.playerMessage);
                chatBox.text = "";

                SendMessageToChat("Police: testing", MessageType.enemyMessage);

                chatBox.ActivateInputField();
            }
        }
        else
        {
            if (!chatBox.isFocused && Input.GetKeyDown(KeyCode.Return))
            {
                chatBox.ActivateInputField();
            }
        }

        if (!chatBox.isFocused)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SendMessageToChat("You pressed the space bar!", MessageType.info);
                Debug.Log("space");
            }
        }
    }


    public void SendMessageToChat(string text, MessageType messageType)
    {
        if (messageList.Count >= maxMessages)
        {
            Destroy(messageList[0].textObject.gameObject);
            messageList.Remove(messageList[0]);
        }
        Message newMessage = new Message();
        newMessage.text = text;
        newMessage.type = messageType;
        GameObject chatType = MessageTypePrefab(messageType);
        GameObject newText = Instantiate(chatType, chatPanel.transform);
        newMessage.textObject = newText.GetComponent<TextMeshProUGUI>();

        newMessage.textObject.text = text;
        newMessage.textObject.color = MessageTypeColor(messageType);

        messageList.Add(newMessage);
    }

    private Color MessageTypeColor(MessageType type)
    {
        Color color = infoMessageColor;

        switch (type)
        {
            case MessageType.info:
                color = infoMessageColor;
                break;
            case MessageType.playerMessage:
                color = playerMessageColor;
                break;
            case MessageType.enemyMessage:
                color = enemyMessageColor;
                break;
        }

        return color;
    }

    private GameObject MessageTypePrefab(MessageType type)
    {
        GameObject gameObject = textObject;

        switch (type)
        {
            case MessageType.info:
                gameObject = infoTextPrefab;
                break;
            case MessageType.playerMessage:
                gameObject = playerTextPrefab;
                break;
            case MessageType.enemyMessage:
                gameObject = enemyTextPrefab;
                break;
        }

        return gameObject;
    }
}

[System.Serializable]
public class Message
{
    public string text;
    public TextMeshProUGUI textObject;
    public MessageType type;
}

public enum MessageType
{
    playerMessage,
    info,
    enemyMessage
}