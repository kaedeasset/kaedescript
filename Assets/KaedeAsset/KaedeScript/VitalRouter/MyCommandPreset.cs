using VitalRouter;
using VitalRouter.MRuby;

namespace KaedeAsset.KaedeScript.VitalRouter
{
    [MRubyCommand("move", typeof(CharacterMoveCommand))]   // < Your custom command name and type list here 
    [MRubyCommand("speak", typeof(CharacterSpeakCommand))]
    [MRubyCommand("speak2", typeof(CharacterSpeakCommand2))]
    partial class MyCommandPreset : MRubyCommandPreset
    {

    }

// Your custom command decralations
    [MRubyObject]
    public partial struct CharacterMoveCommand : ICommand
    {
        public string Id;
        //public Vector3 To;
        public int To;
    }

    [MRubyObject]
    public partial struct CharacterSpeakCommand : ICommand
    {
        public string Id;
        public string Text;
    }
    
    [MRubyObject]
    public partial struct CharacterSpeakCommand2 : ICommand
    {
        public string Id;
        public string Text;
    }
}