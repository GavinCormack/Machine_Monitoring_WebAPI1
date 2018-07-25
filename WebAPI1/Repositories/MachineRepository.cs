using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebAPI1.Models;

namespace WebAPI1.Repositories
{

    static public class DB
    {
        static private string connectionString = "mongodb://localhost:27017";
        static private MongoClient mongoClient = new MongoClient( connectionString );
        static public IMongoDatabase mongoDatabase { get; private set; } = mongoClient.GetDatabase( "Monitoring" );

        static public IMongoCollection< Machine > mongoMachineCollection { get; set; } = mongoDatabase.GetCollection< Machine >( "Machine" );
        static public IMongoCollection< Threshold > mongoThresholdCollection { get; set; } = mongoDatabase.GetCollection< Threshold >( "Thresholds" );
    }

    public class MachineRepository
    {
        //static string connectionString = @"Data Source=gavin-dev-vm-01;Initial Catalog=GavinDatabase;Integrated Security=True";

        public static Machine getMachine( ObjectId machineId )
        {
            var result = DB.mongoMachineCollection.Find( m => m._id == machineId ).ToList();
            Machine resultMachine = result[ 0 ];

            return resultMachine;
            
        }


        public static List< Machine > getMachineAll()
        {
            List<Machine> resultMachines = DB.mongoMachineCollection.Find( m => m.machineName != null ).ToList();
            return resultMachines;
            
        }


        public static async Task<bool> updateMachine( Machine machine )
        {
            UpdateOptions updateOptions = new UpdateOptions();
            updateOptions.IsUpsert = true; // Insert if does not exist, update if does.

            var updatedMachine = Builders<Machine>.Update.Set( m => m.machineName, machine.machineName )
                                                        .Set( m => m.machineIp, machine.machineIp )
                                                        .Set( m => m.machineUpTime, machine.machineUpTime )
                                                        .Set( m => m.machineStats, machine.machineStats );
            var updateResult = DB.mongoMachineCollection.UpdateOneAsync( m => m.machineName == machine.machineName, updatedMachine, updateOptions );

            return true;
            
        }


        public static async Task<bool> deleteMachine( ObjectId machineId )
        {
            var deleteResult = DB.mongoMachineCollection.DeleteOneAsync( m => m._id == machineId );
            return true;
            
        }
        
    }
}