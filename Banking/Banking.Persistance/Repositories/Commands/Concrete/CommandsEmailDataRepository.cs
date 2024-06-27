using AutoMapper;
using Banking.Domain.Entities;
using Banking.Persistance.Repositories.Base;
using Banking.Persistance.Repositories.Commands.Abstract;
using BankingApp.DataTransferObject.Externals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Persistance.Repositories.Commands.Concrete
{
    internal class CommandsEmailDataRepository : ICommandsEmailDataRepository
    {
        private readonly ICommandDbContext _context;
        private readonly IMapper _mapper;

        public CommandsEmailDataRepository(ICommandDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddEmail(CreatedEmailExternal email, CancellationToken cancellationToken)
        {
            var emailToAdd = _mapper.Map<Email>(email);

            await _context.Emails.AddAsync(emailToAdd);
            await _context.SaveChangesAsync(cancellationToken);

            return emailToAdd.Id;
        }
    }
}
