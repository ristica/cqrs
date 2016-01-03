﻿using System;
using BankAccount.CommandHandlers.Base;
using BankAccount.Commands;
using BankAccount.Infrastructure.CommandHandling;
using BankAccount.Infrastructure.Storage;

namespace BankAccount.CommandHandlers
{
    public class DeleteBankAccountCommandHandler : BaseBankAccountCommandHandler, ICommandHandler<DeleteCustomerCommand>
    {
        public DeleteBankAccountCommandHandler(ICommandStackRepository<Domain.BankAccount> repository) 
            : base(repository)
        {
        }

        public void Execute(DeleteCustomerCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            var aggregate = this.Repository.GetById(command.Id);

            aggregate.DeleteBankAccount();

            this.Repository.Save(aggregate, aggregate.Version);
        } 
    }
}
