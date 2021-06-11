using BackendUsers.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BackendUsers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> UserManager , SignInManager<IdentityUser> SignInManager)
        {
            this.userManager = UserManager;
            this.signInManager = SignInManager;
        }


        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> Register(Registeration model)
        {
            //if (ModelState.IsValid)
            //{
            //    var data = new IdentityUser()
            //    {
            //        UserName = model.Email,
            //    };

            //    var res = await userManager.CreateAsync(data, model.Password);

            //    if (res.Succeeded)
            //    {
            //        return Ok(res);
            //    }
            //    else
            //    {
            //        foreach (var item in res.Errors)
            //        {
            //            ModelState.AddModelError("register error", item.Description);
            //        }
            //    }
            //}
            //return Ok(model);


            var data = new IdentityUser()
            {
                UserName = model.Email
            };

            try
            {
                var res = await userManager.CreateAsync(data, model.Password);
                return Ok(res);
            }
            catch (Exception)
            {

                return Ok(model);
            }

        }




        // [HttpPost]
        // [Route("Login")]
        // public async Task<ActionResult> Login(Login model)
        // {

        //     //if (ModelState.IsValid)
        //     //{
        //     //    var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

        //     //    if (result.Succeeded)
        //     //    {
        //     //        return Ok(result);
        //     //    }
        //     //    else
        //     //    {              
        //     //        ModelState.AddModelError("", "invalid username or password");                   
        //     //    }
        //     //}
        //     //return Ok(model);



        //     try
        //     {
        //         var res = await signInManager.PasswordSignInAsync(model.Email, model.Password , true , false);
        //         return Ok(res);
        //     }
        //     catch (Exception)
        //     {

        //         throw;
        //     }

        // }




        [HttpPost, Route("login")]
        public async Task<ActionResult> Login([FromBody] Login user)
        {
            var res = await signInManager.PasswordSignInAsync(user.Email, user.Password, false, false);  

            if (!res.Succeeded)  
            {
                return BadRequest("Invalid client request");
            }
            if (res.Succeeded)  
            {
                var secretKey =  new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:4200",
                    audience: "http://localhost:4200",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(50),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }



    }
}
