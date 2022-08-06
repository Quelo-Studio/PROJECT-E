using UnityEngine;
using UnityEngine.UI;

namespace ArcaneNebula
{
    public class SelectCell : MonoBehaviour
    {
        public static SelectCell SelectedCell => s_SelectedCell;
        private static SelectCell s_SelectedCell;

        public bool Selected { get; private set; }

        [SerializeField] private Image m_Image;

        private CellData m_CellData;

        private LevelEditor m_LevelEditor;

        private void Awake()
        {
            m_Image.color = Color.gray;
            m_LevelEditor = LevelEditor.Instance;
        }

        public void Set(CellData cellData)
        {
            m_CellData = cellData;
            m_Image.sprite = cellData.Sprite;
            m_LevelEditor.SelectedTile = m_CellData.Index;
        }

        public void Select()
        {
            if (s_SelectedCell)
                s_SelectedCell.Deselect();

            m_Image.color = Color.white;
            m_LevelEditor.SelectedTile = m_CellData.Index;
            s_SelectedCell = this;
            Selected = true;
        }

        public void Deselect()
        {
            m_Image.color = Color.gray;
            Selected = false;
        }
    }
}
