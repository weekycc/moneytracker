using MTP.Entities;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTP.Events
{
    public class AccountUpdatingEvent : PubSubEvent<Account>
    {
    }
}
