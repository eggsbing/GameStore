using GameStore.Core.Senders.Mail;
using GameStore.Core.Utilities.Extensions;
using GameStore.Core.Utilities.Security;
using GameStore.Core.ViewModels.Users;
using GameStore.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.Services
{
    public interface IAccountService
    {
        Task<bool> RegisterAsync(AccountRegisterVm vm);
        Task<bool> CheckEmailAndPasswordAsync(AccountLoginVm vm);
        Task<bool> IsDuplicatedEmail(string email);
        Task<UserDetailVm> GetUserByEmailAsync(string email);
        Task<UserDetailVm> GetUserByIdAsync(int userId);

    }
    public class AccountService : IAccountService
    {
        private readonly GameStoreContext _context;
        private readonly ISecurityService _securityService;
        private readonly IMailSender _mailSender;

        public AccountService(GameStoreContext context, ISecurityService securityService, IMailSender mailSender)
        {
            _context = context;
            _securityService = securityService;
            _mailSender = mailSender;
        }

        public async Task<bool> CheckEmailAndPasswordAsync(AccountLoginVm vm)
        {
            var email = vm.Email.Fixed();
            var user = await _context.Users.SingleOrDefaultAsync(c => c.Email == email);
            if (user != null)
            {
                return _securityService.VerifyHashedPassword(user.Password, vm.Password);
            }
            return false;
        }

        public async Task<UserDetailVm> GetUserByEmailAsync(string email)
        {
            email = email.Fixed();
            var user = await _context.Users
                .SingleOrDefaultAsync(c => c.Email == email);

            return user.ToDetailViewModel();
        }

        public async Task<UserDetailVm> GetUserByIdAsync(int userId)
        {
            var user = await _context.Users
                .SingleOrDefaultAsync(c => c.Id == userId);
            return user.ToDetailViewModel();
        }

        public async Task<bool> IsDuplicatedEmail(string email)
        {
            email = email.Fixed();
            return await _context.Users.AnyAsync(c => c.Email == email);
        }

        public async Task<bool> RegisterAsync(AccountRegisterVm vm)
        {
            try
            {
                var hassPassword = _securityService.HashPassword(vm.Password);
                var emailCode = Guid.NewGuid();
                vm.Email = vm.Email.Fixed();
                await _context.Users.AddAsync(new Domain.Entities.Users.User
                {
                    FullName = vm.FullName,
                    Mobile = vm.Mobile,
                    Password = hassPassword,
                    CreateDate = DateTime.Now,
                    Email = vm.Email,
                    EmailCode = emailCode,
                    EmailConfirm = true,
                    IsActive = true,
                });
                await _context.SaveChangesAsync();
                _mailSender.Send(vm.Email, "Game Store Activate Code", $"<a href='http://eggsbing.ir/home/active/{emailCode}'>Active Link</a>");
                return true;
            }
            catch (Exception ex)
            {
                var m = ex.Message;
                return false;
            }
        }
    }
}
