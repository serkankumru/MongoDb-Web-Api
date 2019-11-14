using MongoDAL.Repositories;
using MongoDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace NoSQL.Controllers
{
    public class ValuesController : ApiController
    {
        public UserRepository _UserRepository { get; set; }
        public ValuesController()
        {
            _UserRepository = new UserRepository();
        }

        [ResponseType(typeof(Users))]
        public IHttpActionResult Post([FromBody]Users entity)
        {
            if (entity == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            entity = new Users();
            entity.Age = 22;
            entity.Name = "serkan";
            entity.Surname = "kumru";
            return Ok(_UserRepository.Insert(entity));
        }

        public IHttpActionResult Put([FromBody]Users entity)
        {
            if (entity == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_UserRepository.Update(entity));
        }

        public IHttpActionResult Delete(string id)
        {
            Users user = _UserRepository.GetById(id);
            if (user == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_UserRepository.Delete(user));
        }

        public IHttpActionResult Get()
        {
            return Ok(_UserRepository.GetAll());
        }

        public IHttpActionResult Get(string id)
        {
            if (id == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_UserRepository.GetById(id));
        }
    }
}
