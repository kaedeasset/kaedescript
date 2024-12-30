using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace KaedeAsset.KaedeScript.View
{
    public class ImageAnimator : MonoBehaviour
    {
        // Reference to the NovelView component, set via the Inspector
        public NovelView novelView;

        // Injected SpriteHandler dependency
        [Inject]
        private SpriteHandler _spriteHandler;

        // Dictionary to manage animation sequences for GameObjects
        private readonly Dictionary<GameObject, Sequence> _sequences = new Dictionary<GameObject, Sequence>();

        private void Awake()
        {
            Debug.Log($"ImageAnimator Awake _spriteHandler={_spriteHandler}");
            DOTween.Init();
        }

        private Sequence GetOrCreateSequence(GameObject obj, Action<Sequence> applyAnimation)
        {
            if (!_sequences.TryGetValue(obj, out var sequence) || !sequence.IsActive() || sequence.IsComplete())
            {
                sequence = DOTween.Sequence().Pause().SetAutoKill(false);
                _sequences[obj] = sequence;
            }

            applyAnimation(sequence);

            return sequence;
        }
    }
}