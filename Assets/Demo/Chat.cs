#region Includes
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TS.ChatBubbles;
#endregion

namespace TS.Examples.ChatMessages
{
    public class Chat : MonoBehaviour
    {
        #region Variables

        [Header("References")]
        [SerializeField] private MessageContainer _container;
        [SerializeField] private InputField _inputField;

        public delegate void OnNewMessage(Chat sender, string message);
        public OnNewMessage NewMessage;

        #endregion

        private void Update()
        {
            if (EventSystem.current.currentSelectedGameObject == _inputField.gameObject &&
                Input.GetKeyUp(KeyCode.Return))
            {
                SendMessage();
            }
        }

        private void SendMessage()
        {
            string message = _inputField.text;

            if (string.IsNullOrEmpty(message)) { return; }

            _container.AddRight(message);

            _inputField.text = "";
            _inputField.ActivateInputField();

            NewMessage?.Invoke(this, message);
        }

        public void AddMessage(string text)
        {
            _container.AddLeft(text);
        }
        public void UI_Button_Click()
        {
            SendMessage();
        }
    }
}