using System.Threading.Tasks;
using DG.Tweening;
using KaedeAsset.KaedeScript.View;
using UniRx;

using UnityEngine;
// using KaedeAsset.Serena.Scripts.View.PBattle.Presenter;
using ChoiceCommand = KaedeAsset.KaedeScript.VitalRouter.KaedeScript.ChoiceCommand;

namespace KaedeAsset.KaedeScript.Presenter
{
    public class NobelPresenter
    {
        // MonoBehaviourを継承、インスペクターから設定する
        // Inherits from MonoBehaviour, set from the inspector
        public readonly NovelView NovelView;
        // public AnimatorControllerExample ace;
        public readonly ImageFader ImageFader;
        public readonly SpriteHandler SpriteHandler;
        public readonly ChoiceView ChoiceView;
        
        // Button click events
        // ボタンクリックイベント
        public readonly Subject<Unit> OnClickButtonClicked = new Subject<Unit>();
        public readonly Subject<Unit> OnBrakeButtonClicked = new Subject<Unit>();
        public readonly Subject<Unit> OnLoadButtonClicked = new Subject<Unit>();
        
        private TaskCompletionSource<int> _tcs;

        // Constructor
        // コンストラクタ
        public NobelPresenter(SpriteHandler spriteHandler, NovelView novelView, 
            ImageFader imageFader, ChoiceView choiceView)
        {
            Debug.Log("NobelPresenter コンストラクタ");
            NovelView = novelView;
            ImageFader = imageFader;
            SpriteHandler = spriteHandler;
            ChoiceView = choiceView;
            Initialization();
        }
        
        // Initialization method
        // 初期化メソッド
        void Initialization()
        {
            Debug.Log("NobelPresenter Initialization");
            if (NovelView == null)
            {
                Debug.Log("_novelView is null");
            }
            
            // Subscribe to button click events
            // ボタンクリックイベントにサブスクライブ
            NovelView.buttonClick.onClick.AsObservable()
                .Subscribe(_ => OnClickButtonClicked.OnNext(Unit.Default));
            
            NovelView.buttonBrake.onClick.AsObservable()
                .Subscribe(_ => OnBrakeButtonClicked.OnNext(Unit.Default));
            
            NovelView.buttonLoad.onClick.AsObservable()
                .Subscribe(_ => OnLoadButtonClicked.OnNext(Unit.Default));
            
            // Add listeners for choice buttons
            // 選択肢ボタンにリスナーを追加
            ChoiceView.choice1.onClick.AddListener(() =>
            {
                Debug.Log("ChoiceView.choice1.onClick");    
                OnChoiceSelected(1);
            });
            ChoiceView.choice2.onClick.AddListener(() =>
            {
                Debug.Log("ChoiceView.choice2.onClick");    
                OnChoiceSelected(2);
            });
            ChoiceView.choice3.onClick.AddListener(() =>
            {
                Debug.Log("ChoiceView.choice3.onClick");    
                OnChoiceSelected(3);
            });
            
            // Initialize DOTween
            // DOTweenを初期化
            DOTween.Init();
        }
        
        // Show choices asynchronously
        // 選択肢を非同期で表示
        public async Task<int> ShowChoicesAsync(ChoiceCommand cmd)
        {
            Debug.Log("ShowChoicesAsync");
            _tcs = new TaskCompletionSource<int>();

            // Display choice panel and set texts
            // 選択肢パネルを表示し、テキストを設定
            ChoiceView.choicePanel.SetActive(true);
            ChoiceView.choice1Text.text = cmd.Choice1;
            ChoiceView.choice2Text.text = cmd.Choice2;
            ChoiceView.choice3Text.text = cmd.Choice3;

            int result = await _tcs.Task;
            ChoiceView.choicePanel.SetActive(false);
            
            Debug.Log($"ShowChoicesAsync-2 {result}");
            return result;
        }

        // Handle choice selection
        // 選択肢の選択を処理
        private void OnChoiceSelected(int choice)
        {
            Debug.Log($"OnChoiceSelected {choice}");
            _tcs.TrySetResult(choice);
        }
        
        // Show click button
        // クリックボタンを表示
        public void ShowClick()
        {
            NovelView.buttonClick.gameObject.SetActive(true);
        }
        
        // Hide click button
        // クリックボタンを非表示
        public void HideClick()
        {
            NovelView.buttonClick.gameObject.SetActive(false);
        }

        // Set message text
        // メッセージテキストを設定
        public void SetMessage(string s)
        {
            NovelView.msg.text = s;
        }

        // Set name text
        // 名前テキストを設定
        public void SetName(string s)
        {
            NovelView.name.text = s;
        }
        
        // Play background music
        // BGMを再生
        public void PlayBGM()
        {
            Debug.Log("PlayBGM");
            NovelView.audioPlayer.PlayBGM();
        }
        
        // Play audio from file
        // ファイルからオーディオを再生
        public void PlayAudio(string filePath)
        {
            Debug.Log("PlayAudio");
            NovelView.audioPlayer.PlayAudio(filePath);
            Debug.Log("PlayAudio-2");
        }
    }
}