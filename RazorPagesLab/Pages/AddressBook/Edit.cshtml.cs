using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesLab.Pages.AddressBook
{
    public class EditModel : PageModel
	{
		private readonly IRepo<AddressBookEntry> _repo;
		private readonly IMediator _mediator;

		[BindProperty] public UpdateAddressRequest UpdateAddressRequest { get; set; }

		public EditModel(IRepo<AddressBookEntry> repo, IMediator mediator)
		{
			_repo = repo;
			_mediator = mediator;
		}

        public async void OnGet(Guid id)
        {
            Specification<AddressBookEntry> spec = new EntryByIdSpecification(id);
            AddressBookEntry temp = _repo.Find(spec)[0];

            UpdateAddressRequest = new UpdateAddressRequest();
            UpdateAddressRequest.Id = temp.Id;
            UpdateAddressRequest.Line1 = temp.Line1;
            UpdateAddressRequest.Line2 = temp.Line2;
            UpdateAddressRequest.City = temp.City;
            UpdateAddressRequest.State = temp.State;
            UpdateAddressRequest.PostalCode = temp.PostalCode;
            _ = await _mediator.Send(UpdateAddressRequest);

        }

        public async Task<ActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                _ = await _mediator.Send(UpdateAddressRequest);
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}