using EmployeePlatform.Helper;
using EmployeePlatform.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EmployeePlatform.Models;
using System.Collections.Generic;
using System;

namespace EmployeePlatform.Controllers
{
    public class AccountController : Controller
    {
        private readonly IIdentityHelper _identityHelper;

        public AccountController(IIdentityHelper identityHelper)
        {
            _identityHelper = identityHelper;
        }

        public IActionResult Login()
        {
            var loginInfo = new UserLogin();

            return View(loginInfo);
        }

        

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Login(UserLogin model)
            {
                if (ModelState.IsValid)
                {
                    var query = @"mutation($email: String!, $password: String!){
                              login(
                                input:{
                                  email: $email,
                                  password: $password
                                }
                              ){
                                token,
                                expiredToken,
                                id,
                                role,
                                email
                              }
                             }
                            ";

                    var variable = new
                    {
                        email = model.Email,
                        password = model.Password
                    };
                    AuthenticateResponseDTO userLog = await new GraphqlConexionEntityHelper<AuthenticateResponseDTO>(_identityHelper).GraphqlConexionEntity(query, variable, true);

                    if (userLog == null)
                    {
                        TempData["Message"] = "Ingreso incorrecto";
                        TempData["Type"] = "Error";
                        return View(model);
                    }
                    var principal = _identityHelper.CreateIdentity(userLog.Id.ToString(), "", userLog);

                    await HttpContext.SignInAsync("CookieAuthentication", principal);
                    HttpContext.Session.SetString("JWToken", userLog.Token);

                    TempData["Message"] = "Bienvenido a la Plataforma de Empleados";
                    TempData["Type"] = "Ok";
                    return RedirectToAction("Index", "Employee");
                }
                else
                {
                    TempData["Message"] = "Datos incorrectos";
                    TempData["Type"] = "Error";
                    return View(model);
                }
            }

            public async Task<IActionResult> LogOff()
            {
                HttpContext.Session.Clear();
                HttpContext.Response.Cookies.Append("ASP.NET_SessionId", "");
                TempData["Message"] = "Sesión cerrada correctamente";
                TempData["Type"] = "Ok";
                await HttpContext.SignOutAsync("CookieAuthentication");
                return RedirectToAction("Index", "Home");
            }

            public IActionResult Forbidden()
            {
                return View();
            }
        }
    }
