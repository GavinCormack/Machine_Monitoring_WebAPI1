using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebAPI1.Models;
using WebAPI1.Processors;

namespace WebAPI1.Controllers
{
    public class ThresholdController : ApiController
    {
        [HttpGet]
        [Route( "api/getThresholds" )]
        public Threshold getThresholds()
        {
            var thresholds = ThresholdProcessor.getThresholds();
            return thresholds;
        }
        

        [HttpPost]
        [Route( "api/updateThresholds" )]
        public bool updateThresholds( Threshold threshold )
        {
            var update = ThresholdProcessor.updateThresholds( threshold );
            update.Wait();
            if(update.Status == TaskStatus.RanToCompletion)
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