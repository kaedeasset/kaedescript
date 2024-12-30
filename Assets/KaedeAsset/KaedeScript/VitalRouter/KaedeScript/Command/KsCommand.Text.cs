using Cysharp.Threading.Tasks;

using UnityEngine;

namespace KaedeAsset.KaedeScript.VitalRouter.KaedeScript.Command
{
    public partial class KsCommand
    {
        // Asynchronously processes a message command.
        // メッセージコマンドを非同期で処理します。
        public async UniTask Msg(MsgCommand cmd)
        {
            // Debug.Log($"KsCommand Msg {cmd.Msg} {cmd.Arg1}");
            await _textCommand.Msg(cmd);
        }
        
        // Clears the current command.
        // 現在のコマンドをクリアします。
        public void Clr(ClrCommand cmd)
        {
            Debug.Log($"KsCommand Clr {cmd.Msg}");
            _textCommand.Clr(cmd);
        }
        
        // Asynchronously presents choices and saves the selected choice to shared state.
        // 選択肢を非同期で表示し、選択された結果を共有状態に保存します。
        public async UniTask Choice(ChoiceCommand cmd)
        {
            Debug.Log($"KsCommand Choice {cmd.Choice1} {cmd.Choice2} {cmd.Choice3} ---");
            int selectedChoice = await _nobelPresenter.ShowChoicesAsync(cmd);
            
            // Save the selected choice result to SharedState
            // 選択結果をSharedStateに保存
            Debug.Log($"KsCommand Choice-2");
            _context.SharedState.Set("selected_choice", selectedChoice);
            Debug.Log($"KsCommand Choice-3");
            
            // Uncomment the following lines to retrieve and log the selected choice
            // 以下の行をコメント解除して、選択された選択肢を取得してログに出力します。
            // var get_selected_choice = _context.SharedState.Get<string>("selected_choice");
            // Debug.Log($"get_selected_choice {get_selected_choice}");
            
            Debug.Log($"KsCommand Choice-4");
            Debug.Log($"KsCommand Choice-5");
        }
    }
}