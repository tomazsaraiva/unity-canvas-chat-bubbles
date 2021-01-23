#region Includes
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace TS.Examples.ChatMessages
{
    public class ChatMessageItem : MonoBehaviour
    {
        #region Variables

        [Header("References")]
        [SerializeField] private Text _labelMessage;
        [SerializeField] private LayoutElement _layoutElement;

        public string Text
        {
            get { return _labelMessage.text; }
            set { _labelMessage.text = value; }
        }
        public float MaxWidth
        {
            get { return _layoutElement.preferredWidth; }
            set { _layoutElement.preferredWidth = value; }
        }

        #endregion
    }
}