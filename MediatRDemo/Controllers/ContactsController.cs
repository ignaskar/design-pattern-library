using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatRDemo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace MediatRDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<Contact> GetContact([FromRoute] Query query)
        {
            return await _mediator.Send(query);
        }

        #region Nested Classes

        public class Query : IRequest<Contact>
        {
            public int Id { get; set; }
        }

        public class ContactHandler : IRequestHandler<Query, Contact>
        {
            private ContactsContext _db;

            public ContactHandler(ContactsContext db)
            {
                _db = db;
            }
            
            public Task<Contact> Handle(Query request, CancellationToken cancellationToken)
            {
                return _db.Contacts.Where(c => c.Id == request.Id).SingleOrDefaultAsync();
            }
        }

        #endregion
    }
}
