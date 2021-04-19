using AwePay_DataAccess;
using AwePay_Service;
using AwePay_Service.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace AwePay_WebAPI.Controllers
{
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		[Route("User/Index")]
		[HttpGet]
		[Consumes(MediaTypeNames.Application.Json)]
		public IEnumerable<string> Index()
		{
			return new string[] { "This return data is to Test the API is working. Kindly Ignore this." };
		}

		[Route("User/Create")]
		[HttpPost]
		[Consumes(MediaTypeNames.Application.Json)]
		public IActionResult Create(UserData newUser)
		{
			StdResponse<string> response = new StdResponse<string>();
			try
			{
				long result = _userService.CreateUser(newUser);
				response.response = string.Empty;

				if (result > 0)
				{
					response.responseMessage = Messages.UserCreated;
					response.response = Convert.ToString(result);
					response.responseCode = Convert.ToString(Enums.StatusCode.Created201);
				}
				else if (result == Convert.ToInt32(Enums.ReturnValue.Minus1.GetStringValue()))
				{
					response.responseMessage = Messages.AlreadyExists;
					response.response = Convert.ToString(result);
					response.responseCode = Convert.ToString(Enums.StatusCode.AlreadyExists409);
				}
				else if (result == Convert.ToInt32(Enums.ReturnValue.Minus2.GetStringValue()))
				{
					response.responseMessage = Messages.IncorrectInput;
					response.response = Convert.ToString(result);
					response.responseCode = Convert.ToString(Enums.StatusCode.InvalidData);
				}
				else
				{
					response.responseMessage = Messages.SomethingWentWrong;
					response.response = Convert.ToString(result);
					response.responseCode = Convert.ToString(Enums.StatusCode.InternalServerError500);
				}
			}
			catch (Exception ex)
			{
				response.responseCode = StatusCodes.Status500InternalServerError.ToString();
				response.responseMessage = ex.Message;
				response.response = string.Empty;
			}
			return Ok(response);

		}

		[Route("User/Update")]
		[HttpPut]
		[Consumes(MediaTypeNames.Application.Json)]
		public IActionResult Update(int id, UserData updatedUser)
		{
			StdResponse<string> response = new StdResponse<string>();
			try
			{
				long result = _userService.UpdateUser(id, updatedUser);
				response.response = string.Empty;

				if (result > 0)
				{
					response.responseMessage = Messages.UserUpdated;
					response.response = Convert.ToString(result);
					response.responseCode = Convert.ToString(Enums.StatusCode.Ok200);
				}
				else if (result == Convert.ToInt32(Enums.ReturnValue.Minus2.GetStringValue()))
				{
					response.responseMessage = Messages.IncorrectInput;
					response.response = Convert.ToString(result);
					response.responseCode = Convert.ToString(Enums.StatusCode.InvalidData);
				}
				else
				{
					response.responseMessage = Messages.NotFound;
					response.response = Convert.ToString(result);
					response.responseCode = Convert.ToString(Enums.StatusCode.NotFound404);
				}
			}
			catch (Exception ex)
			{
				response.responseCode = StatusCodes.Status500InternalServerError.ToString();
				response.responseMessage = ex.Message;
				response.response = string.Empty;
			}
			return Ok(response);
		}

		[Route("User/Delete/{id}")]
		[HttpDelete]
		[Consumes(MediaTypeNames.Application.Json)]
		public IActionResult Delete(int id)
		{
			StdResponse<string> response = new StdResponse<string>();
			try
			{
				bool result = _userService.DeleteUSer(id);
				response.response = string.Empty;

				if (result)
				{
					response.responseMessage = Messages.UserDeleted;
					response.response = Convert.ToString(result);
					response.responseCode = Convert.ToString(Enums.StatusCode.Ok200);
				}
				else
				{
					response.responseMessage = Messages.SomethingWentWrong;
					response.response = Convert.ToString(result);
					response.responseCode = Convert.ToString(Enums.StatusCode.InternalServerError500);
				}
			}
			catch (Exception ex)
			{
				response.responseCode = StatusCodes.Status500InternalServerError.ToString();
				response.responseMessage = ex.Message;
				response.response = string.Empty;
			}
			return Ok(response);
		}

		[Route("User/Search/{keyword}/{email}/{phone}")]
		[HttpGet]
		[Consumes(MediaTypeNames.Application.Json)]
		public IActionResult SearchUser(bool email, bool phone, string keyword)
		{
			StdResponse<List<UserData>> response = new StdResponse<List<UserData>>();
			try
			{
				var result = _userService.SearchUser(email, phone, keyword);
				response.response = null;

				if (result != null)
				{
					response.responseMessage = Messages.UserListed;
					response.response = result;
					response.responseCode = Convert.ToString(Enums.StatusCode.Ok200);
				}
				else
				{
					response.responseMessage = Messages.NotFound;
					response.response = result;
					response.responseCode = Convert.ToString(Enums.StatusCode.NotFound404);
				}
			}
			catch (Exception ex)
			{
				response.responseCode = StatusCodes.Status500InternalServerError.ToString();
				response.responseMessage = ex.Message;
				response.response = null;
			}
			return Ok(response);
		}
	}
}
