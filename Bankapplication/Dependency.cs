using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bankapplication
{
    class Dependency
    {
        readonly IBankServices _bankService;
        readonly DbContext _context;


        public Dependency(IBankServices service, DbContext context)
        {
            _bankService = service;
            _context = context;
        }

        public void RunDependency()
        {
            _bankService.GetBankAccountByName();
        }
    }
}
