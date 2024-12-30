using KaedeAsset.KaedeScript.Presenter;
using KaedeAsset.KaedeScript.VitalRouter.KaedeScript.Command.Text;
using VitalRouter.MRuby;

namespace KaedeAsset.KaedeScript.VitalRouter.KaedeScript.Command
{
    public partial class KsCommand
    {
        // You can add common methods and variables here
        // 共通のメソッドや変数をここに追加できます
        private readonly NobelPresenter _nobelPresenter;
        
        MRubyContext _context;
        private string _bgImgPash = ""; // Background image path 背景画像のパス
        private string _imgPash = "";   // Image path 画像のパス
        private readonly TextCommand _textCommand;

        // Constructor to initialize the KsCommand with a NobelPresenter
        // NobelPresenterを使用してKsCommandを初期化するコンストラクタ
        public KsCommand(NobelPresenter presenter)
        {
            _nobelPresenter = presenter;
            _textCommand = new TextCommand(_nobelPresenter);
        }
        
        // Method to set the MRuby context
        // MRubyコンテキストを設定するメソッド
        public void SetContext(MRubyContext context)
        {
            _context = context;
        }
    }
}