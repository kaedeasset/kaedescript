
using UnityEngine;

namespace KaedeAsset.KaedeScript.VitalRouter.KaedeScript.Command
{
    // Methods related to image handling / 画像処理に関連するメソッドを置く
    public partial class KsCommand
    {
        // Load and switch to a new image / 新しい画像を読み込み、切り替える
        public void Img(ImgCommand cmd)
        {
            var path = _imgPash + "/" + cmd.FileName;
            // Debug.Log("path=" + path); // Uncomment for debugging / デバッグ用にコメントを解除
            var sprite = Resources.Load<Sprite>(path);
            if (sprite == null)
            {
                Debug.LogError($"Img ファイルがありません{path}");
                _nobelPresenter.ImageFader.SwitchToNewImage(_nobelPresenter.NovelView.img1, sprite, 1);
            }
            else
            {
                _nobelPresenter.ImageFader.SwitchToNewImage(_nobelPresenter.NovelView.img1, sprite, 1);
            }
        }
        
        // Set the image path / 画像のパスを設定する
        public void ImgPath(ImgPathCommand cmd)
        {
            _imgPash = cmd.Path;
        }
        
        // Load and switch to a new background image / 新しい背景画像を読み込み、切り替える
        public void BgImg(BgImgCommand cmd)
        {
            var path = _bgImgPash + "/" + cmd.FileName;
            // Debug.Log("path=" + path); // Uncomment for debugging / デバッグ用にコメントを解除
            var sprite = Resources.Load<Sprite>(path);
            if (sprite == null)
            {
                Debug.LogError($"BgImg ファイルがありません{path}");
                _nobelPresenter.ImageFader.SwitchToNewImage(_nobelPresenter.NovelView.bgImg, sprite, 1);
            }
            else
            {
                _nobelPresenter.ImageFader.SwitchToNewImage(_nobelPresenter.NovelView.bgImg, sprite, 1);
            }
        }
        
        // Set the background image path / 背景画像のパスを設定する
        public void BgImgPath(BgImgPathCommand cmd)
        {
            _bgImgPash = cmd.Path;
        }
    }
}