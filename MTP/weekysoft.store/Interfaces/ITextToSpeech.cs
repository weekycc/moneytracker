using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using weekysoft.store.Enums;

namespace weekysoft.store.Interfaces
{
    public interface ITextToSpeech
    {
        void Speak(string text, VoiceType voice = VoiceType.Self);

    }
}
