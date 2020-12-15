using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB2_ClaimsRepo
{
    public class ClaimRepo
    {
        private Queue<Claim> _queueOfClaim = new Queue<Claim>();



        //Add to Queue Option
        public void AddClaimToQueue(Claim claim)
        {
            _queueOfClaim.Enqueue(claim);
        }

        //Display Queued Claims
        public Queue<Claim> GetClaimQueue()
        {
            return _queueOfClaim;
        }

        //Remove Claim from Queue
        public bool DequeueClaim()
        {
            int initialCount = _queueOfClaim.Count;
            _queueOfClaim.Dequeue();

            if (initialCount > _queueOfClaim.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



    }
}
