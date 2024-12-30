using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace KaedeAsset.KaedeScript.View
{
    public class NovelView : MonoBehaviour
    {
        // UI elements for displaying messages and names
        // メッセージと名前を表示するためのUI要素
        public Text msg;
        public Text name;
        
        // Buttons for various actions
        // 各種アクションのためのボタン
        public Button buttonBattle;
        public Button buttonClick;
        public Button buttonBrake;
        public Button buttonLoad;
        //xx public Button buttonTitle;
        // public Button buttonInteractive;
        
        // Image elements for displaying graphics
        // グラフィックを表示するための画像要素
        public Image img;
        //xx public Image bgImg1, bgImg2;
        public Image item;
        //xx public Image imageInOut;
        
        // Inventory object set in the Unity Editor
        // Unityエディタで設定されたインベントリオブジェクト
        public GameObject inventory;
        
        // Two images needed for crossfade effects
        // クロスフェード効果に必要な2つの画像
        public Image[] img1; 
        public Image[] bgImg; 
        
        // Two sprite renderers needed for crossfade effects
        // クロスフェード効果に必要な2つのスプライトレンダラー
        //xx [FormerlySerializedAs("chSR1")] public SpriteRenderer[] chSr1; 
        //xx [FormerlySerializedAs("bgSR")] public SpriteRenderer[] bgSr; 
        
        // Choice buttons set in the Unity Editor
        // Unityエディタで設定された選択ボタン
        public Button[] choiceButtons; // 3個のButtonをUnity Editor上で設定
        // public Image[] gridImages; // 9個のImageをUnity Editor上で設定
        // public ItemView[] itemViews; // 16個のImageをUnity Editor上で設定
        public Button[] listsButtons; // 12個のImageをUnity Editor上で設定
        
        // Objects for display control
        // 表示制御用のオブジェクト
        public GameObject[] objs;
        
        // Images for animation
        // アニメーション用の画像
        public Image[] images;
        
        // Sprite renderers for animation
        // アニメーション用のスプライトレンダラー
        public SpriteRenderer[] srs;

        // Game objects and sprite renderers for characters and backgrounds
        // キャラクターと背景用のゲームオブジェクトとスプライトレンダラー
        public GameObject objCharacter;
        public GameObject objBg;
        public SpriteRenderer srCharacter;
      
        // Audio player for handling audio
        // オーディオを扱うためのオーディオプレーヤー
        public AudioPlayer audioPlayer;
        
        // Called before the first frame update
        // 最初のフレーム更新の前に呼び出される
        private void Awake()
        {
            // Debug.Log("NovelView Awake-1");
            /***
            if (objCharacter != null && objBg != null)
            {
                srCharacter = objCharacter.GetComponent<SpriteRenderer>();
            }
            ***/

            // Debug.Log("NovelView Awake-2");
        }
    }
}