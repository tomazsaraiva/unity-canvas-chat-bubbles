#region Includes
using UnityEngine;
using System.Collections;
using System;
#endregion

namespace TS.Examples.ChatMessages
{
    public class ChatBot : MonoBehaviour
    {
        #region Variables

        [Header("References")]
        [SerializeField] private Chat _chat;

        private string[] _messages = new string[]
        {
            "Who are you talking to right now? Who is it you think you see?",
            "Say my name.",
            "You're goddamn right."
        };

        private int _messageIndex = -1;
        private bool _success;

        #endregion

        private void Awake()
        {
            _chat.NewMessage = Chat_NewMessage;
        }

        private void Chat_NewMessage(Chat sender, string message)
        {
            if (_success) { return; }

            if (_messageIndex < 1)
            {
                _messageIndex++;
            }
            else if (string.Equals(message.ToLower(), "heisenberg", StringComparison.InvariantCultureIgnoreCase))
            {
                _messageIndex++;
                _success = true;
            }

            StartCoroutine(Reply_Coroutine(_messages[_messageIndex]));
        }
        private IEnumerator Reply_Coroutine(string message)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(0.1f, 0.3f));
            _chat.AddMessage(message, false);
        }
    }
}