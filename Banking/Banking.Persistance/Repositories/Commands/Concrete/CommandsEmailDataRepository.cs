using AutoMapper;
using Banking.Domain.Entities;
using Banking.Persistance.Repositories.Base;
using Banking.Persistance.Repositories.Commands.Abstract;
using BankingApp.DataTransferObject.Externals;
using Microsoft.EntityFrameworkCore;

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

        public async Task<bool> EditEmail(UpdatedEmailExternal email, int emailId, CancellationToken cancellationToken)
        {
            var emailToUpdate = await _context.Emails.FirstOrDefaultAsync(x => x.Id == emailId);

            if (emailToUpdate == null)
            {
                return false;
            }

            emailToUpdate.Address = email.Address;

            _context.Emails.Update(emailToUpdate);
            var result = await _context.SaveChangesAsync(cancellationToken);

            return Convert.ToBoolean(result);
        }

        public async Task<bool> DeleteEmail(int emailId, CancellationToken cancellationToken)
        {
            var emailToRemove = await _context.Emails.FirstOrDefaultAsync(x => x.Id == emailId);

            if (emailToRemove == null)
            {
                return false;
            }

            _context.Emails.Remove(emailToRemove);

            var result = await _context.SaveChangesAsync(cancellationToken);

            return Convert.ToBoolean(result);
        }
    }
}
