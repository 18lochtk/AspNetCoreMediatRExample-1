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

        public void OnGet(Guid id)
        {
            // Todo: Use repo to get address book entry, set UpdateAddressRequest fields.
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