using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Identity.Models.Dto;
using Identity.Models.Dto.Account;
using Identity.Models.Entities;
using Identity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly EmailService _emailService;
        public AccountController(UserManager<User> userManager, 
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = new EmailService();
        }

        [Authorize]
        public IActionResult Index()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            MyAccountinfoDto myAccount = new MyAccountinfoDto()
            {
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                FullName = $"{user.FirstName} {user.LastName}",
                Id = user.Id,
                PhoneNumber = user.PhoneNumber,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                TwoFactorEnabled = user.TwoFactorEnabled,
                UserName = user.UserName,
            };
            return View(myAccount);
        }

        [Authorize]
        public IActionResult TwoFactorEnabled()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var Result = _userManager.SetTwoFactorEnabledAsync(user, !user.TwoFactorEnabled).Result;
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterDto register)
        {
            if(ModelState.IsValid ==false)
            {
                return View(register);
            }

            User newUser = new User()
            {
                FirstName = register.FirstName,
                LastName = register.LastName,
                Email = register.Email,
                UserName = register.Email,
            };

           var result= _userManager.CreateAsync(newUser, register.Password).Result;
            if (result.Succeeded)
            {
                var token = _userManager.GenerateEmailConfirmationTokenAsync(newUser).Result;
                string callbackUrl = Url.Action("ConfirmEmail", "Account", new
                {
                    UserId = newUser.Id
                ,
                    token = token
                }, protocol: Request.Scheme);

                string body = $"لطفا برای فعال حساب کاربری بر روی لینک زیر کلیک کنید!  <br/> <a href={callbackUrl}> Link </a>";
                _emailService.Execute(newUser.Email, body, "فعال سازی حساب کاربری ");

                return RedirectToAction("DisplayEmail");
            }

            string message="";
            foreach (var item in result.Errors.ToList())
            {
                message += item.Description + Environment.NewLine;
            }
            TempData["Message"] = message;
            return View(register);
        }

        public IActionResult ConfirmEmail(string UserId, string Token)
        {
            if (UserId == null || Token == null)
            {
                return BadRequest();
            }
            var user = _userManager.FindByIdAsync(UserId).Result;
            if (user == null)
            {
                return View("Error");
            }

            var result = _userManager.ConfirmEmailAsync(user, Token).Result;
            if (result.Succeeded)
            {
                /// return 
            }
            else
            {

            }
            return RedirectToAction("login");

        }
        public IActionResult DisplayEmail()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = "/")
        {

            return View( new LoginDto
            {
                 ReturnUrl=returnUrl,
            });
        }

        [HttpPost]
        public IActionResult Login(LoginDto login)
        {
            if(!ModelState.IsValid)
            {
                return View(login);
            }

            var user = _userManager.FindByNameAsync(login.UserName).Result;

            _signInManager.SignOutAsync();

           var result= _signInManager.PasswordSignInAsync(user, login.Password, login.IsPersistent
                , true).Result;

            if(result.Succeeded == true)
            {
                return Redirect(login.ReturnUrl);
            }
            if(result.RequiresTwoFactor ==true)
            {
                return RedirectToAction("TwoFactorLogin", new { login.UserName, login.IsPersistent });
            } 
            if(result.IsLockedOut)
            {
                //
            }
           
            ModelState.AddModelError(string.Empty, "Login  Error");
            return View();
        }

        public IActionResult TwoFactorLogin(string UserName, bool IsPersistent)
        {
            var user = _userManager.FindByNameAsync(UserName).Result;
            if (user == null)
            {
                return BadRequest();
            }

            var providers = _userManager.GetValidTwoFactorProvidersAsync(user).Result;

            TwoFactorLoginDto model = new TwoFactorLoginDto();
            if (providers.Contains("Phone"))
            {
                string smsCode = _userManager.GenerateTwoFactorTokenAsync(user, "Phone").Result;

                SmsService smsService = new SmsService();
                smsService.Send(user.PhoneNumber, smsCode);
                model.Provider = "Phone";
                model.IsPersistent = IsPersistent;
            }
            else if (providers.Contains("Email"))
            {
                string emailCode = _userManager.GenerateTwoFactorTokenAsync(user, "Email").Result;
                EmailService emailService = new EmailService();
                emailService.Execute(user.Email, $"Two Factor Code:{emailCode}", "Two Factor Login");

                model.Provider = "Email";
                model.IsPersistent = IsPersistent;
            }

            return View(model);

        }

        [HttpPost]
        public IActionResult TwoFactorLogin(TwoFactorLoginDto twoFactor)
        {
            if (!ModelState.IsValid)
            {
                return View(twoFactor);
            }
            var user = _signInManager.GetTwoFactorAuthenticationUserAsync().Result;

            if (user == null)
            {
                return BadRequest();
            }

            var result = _signInManager.TwoFactorSignInAsync
                (twoFactor.Provider, twoFactor.Code, twoFactor.IsPersistent, false).Result;

            if (result.Succeeded)
            {
                return RedirectToAction("index");
            }
            else if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "حساب کاربری شما قفل شده است");
                return View();
            }
            else
            {
                ModelState.AddModelError("", "کد وارد شده صحیح نیست ");
                return View();
            }
        }

        public IActionResult LogOut()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "home");
        }


        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(ForgotPasswordConfirmationDto forgot)
        {
            if (!ModelState.IsValid)
            {
                return View(forgot);
            }

            var user = _userManager.FindByEmailAsync(forgot.Email).Result;
            if (user == null || _userManager.IsEmailConfirmedAsync(user).Result == false)
            {
                ViewBag.meesage = "ممکن است ایمیل وارد شده معتبر نباشد! و یا اینکه ایمیل خود را تایید نکرده باشید";
                return View();
            }

            string token = _userManager.GeneratePasswordResetTokenAsync(user).Result;
            string callbakUrl = Url.Action("ResetPassword", "Account", new
            {
                UserId = user.Id,
                token = token
            }, protocol: Request.Scheme);

            string body = $"برای تنظیم مجدد کلمه عبور بر روی لینک زیر کلیک کنید <br/> <a href={callbakUrl}> link reset Password </a>";
            _emailService.Execute(user.Email, body, "فراموشی رمز عبور");
            ViewBag.meesage = "لینک تنظیم مجدد کلمه عبور برای ایمیل شما ارسال شد";
            return View();
        }

        public IActionResult ResetPassword(string UserId, string Token)
        {
            return View(new ResetPasswordDto
            {
                Token = Token,
                UserId = UserId,
            });
        }

        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordDto reset)
        {
            if (!ModelState.IsValid)
                return View(reset);
            if (reset.Password != reset.ConfirmPassword)
            {
                return BadRequest();
            }
            var user = _userManager.FindByIdAsync(reset.UserId).Result;
            if (user == null)
            {
                return BadRequest();
            }

            var Result = _userManager.ResetPasswordAsync(user, reset.Token, reset.Password).Result;

            if (Result.Succeeded)
            {
                return RedirectToAction(nameof(ResetPasswordConfirmation));

            }
            else
            {
                ViewBag.Errors = Result.Errors;
                return View(reset);
            }
        }

        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }


        [Authorize]
        public IActionResult SetPhoneNumber()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult SetPhoneNumber(SetPhoneNumberDto phoneNumberDro)
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var setResult = _userManager.SetPhoneNumberAsync(user, phoneNumberDro.PhoneNumber).Result;
            string code = _userManager.GenerateChangePhoneNumberTokenAsync(user, phoneNumberDro.PhoneNumber).Result;
            SmsService smsService = new SmsService();
            smsService.Send(phoneNumberDro.PhoneNumber, code);
            TempData["PhoneNumber"] = phoneNumberDro.PhoneNumber;
            return RedirectToAction(nameof(VerifyPhoneNumber));
        }

        [Authorize]
        public IActionResult VerifyPhoneNumber()
        {
            return View(new VerifyPhoneNumberDto
            {
                PhoneNumber = TempData["PhoneNumber"].ToString(),
            });
        }

        [Authorize]
        [HttpPost]
        public IActionResult VerifyPhoneNumber(VerifyPhoneNumberDto verify)
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            bool resultVerify = _userManager.VerifyChangePhoneNumberTokenAsync
                (user, verify.Code, verify.PhoneNumber).Result;
            if (resultVerify == false)
            {
                ViewData["Message"] = $"کد وارد شده برای شماره {verify.PhoneNumber} اشتباه اشت";
                return View(verify);
            }
            else
            {
                user.PhoneNumberConfirmed = true;
                _userManager.UpdateAsync(user);
            }
            return RedirectToAction("VerifySuccess");
        }

        public IActionResult VerifySuccess()
        {
            return View();
        }


        public IActionResult ExternalLogin(string ReturnUrl)
        {
            string url = Url.Action(nameof(CallBack), "Account", new
            {
                ReturnUrl
            });

            var propertis = _signInManager
                .ConfigureExternalAuthenticationProperties("Google", url);

            return new ChallengeResult("Google", propertis);
        }

        public IActionResult CallBack(string ReturnUrl)
        {
            var loginInfo = _signInManager.GetExternalLoginInfoAsync().Result;

            string email = loginInfo.Principal.FindFirst(ClaimTypes.Email)?.Value ?? null;
            if (email == null)
            {
                return BadRequest();
            }
            string FirstName = loginInfo.Principal.FindFirst(ClaimTypes.GivenName)?.Value ?? null;
            string LastName = loginInfo.Principal.FindFirst(ClaimTypes.Surname)?.Value ?? null;

            var signin = _signInManager.ExternalLoginSignInAsync("Google", loginInfo.ProviderKey
                , false, true).Result;
            if (signin.Succeeded)
            {
                if (Url.IsLocalUrl(ReturnUrl))
                {
                    return Redirect("~/");

                }
                return RedirectToAction("Index", "Home");
            }
            else if (signin.RequiresTwoFactor)
            {
                //
            }

            var user = _userManager.FindByEmailAsync(email).Result;
            if (user == null)
            {
                User newUser = new User()
                {
                    UserName = email,
                    Email = email,
                    FirstName = FirstName,
                    LastName = LastName,
                    EmailConfirmed = true,
                };
                var resultAdduser = _userManager.CreateAsync(newUser).Result;
                user = newUser;
            }
            var resultAddlogin = _userManager.AddLoginAsync(user, loginInfo).Result;
            _signInManager.SignInAsync(user, false).Wait();


            return Redirect("/");
        }
    }
}
