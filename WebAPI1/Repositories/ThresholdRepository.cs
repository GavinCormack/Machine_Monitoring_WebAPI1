using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebAPI1.Models;

namespace WebAPI1.Repositories
{
    public class ThresholdRepository
    {
        public static Threshold getThresholds()
        {
            Threshold resultThreshold = DB.mongoThresholdCollection.Find( t => t.cpuLimit != null ).First();
            return resultThreshold;
        }


        public static async Task<bool> updateThresholds( Threshold threshold )
        {
            UpdateOptions updateOptions = new UpdateOptions();
            updateOptions.IsUpsert = true; // Insert if does not exist, update if does.

            var updatedThresholds = Builders<Threshold>.Update.Set( t => t.upTimeLimit, threshold.upTimeLimit )
                                                        .Set( t => t.cpuLimit, threshold.cpuLimit )
                                                        .Set( t => t.ramLimit, threshold.ramLimit )
                                                        .Set( t => t.freeLimit, threshold.freeLimit )
                                                        .Set( t => t.percentLimit, threshold.percentLimit );
            var updateResult = DB.mongoThresholdCollection.UpdateOneAsync( t => t.cpuLimit != null, updatedThresholds, updateOptions );

            return true;
            
        }
    }
}