using UnityEngine;
using VitalRouter;

namespace KaedeAsset.KaedeScript.VitalRouter
{
    [Routes] // < If routing as a MonoBehaviour
    public partial class MyPresentor
    {
        public void On(CharacterMoveCommand cmd)
        {
            Debug.Log($"CharacterMoveCommand On {cmd.Id} {cmd.To}");
            // Do something ...
        }
        
        // This is called when a FooCommand is published.
        public void On(CharacterSpeakCommand cmd)
        {
            Debug.Log($"CharacterSpeakCommand On {cmd.Id} {cmd.Text}");
            // Do something ...
        }
        
        public void On(CharacterSpeakCommand2 cmd)
        {
            Debug.Log($"CharacterSpeakCommand2 On {cmd.Id} {cmd.Text}");
            // Do something ...
        }
        
#if false
        // This is called when a FooCommand is published.
        public void On(MyCSCommandPreset.FooCommand cmd)
        {
            Debug.Log($"FooCommand On {cmd.X} {cmd.Y}");
            // Do something ...
        }

        public void On(MyCSCommandPreset.BarCommand  cmd)
        {
            Debug.Log($"FooCommand On {cmd.Id} {cmd.Destination}");
            // Do something ...
        }
#endif
        
    }
}