using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesLab.Pages.AddressBook
{
    public class DeleteModel : PageModel
    {
        private readonly IRepo<AddressBookEntry> _repo;
        private readonly IMediator _mediator;

        public DeleteModel(IRepo<AddressBookEntry> repo, IMediator mediator)
        {
            _repo = repo;
            _mediator = mediator;
        }

        [BindProperty] public DeleteAddressRequest DeleteAddressRequest { get; set; }

        public async Task<ActionResult> OnGet(Guid id)
        {
            Specification<AddressBookEntry> spec = new EntryByIdSpecification(id);
            AddressBookEntry temp = _repo.Find(spec)[0];
            _repo.Remove(temp);
            return RedirectToPage("Index");
        }

    }
}