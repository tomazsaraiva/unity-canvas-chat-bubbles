#region Includes
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
#endregion

namespace TS.Examples.ChatMessages
{
    public class Chat : MonoBehaviour
    {
        #region Variables

        [Header("References")]
        [SerializeField] private VerticalLayoutGroup _layout;
        [SerializeField] private InputField _inputField;
        [SerializeField] private ChatMessageItem _playerMessagePrefab;
        [SerializeField] private ChatMessageItem _otherMessagePrefab;

        [Header("Configuration")]
        [SerializeField] private float _messageWidthPercent;

        public delegate void OnNewMessage(Chat sender, string message);
        public OnNewMessage NewMessage;

        private float _messageWidth;

        #endregion

        private void Awake()
        {
            var width = ((RectTransform)_layout.transform).rect.width;
            _messageWidth = (width - _layout.padding.horizontal) * _messageWidthPercent;
        }
        private void Update()
        {
            if (EventSystem.current.currentSelectedGameObject == _inputField.gameObject &&
                Input.GetKeyUp(KeyCode.Return))
            {
                SendMessage();
            }
        }

        public void AddMessage(string message, bool playerMessage)
        {
            var prefab = playerMessage ? _playerMessagePrefab : _otherMessagePrefab;

            var instance = Instantiate(prefab, Vector3.zero, Quaternion.identity, _layout.transform);
            instance.Text = message;
            instance.MaxWidth = _messageWidth;
        }

        private void SendMessage()
        {
            string message = _inputField.text;

            if (string.IsNullOrEmpty(message)) { return; }

            AddMessage(message, true);

            _inputField.text = "";
            _inputField.ActivateInputField();

            NewMessage?.Invoke(this, message);
        }

        public void UI_Button_Click()
        {
            SendMessage();
        }
    }
}