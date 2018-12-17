using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AWSmS.Service
{
    public enum MessageType
    {
        [Description("Transactional")]
        Transactional,
        [Description("Promotional")]
        Promotional
    }
}
