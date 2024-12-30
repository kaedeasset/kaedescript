using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace KaedeAsset.KaedeScript.View
{
    public class ImageFader : MonoBehaviour
    {
        [Inject]
        private SpriteHandler _spriteHandler;
        
        private void Awake()
        {
            // Awake method is called when the script instance is being loaded.
            // スクリプトインスタンスがロードされるときに呼び出されるAwakeメソッド。
            // Debug.Log($"ImageFader Awake _spriteHandler={_spriteHandler}");
        }
        
        /// <summary>
        /// Switches to a new image with a fade transition.
        /// フェードトランジションで新しい画像に切り替えます。
        /// </summary>
        /// <param name="images">Array of Image components. Must contain exactly two elements.</param>
        /// <param name="newSprite">The new sprite to switch to.</param>
        /// <param name="fadeDuration">Duration of the fade transition.</param>
        public void SwitchToNewImage(Image[] images, Sprite newSprite, float fadeDuration)
        {
            // Debug.Log("SwitchToNewImage");
            if (images.Length != 2)
            {
                return;
            }
            // Cancel ongoing fade animations
            // 進行中のフェードアニメーションをキャンセル
            images[0].DOKill();
            images[1].DOKill();
            
            // Set the new sprite to images[1]
            // images[1]に新しいSpriteを設定
            images[1].sprite = newSprite;
            // Set the alpha value of images[1]'s color to 0
            // images[1]のColorのアルファ値を0に設定
            Color newColor = images[1].color;
            newColor.a = 0f;
            images[1].color = newColor;
            
            images[0].DOFade(0f, fadeDuration);
            images[1].DOFade(1f, fadeDuration).OnComplete(() =>
            {
                // After the fade is complete, make images[0] visible
                // フェード完了後、images[0]を見えるようにする
                images[0].sprite = newSprite;
                newColor.a = 1f;
                images[0].color = newColor; // Visible
                newColor.a = 0f;
                images[1].color = newColor; // Invisible
            });
        }

        /// <summary>
        /// Switches to a new character sprite using the sprite name.
        /// スプライト名を使用して新しいキャラクタースプライトに切り替えます。
        /// </summary>
        /// <param name="chSpriteName">Name of the character sprite.</param>
        /// <param name="newSprite">The new sprite to switch to.</param>
        /// <param name="fadeDuration">Duration of the fade transition.</param>
        public void SwitchToNewhChSprite(string chSpriteName, Sprite newSprite, float fadeDuration)
        {
            Debug.Log($"SwitchToNewhChSprite chSpriteName:{chSpriteName}");
            var chSprite = _spriteHandler.GetChSprite(chSpriteName);
            SwitchToNewSprite(chSprite.SpriteRenderers, newSprite, fadeDuration);
        }
        
        /// <summary>
        /// Switches to a new character sprite using both character and new sprite names.
        /// キャラクター名と新しいスプライト名の両方を使用して新しいキャラクタースプライトに切り替えます。
        /// </summary>
        /// <param name="chSpriteName">Name of the character sprite.</param>
        /// <param name="newSpriteName">Name of the new sprite.</param>
        /// <param name="fadeDuration">Duration of the fade transition.</param>
        public void SwitchToNewhChSprite(string chSpriteName, string newSpriteName, float fadeDuration)
        {
            Debug.Log($"SwitchToNewhChSprite chSpriteName:{chSpriteName} newSpriteName:{newSpriteName}");
            var chSprite = _spriteHandler.GetChSprite(chSpriteName);
            var newSprite = _spriteHandler.GetSprite(newSpriteName);
            SwitchToNewSprite(chSprite.SpriteRenderers, newSprite, fadeDuration);
        }

        /// <summary>
        /// Switches to a new sprite with a fade transition.
        /// フェードトランジションで新しいスプライトに切り替えます。
        /// </summary>
        /// <param name="sprites">Array of SpriteRenderer components. Must contain exactly two elements.</param>
        /// <param name="newSprite">The new sprite to switch to.</param>
        /// <param name="fadeDuration">Duration of the fade transition.</param>
        public void SwitchToNewSprite(SpriteRenderer[] sprites, Sprite newSprite, float fadeDuration)
        {
            Debug.Log("SwitchToNewSprite");
            if (sprites.Length != 2)
            {
                return;
            }
            // Cancel ongoing fade animations
            // 進行中のフェードアニメーションをキャンセル
            sprites[0].DOKill();
            sprites[1].DOKill();
            
            // Set the new sprite to sprites[1]
            // sprites[1]に新しいSpriteを設定
            sprites[1].sprite = newSprite;
            // Set the alpha value of sprites[1]'s color to 0
            // sprites[1]のColorのアルファ値を0に設定
            Color newColor = sprites[1].color;
            newColor.a = 0f;
            sprites[1].color = newColor;
            
            sprites[0].DOFade(0f, fadeDuration);
            sprites[1].DOFade(1f, fadeDuration).OnComplete(() =>
            {
                // After the fade is complete, make sprites[0] visible
                // フェード完了後、sprites[0]を見えるようにする
                sprites[0].sprite = sprites[1].sprite;
                newColor.a = 1f;
                sprites[0].color = newColor; // Visible
                newColor.a = 0f;
                sprites[1].color = newColor; // Invisible
            });
        }
    }
}