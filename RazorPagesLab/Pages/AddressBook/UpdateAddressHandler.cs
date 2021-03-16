using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace RazorPagesLab.Pages.AddressBook
{
    public class UpdateAddressHandler
        : IRequestHandler<UpdateAddressRequest>
    {
        private readonly IRepo<AddressBookEntry> _repo;

        public UpdateAddressHandler(IRepo<AddressBookEntry> repo)
        {
            _repo = repo;
        }

        Task<Unit> IRequestHandler<UpdateAddressRequest, Unit>.Handle(UpdateAddressRequest request, CancellationToken cancellationToken)
        {
            Specification < AddressBookEntry >  spec = new EntryByIdSpecification(request.Id);
            AddressBookEntry temp = _repo.Find(spec)[0];
            temp.Update(request.Line1, request.Line2, request.City, request.State, request.PostalCode);
            _repo.Update(temp);
            return Task.FromResult(Unit.Value);
        }
    }
}