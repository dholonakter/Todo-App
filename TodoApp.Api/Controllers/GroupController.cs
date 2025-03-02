using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Contracts;
using TodoApp.Api.DTO.Group;
using ToDoApp.Domain.Entities;

namespace TodoApp.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GroupController : ControllerBase
	{
		private readonly ITodoService _todoService;
		public GroupController(ITodoService todoService)
		{
			_todoService = todoService;
		}

		/// <summary>
		/// Creates a Group.
		/// </summary>
		/// <param name="group"></param>
		/// <returns>A newly created Group</returns>
		/// <remarks>
		/// Sample request:
		///
		///     POST /Todo/Group
		///     {
		///        "id": guid,
		///        "name": "Dholon",
		///     }
		///
		/// </remarks>
		/// <response code="201">Returns the newly created item</response>
		/// <response code="400">If the item is null</response>
		[HttpPost]
		[ProducesResponseType(statusCode: StatusCodes.Status201Created)]
		[ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
		public IActionResult PostNewGroup(GetGroupDto group)
		{
			var group_object = new Group { ID = Guid.NewGuid(), Name = group.Name };
			_todoService.CreateANewGroup(group_object);
			return Ok("Group created successfully.");
		}

		/// <summary>
		/// Update a group
		/// </summary>
		/// <param name="group"></param>
		/// <returns></returns>
		[HttpPut("{group_id}")]
		[ProducesResponseType(statusCode: StatusCodes.Status200OK)]
		public IActionResult UpdateGroup([FromRoute] Guid group_id, [FromBody] UpdateGroupDto updategroup)
		{
			var group_object = new Group { Name = updategroup.Name };
			_todoService.UpdateGroup(group_id, group_object);
			return Ok("Updated successfully");
		}


		/// <summary>
		/// Reads all group
		/// </summary>
		/// <returns> Returns a list of groups</returns>
		[HttpGet]
		[ProducesResponseType(statusCode: StatusCodes.Status200OK)]
		[ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
		public IActionResult GetGroup()
		{
			var group_list = _todoService.GetAllGroups();
			if (group_list == null || !group_list.Any())
			{
				return NoContent();
			}
			var result = group_list.Select(g => new GetGroupDto { Name = g.Name });
			if (result == null || !result.Any())
			{
				return NoContent();

			}
			return Ok(result);
		}

		/// <summary>
		/// Delete the Group
		/// </summary>
		/// <returns></returns>
		[HttpDelete("{group_id}")]
		[ProducesResponseType(statusCode: StatusCodes.Status200OK)]
		[ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
		public IActionResult DeletedGroup([FromRoute] Guid group_id)
		{
			_todoService.DeletedGroup(group_id);
			return Ok("deleted group successfully.");
		}

	}
}
