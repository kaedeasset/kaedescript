using VitalRouter;
using VitalRouter.MRuby;

namespace KaedeAsset.KaedeScript.VitalRouter.KaedeScript
{
    // Define your custom command name and type list here
    // カスタムコマンド名とタイプのリストをここに定義します

    // Test commands
    // テストコマンド
    [MRubyCommand("move", typeof(CharacterMoveCommand))] 
    [MRubyCommand("moveone", typeof(MoveOneCommand))] 
    
    // Image commands
    // 画像コマンド
    [MRubyCommand("img", typeof(ImgCommand))] 
    [MRubyCommand("imgPath", typeof(ImgPathCommand))] 
    [MRubyCommand("bgImg", typeof(BgImgCommand))] 
    [MRubyCommand("bgImgPath", typeof(BgImgPathCommand))] 
    
    // Text commands
    // テキストコマンド
    [MRubyCommand("msg", typeof(MsgCommand))] 
    [MRubyCommand("clr", typeof(ClrCommand))] 
    
    // Sound commands
    // サウンドコマンド
    [MRubyCommand("pa", typeof(PaCommand))]  // PlayAudio
    [MRubyCommand("delay", typeof(DelayCommand))]  // Delay
    
    // Choice command
    // 選択コマンド
    [MRubyCommand("choice", typeof(ChoiceCommand))]
    
    // Class definition for command presets
    // コマンドプリセットのクラス定義
    partial class KsCommandPreset : MRubyCommandPreset
    {
        // This class can be extended with additional functionality if needed
        // 必要に応じて追加の機能で拡張できます
    }
    
    // Custom command declarations
    // カスタムコマンドの宣言
    
    // Command for moving a character
    // キャラクターを移動させるコマンド
    [MRubyObject]
    public partial struct CharacterMoveCommand : ICommand
    {
        public string Id; // Character identifier
        // キャラクターの識別子
        public int To; // Destination position
        // 目的地の位置
    }
    
    // Command for moving a single character
    // 単一のキャラクターを移動させるコマンド
    [MRubyObject]
    public partial struct MoveOneCommand : ICommand
    {
        public string Id; // Character identifier
        // キャラクターの識別子
    }
    
    // Image-related commands
    // 画像関連のコマンド
    
    // Command to display an image
    // 画像を表示するコマンド
    [MRubyObject]
    public partial struct ImgCommand : ICommand
    {
        public string FileName; // Image file name
        // 画像ファイル名
    }
    
    // Command to specify an image path
    // 画像パスを指定するコマンド
    [MRubyObject]
    public partial struct ImgPathCommand : ICommand
    {
        public string Path; // Image path
        // 画像パス
    }
    
    // Command to display a background image
    // 背景画像を表示するコマンド
    [MRubyObject]
    public partial struct BgImgCommand : ICommand
    {
        public string FileName; // Background image file name
        // 背景画像ファイル名
    }
    
    // Command to specify a background image path
    // 背景画像パスを指定するコマンド
    [MRubyObject]
    public partial struct BgImgPathCommand : ICommand
    {
        public string Path; // Background image path
        // 背景画像パス
    }
    
    // Text-related commands
    // テキスト関連のコマンド
    
    // Command to display a message
    // メッセージを表示するコマンド
    [MRubyObject]
    public partial struct MsgCommand : ICommand
    {
        public string Msg; // Message content
        // メッセージ内容
        public string Arg1; // Additional argument
        // 追加の引数
    }
    
    // Command to clear text
    // テキストをクリアするコマンド
    [MRubyObject]
    public partial struct ClrCommand : ICommand
    {
        public string Msg; // Message to clear
        // クリアするメッセージ
    }
    
    // Sound-related commands
    // サウンド関連のコマンド
    
    // Command to play audio
    // オーディオを再生するコマンド
    [MRubyObject]
    public partial struct PaCommand : ICommand
    {
        public string FileName; // Audio file name
        // オーディオファイル名
    }
    
    // Command to introduce a delay
    // 遅延を導入するコマンド
    [MRubyObject]
    public partial struct DelayCommand : ICommand
    {
        public int MSec; // Delay in milliseconds
        // ミリ秒単位の遅延
    }
    
    // Command for making a choice
    // 選択を行うコマンド
    [MRubyObject]
    public partial struct ChoiceCommand : ICommand
    {
        public string Choice1; // First choice
        // 第一の選択肢
        public string Choice2; // Second choice
        // 第二の選択肢
        public string Choice3; // Third choice
        // 第三の選択肢
    }
}