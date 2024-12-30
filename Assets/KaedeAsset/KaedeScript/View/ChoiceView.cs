using UnityEngine;
using UnityEngine.UI;

namespace KaedeAsset.KaedeScript.View
{
    // This class represents the view for displaying choices in the UI.
    // このクラスはUIに選択肢を表示するビューを表します。
    public class ChoiceView : MonoBehaviour
    {
        // Panel that contains the choice buttons.
        // 選択肢ボタンを含むパネル。
        public GameObject choicePanel;

        // Button for the first choice.
        // 最初の選択肢のボタン。
        public Button choice1;

        // Button for the second choice.
        // 2番目の選択肢のボタン。
        public Button choice2;

        // Button for the third choice.
        // 3番目の選択肢のボタン。
        public Button choice3;

        // Text for the first choice button.
        // 最初の選択肢ボタンのテキスト。
        public Text choice1Text;

        // Text for the second choice button.
        // 2番目の選択肢ボタンのテキスト。
        public Text choice2Text;

        // Text for the third choice button.
        // 3番目の選択肢ボタンのテキスト。
        public Text choice3Text;
    }
}