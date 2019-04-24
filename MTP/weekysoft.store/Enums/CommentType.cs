using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using weekysoft.store.Attributes;

namespace weekysoft.store.Enums
{
    public enum CommentType
    {
        [DisplayName("I love this app!!")]
        LoveIt,
        [DisplayName("I found a bug")]
        FoundABug,
        [DisplayName("New feature request")]
        FeatureRequest,
        [DisplayName("I hate this app!!")]
        HateIt,
        [DisplayName("Just thought of something...")]
        Other
    }
}
