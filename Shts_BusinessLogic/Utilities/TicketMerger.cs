using System.Collections.Generic;
using Shts.Dal;
using Shts.Dal.DTOs;
using Shts_BusinessLogic.BusinessLogic_Interfaces;
using Shts_BusinessLogic.Collection_Interfaces;
using Shts_BusinessLogic.Collections;
using Shts_Entities.Enums;

namespace Shts_BusinessLogic.Utilities
{
    public class TicketMerger
    {
        private static IUserCollection _userColl;
        private static List<TicketDto> _ticketList;

        public static List<TicketDto> MergeDuplicateTickets(List<TicketDto> tickets)
        {
            _ticketList = new List<TicketDto>();
            foreach (TicketDto t1 in tickets)
            {
                bool duplicatesFound = false;
                foreach (TicketDto t2 in _ticketList)
                {
                    if (t1.Subject == t2.Subject && t1.Content == t2.Content && t1.CreatedAt == t2.CreatedAt &&
                        t1.AuthorId != t2.AuthorId)
                    {
                        duplicatesFound = true;
                        SetTicketAgent(t2, t1);
                    }
                }

                if (!duplicatesFound)
                    _ticketList.Add(t1);
            }

            return _ticketList;
        }

        private static void SetTicketAgent(TicketDto realTicket, TicketDto agentTicket)
        {
            _userColl = new UserCollection(new AccountManager());
            IUser user = _userColl.GetUserById(agentTicket.AuthorId);
            if (user.Role != UserRole.SupportUser)
            {
                realTicket.AgentId = user.Id;
            }
        }
    }
}