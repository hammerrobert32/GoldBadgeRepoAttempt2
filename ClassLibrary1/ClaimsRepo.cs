using Claims_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class ClaimsRepo
    {
        private Queue<ClaimsPoco> _claimsQ = new Queue<ClaimsPoco>();

        //Create  (Enqueue)
        public void AddClaimsQueue(ClaimsPoco claim)
        {
            _claimsQ.Enqueue(claim);
        }


        //Read    (View All)
        public Queue<ClaimsPoco> ViewClaimsQueue()
        {
            return _claimsQ;
        }


        //Helper
        public ClaimsPoco GetClaimById(int claimId)
        {
            foreach(ClaimsPoco claim in _claimsQ)
            {
                if (claim.ClaimId == claimId)
                {
                    return claim;
                }
                
            }
            return null;
        }
    }
}
