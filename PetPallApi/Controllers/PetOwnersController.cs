using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using PetPallApi.Models;

namespace PetPallApi.Controllers
{
    public class PetOwnersController : ApiController
    {   
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}