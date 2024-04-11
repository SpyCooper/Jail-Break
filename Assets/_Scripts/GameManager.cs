using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public string username;
    public static int maxMessages = 25;

    [SerializeField] GameObject chatPanel;
    [SerializeField] GameObject textObject;
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
    }

    private void Update()
    {
        if(chatBox.text != "")
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                SendMessageToChat(username + ": " + chatBox.text, MessageType.playerMessage);
                chatBox.text = "";

                chatBox.ActivateInputField();
            }
        }
        else
        {
            if(!chatBox.isFocused && Input.GetKeyDown(KeyCode.Return))
            {
                chatBox.ActivateInputField();
            }
        }

        if(!chatBox.isFocused)
        {
            if(Input.GetKeyDown(KeyCode.Space)) 
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
        GameObject newText = Instantiate(textObject, chatPanel.transform);
        newMessage.textObject = newText.GetComponent<TextMeshProUGUI>();

        newMessage.textObject.text = text;
        newMessage.textObject.color = MessageTypeColor(messageType);

        messageList.Add(newMessage);
    }

    private Color MessageTypeColor(MessageType type)
    {
        Color color = infoMessageColor;

        switch(type)
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