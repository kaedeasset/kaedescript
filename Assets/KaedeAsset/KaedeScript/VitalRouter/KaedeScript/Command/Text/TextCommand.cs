using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using KaedeAsset.KaedeScript.Presenter;
using UniRx;
using UnityEngine;

namespace KaedeAsset.KaedeScript.VitalRouter.KaedeScript.Command.Text
{
    public class TextCommand
    {
        private readonly NobelPresenter _nobelPresenter;
        private IDisposable _subscription;
    
        private bool _isContinueButtonClicked = false;
        private string _txt = "";
        private readonly int _dmsec = 70;
        private int _delayTime = 50; // Default text display delay in milliseconds / 通常時の文字表示ディレイ(ms)

        public TextCommand(NobelPresenter presenter)
        {
            _nobelPresenter = presenter;
            _delayTime = _dmsec;
        }

        /// <summary>
        /// Called when the user clicks the button to fast-forward the text (reduce delay).
        /// ユーザーがボタンをクリックした際に呼ばれ、テキストを早送り(ディレイ短縮)する
        /// </summary>
        private void OnButtonClicked()
        {
            // Set to fast-forward delay time / 早送り用のディレイ時間に設定
            _delayTime = 1;
            _subscription?.Dispose();
        }

        /// <summary>
        /// Method to display text one character at a time.
        /// テキストを一文字ずつ表示するメソッド
        /// </summary>
        private async UniTask AddMessage(string message)
        {
            // Debug.Log($"AddMessage {message}");

            // Unsubscribe from previous subscription and subscribe anew / 前の購読を解除してから新たに購読
            _subscription?.Dispose();
            _subscription = _nobelPresenter.OnClickButtonClicked.Subscribe(_ => OnButtonClicked());

            var currentText = _txt;

            // Display one character at a time / 一文字ずつ表示
            for (int i = 0; i < message.Length; i++)
            {
                await Task.Delay(_delayTime);
                currentText += message[i];
                _nobelPresenter.SetMessage(currentText);
            }

            // Update the final text / 最終的なテキストを更新
            _txt = currentText;

            // Unsubscribe / 購読解除
            _subscription?.Dispose();

            // Return to normal speed after display / 表示終了後は通常速度に戻す
            _delayTime = _dmsec;
            
            Debug.Log($"AddMessage-2");
        }

        /// <summary>
        /// Wait until the user clicks.
        /// ユーザーがクリックするまで待機
        /// </summary>
        private async UniTask ClickWait()
        {
            _isContinueButtonClicked = false;
            using (var subscription = _nobelPresenter.OnClickButtonClicked.Subscribe(_ => _isContinueButtonClicked = true))
            {
                _nobelPresenter.ShowClick();
                await UniTask.WaitUntil(() => _isContinueButtonClicked);
                _nobelPresenter.HideClick();
            }
        }

        /// <summary>
        /// Clear the message.
        /// メッセージをクリア
        /// </summary>
        private void ClearMessage()
        {
            Debug.Log($"ClearMessage");
            _txt = "";
            _nobelPresenter.SetMessage(_txt);
        }

        /// <summary>
        /// Split the line by "@" and display the first part (mainMessage) as a message.
        /// line を "@" で分割し、先頭部分(mainMessage)をメッセージとして表示
        /// </summary>
        private async UniTask AddMessageLocal(string line)
        {
            _nobelPresenter.HideClick();
            var args = line.Split('@');
            var mainMessage = args[0];
            await AddMessage(mainMessage);
        }

        /// <summary>
        /// Parse and process command arguments.
        /// コマンド引数を解析して処理
        /// </summary>
        private async UniTask ProcessCommand(string arg)
        {
            switch (arg)
            {
                case "l":
                    await ClickWait();
                    break;
                case "r":
                    _txt += '\n';
                    _nobelPresenter.SetMessage(_txt);
                    break;
                case "lr":
                    _txt += '\n';
                    _nobelPresenter.SetMessage(_txt);
                    await ClickWait();
                    break;
                case "cm":
                    ClearMessage();
                    break;
                case "lcm":
                    await ClickWait();
                    ClearMessage();
                    break;
                default:
                    Debug.LogError($"Error Unknown command: {arg}");
                    break;
            }
        }

        /// <summary>
        /// Process the Msg command.
        /// Msgコマンドを処理
        /// </summary>
        public async UniTask Msg(MsgCommand cmd)
        {
            // Debug.Log($"TextCommand Msg {cmd.Msg} {cmd.Arg1}");
            await AddMessageLocal(cmd.Msg);

            if (!string.IsNullOrEmpty(cmd.Arg1))
            {
                await ProcessCommand(cmd.Arg1);
            }
        }
    
        /// <summary>
        /// Process the Clr command to clear the message.
        /// Clrコマンドを処理してメッセージをクリア
        /// </summary>
        public void Clr(ClrCommand cmd)
        {
            Debug.Log($"TextCommand Clr {cmd.Msg}");
            ClearMessage();
        }
    }
}