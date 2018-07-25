using MongoDB.Bson;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WebAPI1.Models;
using WebAPI1.Repositories;

namespace WebAPI1.Processors
{
    public class MachineProcessor
    {
        public static Machine getMachine( String id )
        {
            // TODO Do all heavy Processing Here
            ObjectId machineId = ObjectId.Parse( id );

            Machine machine = MachineRepository.getMachine(machineId);

            string directory = "F:\\MongoDB\\ServerStats\\" + machine.machineName + "\\";
            string[] files = Directory.GetFiles(directory);
            for( int i=0; i<files.Length; i++)
            {
                string stat = File.ReadAllText(directory + files[i]);
                machine.machineStats.Add( JsonConvert.DeserializeObject< Stats >( stat ) );
            }

            return machine;
        }

        public static List< Machine > getMachineAll()
        {
            // TODO Do all heavy Processing Here
            
            return MachineRepository.getMachineAll();
        }

        public static async Task< bool > updateMachine( Machine machine )
        {
            // TODO Do all heavy Processing Here
            var update = await MachineRepository.updateMachine( machine );

            // Write Stats to File
            try
            {
                string directory = "F:\\MongoDB\\ServerStats\\" + machine.machineName;
                string file = directory + "\\" + ToSafeFileName(machine.machineStats[0].currentTime.ToString()) + ".csv";
                Directory.CreateDirectory(directory);

                string machineDetails = JsonConvert.SerializeObject(machine.machineStats[0]);

                File.WriteAllText(file, machineDetails);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception in API = " + e.Message);
            }
            
    
            return true;
        }

        public static string ToSafeFileName(string s)
        {
            return s
                .Replace(":", "")
                .Replace("/", "");
        }

        public static async Task< bool > deleteMachine( String id )
        {
            // TODO Do all heavy Processing Here

            ObjectId machineId = ObjectId.Parse( id );

            var delete = await MachineRepository.deleteMachine( machineId );
            return true;
        }
        
    }
}