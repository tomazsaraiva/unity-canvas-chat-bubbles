#region Includes
using System.Collections.Generic;

using TS.Examples.ChatMessages;

using UnityEditor.VersionControl;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using static TS.Examples.ChatMessages.Chat;
#endregion

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TS.ChatBubbles
{
    [RequireComponent(typeof(VerticalLayoutGroup))]
    public class MessageContainer : MonoBehaviour
    {
        #region Variables

        [Header("References")]
        [SerializeField] private MessageBubble _messageLeftPrefab;
        [SerializeField] private MessageBubble _messageRightPrefab;

        [Header("Configuration")]
        [SerializeField] private float _messageWidthPercent = 0.8f;

        private VerticalLayoutGroup _layout;

        private float _messageWidth;
        private List<MessageBubble> _messages;

        #endregion

        private void Awake()
        {
            _layout = GetComponent<VerticalLayoutGroup>();

            var width = ((RectTransform)_layout.transform).rect.width;
            _messageWidth = (width - _layout.padding.horizontal) * _messageWidthPercent;
        }

        public void AddLeft(string text)
        {
            Add(_messageLeftPrefab, text);
        }
        public void AddRight(string text)
        {
            Add(_messageRightPrefab, text);
        }
        public void Clear()
        {
            for (int i = 0; i < _messages.Count; i++)
            {
                Destroy(_messages[i].gameObject);
            }

            _messages.Clear();
        }

        private void Add(MessageBubble prefab, string text)
        {
            var instance = Instantiate(prefab, Vector3.zero, Quaternion.identity, _layout.transform);
            instance.Text = text;
            instance.MaxWidth = _messageWidth;

            _messages ??= new List<MessageBubble>();
            _messages.Add(instance);
        }

#if UNITY_EDITOR
        [CustomEditor(typeof(MessageContainer))]
        public class MessageContainerEditor : Editor
        {
            #region Variables

            private MessageContainer _target;
            private string _text;

            #endregion

            private void OnEnable()
            {
                _target = (MessageContainer)target;
            }
            public override void OnInspectorGUI()
            {
                base.OnInspectorGUI();

                EditorGUILayout.Space();
                EditorGUILayout.LabelField("Editor");

                _text = EditorGUILayout.TextField(_text);
                GUILayout.BeginHorizontal();
                if(GUILayout.Button("Add Left"))
                {
                    _target.AddLeft(_text);
                }
                if(GUILayout.Button("Add Right"))
                {
                    _target.AddRight(_text);
                }
                GUILayout.EndHorizontal();
            }
        }
#endif
    }
}