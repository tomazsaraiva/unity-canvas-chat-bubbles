#region Includes
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace TS.ChatBubbles
{
    public class MessageBubble : MonoBehaviour
    {
        #region Variables

        [Header("References")]
        [SerializeField] private Text _label;
        [SerializeField] private Image _image;
        
        public string Text
        {
            get { return _label.text; }
            set { _label.text = value; }
        }
        public Sprite Image
        {
            get { return _image.sprite; }
            set { _image.sprite = value; }
        }
        public float MaxWidth
        {
            get { return _layoutElement.preferredWidth; }
            set { _layoutElement.preferredWidth = value; }
        }

        private LayoutElement _layoutElement;

        #endregion

        private void Awake()
        {
            _layoutElement = GetComponent<LayoutElement>();
        }
    }
}