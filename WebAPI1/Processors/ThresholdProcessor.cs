using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebAPI1.Models;
using WebAPI1.Repositories;

namespace WebAPI1.Processors
{
    public class ThresholdProcessor
    {
        public static Threshold getThresholds()
        {
            // TODO Do all heavy Processing Here

            return ThresholdRepository.getThresholds();
        }

        public static async Task<bool> updateThresholds( Threshold threshold )
        {
            // TODO Do all heavy Processing Here
            var update = await ThresholdRepository.updateThresholds( threshold );
            return true;
        }

    }
}