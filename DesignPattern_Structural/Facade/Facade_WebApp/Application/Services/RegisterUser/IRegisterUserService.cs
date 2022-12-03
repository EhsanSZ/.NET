using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.RegisterUser
{
    public interface IRegisterUserService
    {
        void Execute();
    }

    public class RegisterUserService : IRegisterUserService
    {
        public void Execute()
        {
            action1();
        }

        private void action1()
        {
        }

    }
}
