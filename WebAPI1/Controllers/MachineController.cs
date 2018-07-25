using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPI1.Models;
using WebAPI1.Processors;

namespace WebAPI1.Controllers
{
    public class MachineController : ApiController
    {
        [HttpGet]
        [Route( "api/getMachine/{id}" )]
        public Machine getMachine( String id )
        {
            var machine = MachineProcessor.getMachine( id );
            return machine;
        }

        [HttpGet]
        [Route( "api/getMachineAll" )]
        public List< Machine > getMachineAll()
        {
            var getAll = MachineProcessor.getMachineAll();

            return getAll;
        }

        [HttpPost]
        [Route( "api/updateMachine" )]
        public bool updateMachine( Machine machine )
        {
            var update = MachineProcessor.updateMachine( machine );
            update.Wait();
            if( update.Status == TaskStatus.RanToCompletion )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpDelete]
        [Route( "api/deleteMachine/{id}" )]
        public bool deleteMachine( String id )
        {
            var delete = MachineProcessor.deleteMachine( id );
            delete.Wait();
            if( delete.Status == TaskStatus.RanToCompletion )
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
