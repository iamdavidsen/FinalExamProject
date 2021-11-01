﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using KDBS.Data;
using KDBS.Models;
using KDBS.Models.Forms;
using KDBS.Services.CompanyService;
using KDBS.Services.GeocodingService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace KDBS.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<UserModel> _signInManager;
        private readonly UserManager<UserModel> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly ICompanyService _companyService;
        private readonly IGeocodingService _geocodingService;

        public RegisterModel(
            UserManager<UserModel> userManager,
            SignInManager<UserModel> signInManager,
            ILogger<RegisterModel> logger,
            ICompanyService companyService,
            IGeocodingService geocodingService
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _companyService = companyService;
            _geocodingService = geocodingService;
        }

        [BindProperty]
        public RegistrationForm Input { get; set; }

        public string? ReturnUrl { get; set; }

        public async Task OnGetAsync(string? returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (!ModelState.IsValid)
            {
                return Page();
            }

            Coordinate? coordinate = null;
            try
            {
                coordinate = await _geocodingService.GetCoordinate(Input.Address, Input.Zipcode);
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, "Kunne ikke finde indtastede addresse");
            }

            if (coordinate == null)
            {
                return Page();
            }

            var user = new UserModel { FirstName = Input.FirstName, LastName = Input.LastName, UserName = Input.Email, Email = Input.Email };
            var result = await _userManager.CreateAsync(user, Input.Password);

            if (result.Succeeded)
            {
                _logger.LogInformation("User created a new account with password.");

                var company = new CompanyModel()
                {
                    Name = Input.CompanyName,
                    Address = Input.Address,
                    City = Input.City,
                    ZipCode = Input.Zipcode,
                    User = user,
                    Latitude = coordinate.Latitude,
                    Longitude = coordinate.Longitude
                };
                await _companyService.CreateCompany(company);

                _logger.LogInformation("Company created");

                await _signInManager.SignInAsync(user, isPersistent: false);
                return LocalRedirect(returnUrl);
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return Page();
        }
    }
}
