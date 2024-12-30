using Cysharp.Threading.Tasks;
using KaedeAsset.KaedeScript.VitalRouter.KaedeScript.Command;
using UnityEngine;
using VitalRouter;

namespace KaedeAsset.KaedeScript.VitalRouter.KaedeScript
{
    [Routes] // < If routing as a MonoBehaviour
    public partial class KsPresentor
    {
        private KsCommand _ksCommand;

        // Constructor to initialize KsCommand
        // KsCommandを初期化するためのコンストラクタ
        public KsPresentor(KsCommand ksCommand)
        {
            _ksCommand = ksCommand;
        }

        // Handles CharacterMoveCommand
        // CharacterMoveCommandを処理する
        public void On(CharacterMoveCommand cmd)
        {
            Debug.Log($"★KsPresentor CharacterMoveCommand On {cmd.Id} {cmd.To} ---");
            // Do something ...
            // 何かをする...
        }
        
        // Handles MoveOneCommand
        // MoveOneCommandを処理する
        public void On(MoveOneCommand cmd)
        {
            Debug.Log($"★KsPresentor MoveOneCommand On {cmd.Id} ---");
            // _ksCommand.Pa(cmd.Id);
            // Do something ...
            // 何かをする...
        }
        
        // Handles ImgCommand
        // ImgCommandを処理する
        public void On(ImgCommand cmd)
        {
            Debug.Log($"★KsPresentor ImgCommand On {cmd.FileName} ---");
            _ksCommand.Img(cmd);
            // Do something ...
            // 何かをする...
        }
        
        // Handles ImgPathCommand
        // ImgPathCommandを処理する
        public void On(ImgPathCommand cmd)
        {
            Debug.Log($"★KsPresentor ImgPathCommand On {cmd.Path} ---");
            _ksCommand.ImgPath(cmd);
        }
        
        // Handles BgImgCommand
        // BgImgCommandを処理する
        public void On(BgImgCommand cmd)
        {
            Debug.Log($"★KsPresentor BgImgCommand On {cmd.FileName} ---");
            _ksCommand.BgImg(cmd);
        }
        
        // Handles BgImgPathCommand
        // BgImgPathCommandを処理する
        public void On(BgImgPathCommand cmd)
        {
            Debug.Log($"★KsPresentor BgImgPathCommand On {cmd.Path} ---");
            _ksCommand.BgImgPath(cmd);
        }
        
        // Handles MsgCommand asynchronously
        // MsgCommandを非同期で処理する
        public async UniTask On(MsgCommand cmd)
        {
            Debug.Log($"★KsPresentor MsgCommand On {cmd.Msg} {cmd.Arg1} ---");
            await _ksCommand.Msg(cmd);
            Debug.Log($"★KsPresentor MsgCommand On -2");
        }
        
        // Handles ClrCommand
        // ClrCommandを処理する
        public void On(ClrCommand cmd)
        {
            Debug.Log($"★KsPresentor ClrCommand On {cmd.Msg} ---");
            _ksCommand.Clr(cmd);
            Debug.Log($"★KsPresentor ClrCommand On -2");
        }
        
        // Handles PaCommand
        // PaCommandを処理する
        public void On(PaCommand cmd)
        {
            Debug.Log($"★KsPresentor PaCommand On {cmd.FileName} ---");
            _ksCommand.Pa(cmd);
            Debug.Log($"★KsPresentor PaCommand On -2");
        }
        
        // Handles DelayCommand asynchronously
        // DelayCommandを非同期で処理する
        public async UniTask On(DelayCommand cmd)
        {
            Debug.Log($"★KsPresentor DelayCommand On {cmd.MSec} ---");
            await _ksCommand.Delay(cmd);
            Debug.Log($"★KsPresentor DelayCommand On -2");
        }
        
        // Handles ChoiceCommand asynchronously
        // ChoiceCommandを非同期で処理する
        public async UniTask On(ChoiceCommand cmd)
        {
            Debug.Log($"★KsPresentor ChoiceCommand On {cmd.Choice1} {cmd.Choice2} {cmd.Choice3} ---");
            await _ksCommand.Choice(cmd);
            Debug.Log($"★KsPresentor ChoiceCommand On -2");
        }
    }
}