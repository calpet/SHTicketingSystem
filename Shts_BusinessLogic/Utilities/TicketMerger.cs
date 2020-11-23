using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shts.Dal;
using Shts_BusinessLogic.BusinessLogic_Interfaces;
using Shts_BusinessLogic.Collection_Interfaces;
using Shts_BusinessLogic.Collections;
using Shts_BusinessLogic.Managers;
using Shts_BusinessLogic.Models;
using Shts_Entities.Enums;

namespace Shts_BusinessLogic.Utilities
{
    public class TicketMerger
    {
        private static IUserCollection _userColl;
        private static List<TicketDto> _tempList;

        public static List<TicketDto> MergeDuplicateTickets(List<TicketDto> tickets)
        {
            _tempList = new List<TicketDto>();
            foreach (TicketDto t1 in tickets)
            {
                bool duplicatesFound = false;
                foreach (TicketDto t2 in _tempList)
                {
                    if (t1.Subject == t2.Subject && t1.Content == t2.Content && t1.CreatedAt == t2.CreatedAt &&
                        t1.AuthorId != t2.AuthorId)
                    {
                        duplicatesFound = true;
                        _userColl = new UserCollection(new AccountManager(new CredentialsManager()));
                        var user = _userColl.GetUserById(t1.AuthorId);
                        if (user.Role != UserRole.SupportUser)
                        {
                            t2.AgentId = user.Id;
                        }
                    }
                }

                if (!duplicatesFound)
                    _tempList.Add(t1);
            }

            return _tempList;
        }
    }
}