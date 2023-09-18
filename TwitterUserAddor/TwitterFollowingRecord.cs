using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterUserAddor
{
    public class TwitterFollowingRecord
    {
        private int index;
        private string accountId;
        private string userLink;

        public int Index { get => index; set => index = value; }
        public string AccountId { get => accountId; set => accountId = value; }
        public string UserLink { get => userLink; set => userLink = value; }

        public TwitterFollowingRecord(int currentIndex, string currentAccountId, string currentUserLink)
        {
            Index = currentIndex;
            AccountId = currentAccountId;
            UserLink = currentUserLink;

        }
    }
}
