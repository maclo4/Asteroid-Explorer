using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class FirstConversation : MonoBehaviour
{
    public NPCConversation conversation;
    public void OnTriggerEnter2D(Collider2D other)
    {
        ConversationManager.Instance.StartConversation(conversation);
    }
}
