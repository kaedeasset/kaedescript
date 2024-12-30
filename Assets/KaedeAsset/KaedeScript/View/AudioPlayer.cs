using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace KaedeAsset.KaedeScript.View
{
    public class AudioPlayer : MonoBehaviour
    {
        // Reference to the AudioSource components
        // AudioSource コンポーネントへの参照
        public AudioSource audioSource1;
        public AudioSource audioSource2;

        void Awake()
        {
            // Debug.Log("AudioPlayer Awake");
            // Get the AudioSource components
            // AudioSource コンポーネントを取得
            if (audioSource1 == null)
            {
                Debug.LogError("AudioPlayer audioSource1 is null");
                // audioSource1 が null の場合のエラーログ
            }

            if (audioSource2 == null)
            {
                Debug.LogError("AudioPlayer audioSource2 is null");
                // audioSource2 が null の場合のエラーログ
            }
        }

        // Method to play background music
        // BGM を再生するメソッド
        public void PlayBGM()
        {
            audioSource2.Play();
            // audioSource2 を再生
        }

        // Method to play an audio file
        // 音声ファイルを再生するメソッド
        public void PlayAudio(string filePath)
        {
            // Load an audio clip from the Resources folder
            // Resourcesフォルダからオーディオクリップをロード
            Debug.Log($"PlayAudio {filePath}");
            AudioClip clip = Resources.Load<AudioClip>(filePath);

            if (clip != null)
            {
                audioSource1.clip = clip;
                Debug.Log("Play");
                // Play the audio
                // 再生
                audioSource1.Play();
            }
            else
            {
                Debug.LogError("Audio file not found at: " + filePath);
                // 指定されたパスに音声ファイルが見つからない場合のエラーログ
            }
        }
    }
}